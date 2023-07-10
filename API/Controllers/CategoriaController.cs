using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class CategoriaController : BaseApiController
{
    //creamos el constructor de la clase 
    private readonly MiTiendaContext _context;
    
    public CategoriaController(MiTiendaContext context)
    {
       _context = context;
    }

    //Metodo GET para traer todos lo registros de la entidad Categoria de la Db
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Categoria>>> Get()
    {
         var Categorias = await _context.Categorias.ToListAsync();
         return Ok(Categorias);
    }

    //Metodo GET para taer un solo registro de la entidad Categoria de la Db por ID
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
         var categoria = await _context.Categorias.FindAsync(id);
         return Ok(categoria);
    }
        
}
