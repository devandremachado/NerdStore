﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NerdStore.Catalogo.Application.DTO
{
    public class ProdutoDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="O Campo {0} é obrigatório")]
        public Guid CategoriaId { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Imagem { get; set; }

        [Range(1, int.MinValue, ErrorMessage = "O Campo {0} precisa ter o valor minimo de {1}")]
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public int QuantidadeEstoque { get; set; }

        [Range(1, int.MinValue, ErrorMessage = "O Campo {0} precisa ter o valor minimo de {1}")]
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public int Altura { get; set; }

        [Range(1, int.MinValue, ErrorMessage = "O Campo {0} precisa ter o valor minimo de {1}")]
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public int Largura { get; set; }

        [Range(1, int.MinValue, ErrorMessage = "O Campo {0} precisa ter o valor minimo de {1}")]
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public int Profundidade { get; set; }

        public IEnumerable<CategoriaDTO> Categorias { get; set; }
    }
}
