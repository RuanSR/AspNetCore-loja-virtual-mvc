using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models
{
    public class Categoria
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        
        [Required]
        [MinLength(4)]
        //TODO - Criar validação - Nome Categoria Unico no banco de dados.
        public string Nome { get; set; }

        /* 
         * Nome: Telefone sem fio
         * Slug: telefone-sem-fio
         * URL normal: www.lojavirtual.com.br/categoria/5 
         * URL Amigável e com Slug: www.lojavirtual.com.br/categoria/informatica (Url amigável)
         */
        [Required]
        [MinLength(4)]
        public string Slug { get; set; }

        /*
         * Auto-relacionamento
         * 1-Informatica - P:null
         * - 2-Mouse: P:1
         * -- 3-Mouse sem fio P:2
         * -- 4-Mouse Gamer P:2
         */

        [Display(Name = "Categoria Pai")]
        public int? CategoriaPaiId { get; set; }


        /*
         * ORM - EntityFrameworkCore
         */
         [ForeignKey("CategoriaPaiId")]
         public virtual Categoria CategoriaPai { get; set; }
    }
}