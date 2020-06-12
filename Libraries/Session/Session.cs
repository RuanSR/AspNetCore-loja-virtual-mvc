using Microsoft.AspNetCore.Http;

namespace LojaVirtual.Libraries.Session
{
    public class Session
    {
        IHttpContextAccessor _context;
        public Session(IHttpContextAccessor context)
        {
            _context = context;
        }

        public void Cadastrar(string key, string valor)
        {
            _context.HttpContext.Session.SetString(key, valor);
        }

        public void Atualizar(string key, string valor)
        {
            if(Existe(key))
            {
                _context.HttpContext.Session.Remove(key);
                _context.HttpContext.Session.SetString(key, valor);
            }
        }

        public void Remover(string key)
        {
            _context.HttpContext.Session.Remove(key);
        }

        public string Consultar(string key)
        {
            return  _context.HttpContext.Session.GetString(key);
        }

        public bool Existe(string key)
        {
           if(_context.HttpContext.Session.GetString(key) == null)
           {
               return false;
           }
           return true;
        }

        public void RemoverTodos()
        {
            _context.HttpContext.Session.Clear();
        }
    }
}