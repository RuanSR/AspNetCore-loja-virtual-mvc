using LojaVirtual.Models;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.Login
{
    public class LoginCliente
    {
        private string key = "Login.Cliene";
        private Session.Session _session;

        public LoginCliente(Session.Session sessao)
        {
            _session = sessao;
        }

        public void Login(Cliente cliente)
        {
            string clienteJSON = JsonConvert.SerializeObject(cliente);
            _session.Cadastrar(key, clienteJSON);
        }

        public Cliente GetCliente()
        {
            if(_session.Existe(key))
            {
                string clienteJSON = _session.Consultar(key);
                return JsonConvert.DeserializeObject<Cliente>(clienteJSON);
            }
            return null;
        }

        public void Logout()
        {
            _session.RemoverTodos();
        }
    }
}