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
        }).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<AppDetailsDto> GetAppDetails(int id)
    {
        var result = await context.Apps.Include(a => a.Category)
                                        .Include(a => a.AppLanguages)
                                            .ThenInclude(al => al.Language)
                                        .Where(a => a.Id == id)
                                        .Select(a => new AppDetailsDto()
                                        {
                                            Id = a.Id,
                                            Name = a.Name,
                                            ShortDescription = a.ShortDescription,
                                            Description = a.Description,
                                            ImagePath = a.ImagePath,
                                            Level = a.Level,
                                            CreatedDate = a.CreatedDate,
                                            UpdatedDate = a.UpdatedDate,
                                            Urls = a.Urls,
                                            Category = a.Category,
                                            Languages = a.AppLanguages.Select(al => al.Language).ToList()
                                        })
                                        .SingleOrDefaultAsync();
        return result;

    }

    [HttpPut]
    public void CreateApp(AppDetailsDto dto)
    {

    }

    [HttpPost]
    public void UpdateApp(AppDetailsDto dto)
    {

    }

    [HttpDelete]
    public void DeleteApp(int id)
    {

    }
}