
using Microsoft.AspNetCore.Mvc;
using UsandoViews.Models;

namespace UsandoViews.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {

      ViewBag.QtdeUsuarios = Usuario.Listagem.Count();
      return View();
    }

    [HttpGet]
    public IActionResult Cadastrar(int? id)
    {
      if(id.HasValue && Usuario.Listagem.Any(u => u.Id == id))
      {
         var usuario = Usuario.Listagem.Single(u => u.Id == id);
         return View(usuario);
      } 
      return View();
    }

    [HttpPost]
    public IActionResult Cadastrar(Usuario usuario)
    {
      Usuario.Salvar(usuario);
      return RedirectToAction("Usuarios");
    }

    [HttpGet]
    public IActionResult Excluir(int? id)
    {
      if(id.HasValue && Usuario.Listagem.Any(u => u.Id == id))
      {
         var usuario = Usuario.Listagem.Single(u => u.Id == id);
         return View(usuario);
      } 
      return RedirectToAction("Usuarios");
    }

    [HttpPost]
    public IActionResult Excluir(Usuario usuario)
    {
      TempData["Excluiu"] = Usuario.Excluir(usuario);
      return RedirectToAction("Usuarios");
    }

    public IActionResult Usuarios()
    {
      return View(Usuario.Listagem);
    }
  }
}