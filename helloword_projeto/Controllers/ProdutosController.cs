using helloword_projeto.Data;
using helloword_projeto.Models;
using Microsoft.AspNetCore.Mvc;

namespace helloword_projeto.Controllers
{

    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _db;



        public ProdutosController(ApplicationDbContext db)  // construtor iniciando a base de dados
        {
            _db = db;
        }
        public IActionResult Index()
        {

            var objListaProdutos = _db.Produtos.ToList();
            // outra forma de fazer a linha mais visualmente para entender melhor: List<Produto> objListaProdutos = _db.Produtos.ToList();

            return View(objListaProdutos);
        }
        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Adicionar(Produto prod)
        {
            if (ModelState.IsValid)
            {
                _db.Produtos.Add(prod);
                _db.SaveChanges();
                TempData["Sucesso"] = "Produto adicionado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(prod);

        }
        [HttpGet]  // ñ é preciso colocar pq ele sempre assume que é get
        public IActionResult Editar(int id)
        {
            if (id == null || id == 0)
            {
                TempData["erro"] = "Pataquada aqui não!!!";
                return RedirectToAction("Index");

            }
            Produto? prod = _db.Produtos.Find(id);
            if (prod == null)
            {
                return RedirectToAction("Index");
            }
            return View(prod);
        }
        [HttpPost]
        public IActionResult Editar(Produto prod)
        {
            if (ModelState.IsValid)
            {

                _db.Produtos.Update(prod);
                _db.SaveChanges();
                TempData["Sucesso"] = "Produto adicionado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(prod);
        }
        public IActionResult Apagar(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["erro"] = "Pataquada aqui não!!!";
                return NotFound();
            }
            Produto? prod = _db.Produtos.Find(id);
            if (prod == null)
            {
                return RedirectToAction("Index");
            }
            return View(prod);
        }




        [HttpPost]
        public IActionResult Apagar(Produto? prod)
        {
            if (prod != null)
            {
                _db.Produtos.Remove(prod);
                _db.SaveChanges();
                TempData["Sucesso"] = "Produto apagado com sucesso!";
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
