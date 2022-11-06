using AutoMapper;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public AppController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AppDto>> GetAllApps()
        {
            return await context.Apps.Select(a => mapper.Map<AppDto>(a)).ToListAsync();
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

        [HttpPut]
        public async Task<IActionResult> CreateApp(AppDetailsDto dto)
        {
            var app = mapper.Map<App>(dto);
            context.Apps.Attach(app);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAppDetails), app.Id, app);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateApp(int id, AppDetailsDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("Id didn't match");
            }

            var app = await context.Apps.Where(a => a.Id == dto.Id).SingleOrDefaultAsync();
            if (app == null)
            {
                return NotFound($"Could not find app wit Id of {id}");
            }

            mapper.Map(dto, app);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<AppDetailsDto>> DeleteApp(int id)
        {
            var app = await context.Apps.Where(a => a.Id == id).SingleOrDefaultAsync();
            if (app == null)
            {
                return NotFound("App didn't exist");
            }

            context.Apps.Remove(app);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}