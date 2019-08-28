﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerenciamentoBovinos.Models
{
    public class Fornecedor
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(3, ErrorMessage = "O {0} deve ter no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [MaxLength(50, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(20, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string Telefone { get; set; }

        [MaxLength(80, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string Endereco { get; set; }

        [MaxLength(30, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string CPFCNPJ { get; set; }

        [MaxLength(30, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string inscricaoestadual { get; set; }
    }
}