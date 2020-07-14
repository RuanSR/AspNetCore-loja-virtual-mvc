using System.Collections.Generic;
using System.Linq;
using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Interfaces;

namespace LojaVirtual.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private LojaContext _banco;

        public ColaboradorRepository(LojaContext banco)
        {
            _banco = banco;
        }
        public void Atualizar(Colaborador colaborador)
        {
            _banco.Update(colaborador);
            _banco.SaveChanges();
        }

        public void Cadastrar(Colaborador colaborador)
        {
            _banco.Add(colaborador);
            _banco.SaveChanges();
        }

        public void Excluir(int id)
        {
            Colaborador colaborador = ObterColaborador(id);
            _banco.Remove(colaborador);
            _banco.SaveChanges();
        }

        public Colaborador Login(string Email, string Senha)
        {
            Colaborador colaborador = _banco.Colaboradores.Where(m => m.Email == Email && m.Senha == Senha).FirstOrDefault();
            return colaborador;
        }

        public Colaborador ObterColaborador(int id)
        {
            return _banco.Colaboradores.Find(id);
        }

        public IEnumerable<Colaborador> ObterColaboradores()
        {
            return _banco.Colaboradores.ToList();
        }
    }
}