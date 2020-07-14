using System.Collections.Generic;
using LojaVirtual.Models;

namespace LojaVirtual.Repositories.Interfaces
{
    public interface IColaboradorRepository
    {
        Colaborador Login(string Email, string Senha);
        void Cadastrar(Colaborador colaborador);
        void Atualizar(Colaborador colaborador);
        void Excluir(int id);
        Colaborador ObterColaborador(int id);
        IEnumerable<Colaborador> ObterColaboradores();
    }
}