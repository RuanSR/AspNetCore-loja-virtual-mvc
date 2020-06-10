using System;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Models
{
    public class Cliente
    {
         /* PK */
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Nome { get; set; }

        [Required]
        public DateTime Nascimento { get; set; }

        [Required]
        public string Sexo { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Senha { get; set; }
    }
}