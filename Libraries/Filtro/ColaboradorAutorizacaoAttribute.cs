using System;
using LojaVirtual.Libraries.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LojaVirtual.Libraries.Filtro
{
    public class ColaboradorAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {
        LoginColaborador _loginColaborador;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginColaborador = (LoginColaborador)context.HttpContext.RequestServices.GetService(typeof(LoginColaborador));
            Models.Colaborador cliente = _loginColaborador.GetColaborador();
            if (cliente == null)
            {
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
        }
    }
}