﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoBovinos.Models
{
    public class Bovino
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public long Brinco { get; set; }

        public virtual Raca Raca { get; set; }
        [ForeignKey("Raca")]
        public long RacaId { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }
        [ForeignKey("Fornecedor")]
        public long FornecedorId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal Peso { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Data Nascimento")]
        public DateTime DtNascimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Vlr Unitário")]
        public decimal VlrUnitario { get; set; }

        [MaxLength(200, ErrorMessage = "A {0} deve ter no máximo {1} caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}