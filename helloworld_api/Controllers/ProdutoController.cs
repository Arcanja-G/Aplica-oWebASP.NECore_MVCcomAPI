using helloword_projeto.Data;
using helloword_projeto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace helloworld_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly ApplicationDbContext _db;

        public ProdutoController(ApplicationDbContext db)  // construtor iniciando a base de dados
        {
            _db = db;
        }

        // GET: https://localhost:porto/api/Produtos/gettodosalunos
        [HttpGet("gettodosalunos")]
        public ActionResult GetTodosAlunos()
        {
            string[] nomeAlunos = new string[] { "Pedro", "Rafael", "Ana" };
            return Ok(nomeAlunos);
        }

        // GET: https://localhost:porto/api/Produtos/dobro/5
        [HttpGet("dobro/{numero}")]
        public ActionResult<int> GetDobro(int numero)
        {
            return Ok(numero * 2);
        }

        // GET: https://localhost:porto/api/Produtos/getProdutos
        [HttpGet("getProdutos")]
        public ActionResult<IEnumerable<Produto>> GetProdutos()
        {
            List<Produto> listaProdutos = _db.Produtos.ToList();
            return Ok(listaProdutos);
        }

        // GET: https://localhost:porto/api/Produtos/getUmProduto/5
        [HttpGet("getUmProduto/{idProduto}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Produto> GetUmProduto(int? idProduto)
        {
            if (idProduto == null)
            {
                return BadRequest();
            }

            Produto? p = _db.Produtos.Find(idProduto.Value);
            if (p != null)
                return Ok(p);

            return NotFound();
        }

        // POST: api/Produto/addProduto
        [HttpPost("addProduto")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Produto> AddProduto([FromBody] Produto p)
        {
            if (p == null)
                return BadRequest("Produto não foi passado");

            _db.Produtos.Add(p);
            _db.SaveChanges();

            // Retorna 201 Created com localização do recurso criado
            return CreatedAtAction(nameof(GetUmProduto), new { idProduto = p.Id }, p);
        }

        // DELETE: api/Produto/apagarProduto/5
        [HttpDelete("apagarProduto/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult ApagarProduto(int id)
        {
            if (id <= 0)
                return BadRequest("Não foi passado um id válido");

            Produto? p = _db.Produtos.Find(id);
            if (p == null)
                return NotFound();

            _db.Produtos.Remove(p);
            _db.SaveChanges();

            return NoContent();
        }

        // PUT: api/Produto/editarProduto/5
        [HttpPut("editarProduto/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult EditarProduto(int id, [FromBody] Produto p)
        {
            if (id <= 0)
                return BadRequest("Não foi passado um id válido");

            Produto? antigo = _db.Produtos.Find(id);
            if (antigo == null)
                return NotFound();

            antigo.Nome = p.Nome;
            antigo.Preco = p.Preco;

            _db.Produtos.Update(antigo);
            _db.SaveChanges();

            return NoContent();
        }
    }
}