using LojaVirtual.Libraries.Filtro;
using LojaVirtual.Libraries.Login;
using LojaVirtual.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class HomeController : Controller
    {
        private IColaboradorRepository _repoColaborador;
        private LoginColaborador _loginColaborador;
        
        public HomeController(IColaboradorRepository repositoryColaborador, LoginColaborador loginColaborador)
        {
            _repoColaborador = repositoryColaborador;
            _loginColaborador = loginColaborador;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm]Models.Colaborador colaborador)
        {
            Models.Colaborador colaboradorDB = _repoColaborador.Login(colaborador.Email, colaborador.Senha);

            if(colaboradorDB != null)
            {
                _loginColaborador.Login(colaboradorDB);
                return new RedirectResult(Url.Action(nameof(Painel)));
            }
            else
            {
                ViewData["MSG_E"] = "Usuario não encontrado.";
                return View();
            }
        }

        [ColaboradorAutorizacao]
        public IActionResult Logout()
        {
            _loginColaborador.Logout();
            return RedirectToAction("Login", "Home");
        }

        public IActionResult RecuperarSenha()
        {
            return View();
        }

        public IActionResult CadastrarNovaSenha()
        {
            return View();
        }

        [ColaboradorAutorizacao]
        public IActionResult Painel()
        {
            return View();
        }
    }
}