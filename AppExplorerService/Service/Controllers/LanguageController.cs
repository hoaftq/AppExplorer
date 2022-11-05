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
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly Mapper mapper;

        public LanguageController(AppDbContext dbContext, Mapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public Task<List<LanguageDto>> Get()
        {
            return dbContext.Languages.Select(l => mapper.Map<LanguageDto>(l)).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var language = await dbContext.Languages.Select(l => mapper.Map<LanguageDto>(l)).SingleOrDefaultAsync(l => l.Id == id);
            if (language == null)
            {
                return NotFound();
            }

            return Ok(language);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LanguageDto language)
        {
            var newLanguage = new Language(language.Name);
            await dbContext.Languages.AddAsync(newLanguage);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), newLanguage.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LanguageDto language)
        {
            if (id != language.Id)
            {
                return BadRequest("Id didn't match");
            }

            var existingLanguage = await dbContext.Languages.SingleOrDefaultAsync(l => l.Id == id);
            if (existingLanguage == null)
            {
                return NotFound("Language was not found");
            }

            existingLanguage.Update(language.Name);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingLanguage = await dbContext.Languages.Include(l => l.Apps).Where(l => l.Id == id).SingleOrDefaultAsync();
            if (existingLanguage == null)
            {
                return NotFound("Language was not found");
            }

            if (existingLanguage.Apps.Any())
            {
                return BadRequest("Could not delete a language that was referenced by an app");
            }

            dbContext.Languages.Remove(existingLanguage);
            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
