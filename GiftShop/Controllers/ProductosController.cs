using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftShop.Models;

namespace GiftShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly PinnacleSoftwareContext _context;

        public ProductosController(PinnacleSoftwareContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public IEnumerable<Producto> GetProducto()
        {
            return _context.Producto;
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var producto = await _context.Producto.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        // PUT: api/Productos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto([FromRoute] int id, [FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != producto.ProductoId)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Productos
        [HttpPost]
        public async Task<IActionResult> PostProducto([FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducto", new { id = producto.ProductoId }, producto);
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();

            return Ok(producto);
        }

        private bool ProductoExists(int id)
        {
            return _context.Producto.Any(e => e.ProductoId == id);
        }
    }
}