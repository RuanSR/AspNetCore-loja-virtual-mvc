using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Vizualizar()
        {
            var produto = GetProduto();
            return View(produto);
        }

        private Produto GetProduto()
        {
            return new Produto()
            {
                Id = 1,
                Nome = "Xbox One X",
                Descricao = "Jogue em 4k",
                Valor = 2000.00M
            };
        }
    }
}