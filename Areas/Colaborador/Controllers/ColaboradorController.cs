using LojaVirtual.Libraries.Email;
using LojaVirtual.Libraries.Filtro;
using LojaVirtual.Libraries.Texto;
using LojaVirtual.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [ColaboradorAutorizacao("G")]
    public class ColaboradorController : Controller
    {
        private IColaboradorRepository _colaboradorRespository;
        private GerenciarEmail _gerenciarEmail;

        public ColaboradorController(IColaboradorRepository colaboradorRespository, GerenciarEmail gerenciarEmail)
        {
            _colaboradorRespository = colaboradorRespository;
            _gerenciarEmail = gerenciarEmail;
        }

        public IActionResult Index(int? pagina)
        {
            IPagedList<Models.Colaborador> colaboradores = _colaboradorRespository.ObterTodosColaboradores(pagina);

            return View(colaboradores);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm]Models.Colaborador colaborador)
        {
            ModelState.Remove("Senha");
            if (ModelState.IsValid)
            {
                colaborador.Tipo = "C";
                colaborador.Senha = KeyGenerator.GetUniqueKey(8);
                _colaboradorRespository.Cadastrar(colaborador);

                _gerenciarEmail.EnviarSenhaParaColaboradorPorEmail(colaborador);

                TempData["MSG_S"] = "Registro salvo com sucesso!";

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult GerarSenha(int id)
        {
            Models.Colaborador colaborador = _colaboradorRespository.ObterColaborador(id);
            colaborador.Senha = KeyGenerator.GetUniqueKey(8);
            _colaboradorRespository.AtualizarSenha(colaborador);

            _gerenciarEmail.EnviarSenhaParaColaboradorPorEmail(colaborador);

            TempData["MSG_S"] = "Senha enviada para o e-mail do colaborador com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            Models.Colaborador colaborador = _colaboradorRespository.ObterColaborador(id);
            return View(colaborador);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm]Models.Colaborador colaborador, int id)
        {
            ModelState.Remove("Senha");
            if(ModelState.IsValid)
            {
                _colaboradorRespository.Atualizar(colaborador);

                TempData["MSG_S"] = "Registro salvo com sucesso!";

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            _colaboradorRespository.Excluir(id);

            TempData["MSG_S"] = "Registro excluído com sucesso!";

            return RedirectToAction(nameof(Index));
        }
    }
}