using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class ProductoController : BaseApiController
{
    //creamos el constructor de la calse 
    private readonly MiTiendaContext _context;
    
    public ProductoController(MiTiendaContext context)
    {
       _context = context;
    }

    //generamos el metodo GET para traer o listar todos los productos de la Db
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Producto>>> Get()
    {
         var productos = await _context.Productos.ToListAsync();
         return Ok(productos);
    }

    //Metodo GET para solo traer un solo registro de productos de la Db
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
         var producto = await _context.Productos.FindAsync(id);
         return Ok(producto);
    }

        
}
