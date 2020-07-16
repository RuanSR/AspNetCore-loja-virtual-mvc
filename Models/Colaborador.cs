using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LojaVirtual.Libraries.Validacao;

namespace LojaVirtual.Models
{
    public class Colaborador
    {
        [Display(Name="Código")]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Nome { get; set; }

        [Display(Name="E-mail")]
        [Required]
        [EmailAddress]
        [EmailUnicoColaborador]
        public string Email { get; set; }

        [Required]
        [MinLength(4)]
        public string Senha { get; set; }

        [NotMapped]
        [Display(Name = "Confirme a senha")]
        [Compare("Senha")]
        public string ConfirmacaoSenha { get; set; }
        /*
         * TIPO
         * - C=Comum
         * - G=Gerente
         */
        public string Tipo { get; set; } 
    }
}