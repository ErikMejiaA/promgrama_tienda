using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class MarcaController : BaseApiController
{
    //Creamos el constructor de la clase
    private readonly MiTiendaContext _context;
    
    public MarcaController(MiTiendaContext context)
    {
       _context = context;
    }

    //Metodo GET para traer todo los datos de entidad Marca de la Db
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Marca>>> Get()
    {
         var marcas = await _context.Marcas.ToListAsync();
         return Ok(marcas);
    }

    //Metodo GET para traer un solo registro de la entidad Marca de la Db
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
         var marca = await _context.Marcas.FindAsync(id);
         return Ok(marca);
    }
        
}
