using LojaVirtual.Models;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.Login
{
    public class LoginColaborador
    {
        private string key = "Login.Colaborador";
        private Session.Session _session;

        public LoginColaborador(Session.Session sessao)
        {
            _session = sessao;
        }

        public void Login(Colaborador colaborador)
        {
            string colaboradorJSON = JsonConvert.SerializeObject(colaborador);
            _session.Cadastrar(key, colaboradorJSON);
        }

        public Colaborador GetColaborador()
        {
            if(_session.Existe(key))
            {
                string colaboradorJSON = _session.Consultar(key);
                return JsonConvert.DeserializeObject<Colaborador>(colaboradorJSON);
            }
            return null;
        }

        public void Logout()
        {
            _session.RemoverTodos();
        }
    }
}