using System;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaASPNET.Models
{
    public class Livro
    {
        [Display (Name="Id")]
        public int LivroId { get; set; }

        [Required]
        [StringLength(50)]
        public string LivroTitulo { get; set; }

        [Required(ErrorMessage = "Digite o autor do livro")]
        [StringLength(50)]
        public string LivroAutor { get; set; }

        [Required(ErrorMessage = "Digite a editora do livro")]
        [StringLength(50)]
        public string LivroEditora { get; set; }

        [Required(ErrorMessage = "Digite o ano de publicação do livro")]
        public int LivroAno { get; set; }
    }
}