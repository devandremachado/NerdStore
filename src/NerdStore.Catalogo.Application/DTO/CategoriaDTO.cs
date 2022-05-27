using System;
using System.ComponentModel.DataAnnotations;

namespace NerdStore.Catalogo.Application.DTO
{
    public class CategoriaDTO
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public int Codigo { get; private set; }
    }
}
