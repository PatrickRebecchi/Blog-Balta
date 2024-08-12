using Blog.Data;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers;

public class CategoryController : Controller
{
    [HttpGet("v1/categories")]
    public async Task<IActionResult> GetAsync
        ([FromServices] BlogDataContext context)
    {   try
        {var categories = await context.Categories.ToListAsync();
            return Ok(categories);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "05XE04 - Erro interno do servidor");
        }
    }

    [HttpGet("v1/categories/{id:int}")]
    public async Task<IActionResult> GetByIdAsync
        ([FromRoute] int id,
        [FromServices] BlogDataContext context)
    {
        try
        {var category = await context
            .Categories
            .FirstOrDefaultAsync(x=>x.Id == id);
        if (category == null)
            return NotFound("Conteúdo não encontrado");

            return Ok(category);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "05XE05 - Erro interno do servidor");
        }
    }

    [HttpPost("v1/categories")]
    public async Task<IActionResult> PostAsync
        ([FromBody] EditorCategoryViewModel model,
        [FromServices] BlogDataContext context)
    {
        //if (!ModelState.IsValid)
        //    return BadRequest("Algum dado incorreto");
        try
        {
            var category = new Category
            {
                Id = 0,
                Name = model.Name,
                Slug = model.Slug.ToLower(),
            };
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return Created($"/v1/categories/{category.Id}", category);
        }
        catch (DbUpdateException ex)
        {
            return StatusCode(500, "05XE9 - Não foi possivel incluir a categoria"); 
        }
        catch (Exception ex) 
        {
            return StatusCode(500, "05XE10 - Erro interno do servidor");
        }
    }

    [HttpPut("v1/categories/{id:int}")]
    public async Task<IActionResult> PutAsync   
        ([FromRoute] int id,
        [FromBody] EditorCategoryViewModel model,
        [FromServices] BlogDataContext context)
    {
        try
        {
            var category = await context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound();

            category.Name = model.Name;
            category.Slug = model.Slug;

            context.Categories.Update(category);
            await context.SaveChangesAsync();

                return Ok(model);
        }
        catch (DbUpdateException ex)
        {
            return StatusCode(500, "05XE8 - Não foi possivel alterar a categoria");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "05XE11 - Erro interno do servidor");
        }
    }

    [HttpDelete("v1/categories/{id:int}")]
    public async Task<IActionResult> DeleteAsync
        ([FromRoute] int id,
        [FromServices] BlogDataContext context)
    {
        try
        {var category = await context
            .Categories
            .FirstOrDefaultAsync(x => x.Id == id);
        if (category == null)
            return NotFound("Conteúdo não encontrado");

        context.Categories.Remove(category);
        await context.SaveChangesAsync();

            return Ok(category);
        }
        catch (DbUpdateException ex)
        {
            return StatusCode(500, "05XE7 - Não foi possivel excluir a categoria");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "05XE12 - Erro interno do servidor");
        }
    }
}
