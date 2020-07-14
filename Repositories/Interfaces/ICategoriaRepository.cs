using System.Collections.Generic;
using LojaVirtual.Models;
using X.PagedList;

namespace LojaVirtual.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        //CRUD
        void Cadastrar(Categoria categoria);
        void Atualizar(Categoria categoria);
        void Excluir(int Id);
        Categoria ObterCategoria(int Id);
        IEnumerable<Categoria> ObterTodasCategorias();
        IPagedList<Categoria> ObterTodasCategorias(int? pagina);
    }
}