using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
class AppExplorerController : ControllerBase
{
    private readonly AppExplorerContext context;

    public AppExplorerController(AppExplorerContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<AppDto>> GetAllApps()
    {
        return await context.Apps.Select(a => new AppDto()
        {
            Id = a.Id,
            Name = a.Name,
            ImagePath = a.ImagePath,
            ShortDescription = a.ShortDescription
        }).AsNoTracking().ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppDetailsDto>> GetAppDetails(int id)
    {
        var result = await context.Apps.Include(a => a.Category)
                                        .Include(a => a.AppLanguages)
                                            .ThenInclude(al => al.Language)
                                        .Where(a => a.Id == id)
                                        .Select(a => ConvertAppEntityToDto(a))
                                        .AsNoTracking()
                                        .SingleOrDefaultAsync();
        if (result == null)
        {
            return NotFound();
        }

        return result;

    }

    [HttpPut]
    public async Task<IActionResult> CreateApp(AppDetailsDto dto)
    {
        var app = CopyAppDetailsDtoToEntity(dto, new App());
        context.Apps.Add(app);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAppDetails), app.Id, app);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateApp(AppDetailsDto dto)
    {
        var app = await context.Apps.Where(a => a.Id == dto.Id).SingleOrDefaultAsync();
        if (app == null)
        {
            return BadRequest();
        }

        CopyAppDetailsDtoToEntity(dto, app);
        await context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult<AppDetailsDto>> DeleteApp(int id)
    {
        var app = await context.Apps.Where(a => a.Id == id).SingleOrDefaultAsync();
        if (app == null)
        {
            return BadRequest();
        }

        context.Apps.Remove(app);
        await context.SaveChangesAsync();

        return ConvertAppEntityToDto(app);
    }

    private AppDetailsDto ConvertAppEntityToDto(App entity) => new AppDetailsDto()
    {
        Id = entity.Id,
        Name = entity.Name,
        ShortDescription = entity.ShortDescription,
        Description = entity.Description,
        ImagePath = entity.ImagePath,
        Level = entity.Level,
        CreatedDate = entity.CreatedDate,
        UpdatedDate = entity.UpdatedDate,
        Urls = entity.Urls,
        Category = entity.Category,
        Languages = entity.AppLanguages.Select(al => al.Language).ToList()
    };

    private App CopyAppDetailsDtoToEntity(AppDetailsDto dto, App entity)
    {
        entity.Name = dto.Name;
        entity.ShortDescription = dto.ShortDescription;
        entity.Description = dto.Description;
        entity.ImagePath = dto.ImagePath;
        entity.Level = dto.Level;
        entity.Urls = dto.Urls;
        entity.Category = dto.Category;
        entity.AppLanguages = dto.Languages.Select(l => new AppLanguage()
        {
            Language = l
        }).ToList();
        return entity;
    }
}