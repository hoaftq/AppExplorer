using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Infrastructure;
using AutoMapper;

[ApiController]
[Route("[controller]")]
class AppExplorerController : ControllerBase
{
    private readonly AppDbContext context;
    private readonly Mapper mapper;

    public AppExplorerController(AppDbContext context, Mapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<AppDto>> GetAllApps()
    {
        return await context.Apps.Select(a => mapper.Map<AppDto>(a))
                                 .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppDetailsDto>> GetAppDetails(int id)
    {
        var result = await context.Apps.Include(a => a.Category)
                                       .Include(a => a.Languages)
                                       .Where(a => a.Id == id)
                                       .Select(a => mapper.Map<AppDetailsDto>(a))
                                       .AsNoTracking()
                                       .SingleOrDefaultAsync();
        if (result == null)
        {
            return NotFound();
        }

        return result;
    }

    //[HttpPut]
    //public async Task<IActionResult> CreateApp(AppDetailsDto dto)
    //{
    //    var app = CopyAppDetailsDtoToEntity(dto, new App());
    //    context.Apps.Add(app);
    //    await context.SaveChangesAsync();

    //    return CreatedAtAction(nameof(GetAppDetails), app.Id, app);
    //}

    //[HttpPost]
    //public async Task<IActionResult> UpdateApp(AppDetailsDto dto)
    //{
    //    var app = await context.Apps.Where(a => a.Id == dto.Id).SingleOrDefaultAsync();
    //    if (app == null)
    //    {
    //        return BadRequest();
    //    }

    //    CopyAppDetailsDtoToEntity(dto, app);
    //    await context.SaveChangesAsync();

    //    return Ok();
    //}

    //[HttpDelete]
    //public async Task<ActionResult<AppDetailsDto>> DeleteApp(int id)
    //{
    //    var app = await context.Apps.Where(a => a.Id == id).SingleOrDefaultAsync();
    //    if (app == null)
    //    {
    //        return BadRequest();
    //    }

    //    context.Apps.Remove(app);
    //    await context.SaveChangesAsync();

    //    return ConvertAppEntityToDto(app);
    //}
}
