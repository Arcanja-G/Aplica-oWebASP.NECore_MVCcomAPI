using helloword_projeto.Data;
using helloword_projeto.Models;
using Microsoft.AspNetCore.Mvc;

namespace helloword_projeto.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ClientesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var objListaClientes = _db.Clientes.ToList();

            return View(objListaClientes);
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Cliente clt)
        {
            if (ModelState.IsValid)
            {
                _db.Clientes.Add(clt);
                _db.SaveChanges();
                TempData["Sucesso"] = "Cliente adicionado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(clt);
        }

            [HttpGet]  // ñ é preciso colocar pq ele sempre assume que é get
            public IActionResult Editar(int? id)
            {
                if (id == null || id == 0)
                {
                    TempData["erro"] = "Pataquada aqui não!!!";
                    return RedirectToAction("Index");

                }
                Cliente? clt = _db.Clientes.Find(id);
                if (clt == null)
                {
                    return RedirectToAction("Index");
                }
                return View(clt);
            }
        [HttpPost]
        public IActionResult Editar(Cliente clt)
        {
            if (ModelState.IsValid)
            {
                _db.Clientes.Update(clt);
                _db.SaveChanges();
                TempData["Sucesso"] = "Cliente adicionado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(clt);
        }

        public IActionResult Apagar(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["erro"] = "Pataquada aqui não!!!";
                return NotFound();
            }
            Cliente? clt = _db.Clientes.Find(id);
            if (clt == null)
            {
                return RedirectToAction("Index");
            }
            return View(clt);
        }



        [HttpPost]
        public IActionResult Apagar(Cliente? clt)
        {
            if (clt != null)
            {
                _db.Clientes.Remove(clt);
                _db.SaveChanges();
                TempData["Sucesso"] = "Cliente adicionado com sucesso!";
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    
        
    }
}
