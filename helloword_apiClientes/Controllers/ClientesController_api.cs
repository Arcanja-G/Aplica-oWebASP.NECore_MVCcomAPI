using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using helloword_projeto.Data;
using helloword_projeto.Models;

using Microsoft.EntityFrameworkCore;

namespace helloword_apiClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController_api : ControllerBase
    {
        private readonly ApplicationDbContext _bdContext;
        public ClientesController_api(ApplicationDbContext bdContext)
        {
            _bdContext = bdContext;
        }

        [HttpGet("gettodosclientes")]
        public IActionResult GetTodosClientes()
        {
            var clientes = new List<string>
        {
            "Cliente 1",
            "Cliente 2",
            "Cliente 3"
        };
            return Ok(clientes);
        }

        [HttpGet("{numero}")]
        public ActionResult<int> GetDobro(int numero)
        {

            return numero * 2;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetClientes()
        {
            List<Cliente> listaClientes = _bdContext.Clientes.ToList();
            return Ok(listaClientes);
        }

        [HttpGet("getUmProduto/{idProduto}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Cliente> GetUmCliente(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Cliente? c = _bdContext.Clientes.Find(id.Value);
            if (c != null)
                return Ok(c);
            return NotFound();
        }

        // POST: api/Cliente/addCliente
        [HttpPost("addCliente")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cliente> AddCliente([FromBody] Cliente c)
        {
            if (c == null)
                return BadRequest("Cliente não foi passado");

            _bdContext.Clientes.Add(c);
            _bdContext.SaveChanges();

            // Retorna 201 Created com localização do recurso criado
            return CreatedAtAction(nameof(GetUmCliente), new { id = c.Id }, c);
        }

        // DELETE: api/Cliente/apagarCliente/5
        [HttpDelete("apagarCliente/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult ApagarCliente(int id)
        {
            if (id <= 0)
                return BadRequest("Não foi passado um id válido");

            Cliente? c = _bdContext.Clientes.Find(id);
            if (c == null)
                return NotFound();

            _bdContext.Clientes.Remove(c);
            _bdContext.SaveChanges();

            return NoContent();
        }

        // PUT: api/Cliente/editarCliente/5
        [HttpPut("editarCliente/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult EditarCliente(int id, [FromBody] Cliente c)
        {
            if (id <= 0)
                return BadRequest("Não foi passado um id válido");

            Cliente? antigo = _bdContext.Clientes.Find(id);
            if (antigo == null)
                return NotFound();

            antigo.Nome = c.Nome;
            antigo.Email = c.Email;
            antigo.Telefone = c.Telefone;

            _bdContext.Clientes.Update(antigo);
            _bdContext.SaveChanges();
            return NoContent();
        }
    }
}