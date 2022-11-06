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
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public CategoryController(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public Task<List<CategoryDto>> Get()
        {
            return dbContext.Categories.Select(c => mapper.Map<CategoryDto>(c)).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await dbContext.Categories.Select(c => mapper.Map<CategoryDto>(c)).SingleOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDto category)
        {
            var newCategory = new Category(category.Name);
            await dbContext.Categories.AddAsync(newCategory);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), newCategory.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryDto category)
        {
            if (id != category.Id)
            {
                return BadRequest("Id didn't match");
            }

            var existingCategory = await dbContext.Categories.SingleOrDefaultAsync(c => c.Id == id);
            if (existingCategory == null)
            {
                return NotFound("Category was not found");
            }

            existingCategory.Update(category.Name);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingCategory = await dbContext.Categories.SingleOrDefaultAsync(c => c.Id == id);
            if (existingCategory == null)
            {
                return NotFound("Category was not found");
            }

            if (dbContext.Apps
                .Include(a => a.Category)
                .Any(a => a.Category.Id == id))
            {
                return BadRequest("Could not delete a category that was referenced by an app");
            }

            dbContext.Categories.Remove(existingCategory);
            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
