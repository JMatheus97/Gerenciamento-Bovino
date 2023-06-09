﻿using System.ComponentModel.DataAnnotations;

namespace GerenciamentoBovinos.Models
{
    public class Pessoa : Endereco
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(3, ErrorMessage = "O {0} deve ter no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [MaxLength(50, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string Email { get; set; }

        [MaxLength(20, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string Telefone { get; set; }


        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        [Display(Name = "CPF/CNPJ")]
        public string CPFCNPJ { get; set; }
    }
}
