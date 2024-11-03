using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using $safeprojectname$.Models;
using System.Reflection.Metadata.Ecma335;
using System.Security.Authentication.ExtendedProtection;

namespace $safeprojectname$.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly Productoscontext _context;

        public ProductosController(Productoscontext context) 
        {
            _context = context;
        }

        [HttpPost]
        [Route("Crea algo xd")]

        public async Task<ActionResult>CrearProducto(Producto producto)

        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();

            return Ok();


        }

        [HttpGet] 
        [Route("Cosas que añadir")]
        public async Task<ActionResult<IEnumerable<Producto>>>ListaProductos()
            {
            var productos = await _context.Productos.ToListAsync();

            return Ok(productos);
        }

        [HttpGet]
        [Route("Ver")]

        public async Task<IActionResult>VerProducto(int id)
        {
            Producto producto = await _context.Productos.FindAsync(id);

            if (producto == null) 
            {

                return NotFound();

            }
            return Ok(producto);



        }
        [HttpPut]
        [Route("editar/revisar")] 
        public async Task<IActionResult>ActualizarProducto(int id, Producto producto)
        {

            var productoExistente = await _context.Productos.FindAsync(id);


            productoExistente!.Nombre = producto.Nombre;
            productoExistente.Descripcion = producto.Descripcion;
            productoExistente.Precio = producto.Precio;

            await _context.SaveChangesAsync();

            return Ok();    
        }

        [HttpDelete]
        [Route("Eliminar")]

        public async Task<IActionResult>EliminarProducto(int id)
        {
            var productoBorrado = await _context.Productos.FindAsync(id);

            _context.Productos.Remove(productoBorrado!);

            await _context.SaveChangesAsync();

            return Ok();

        }
    }
}
