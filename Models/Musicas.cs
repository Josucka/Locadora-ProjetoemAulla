using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public class Musicas
    {
        [Display(Name = "#")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo obrigatorio!!")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
   
        [Display(Name = "Cantor(a)")]
        public string Cantor { get; set; }
        
        [Display(Name = "Genero")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio!!")]
        [Display(Name = "Lancamento")]
        [DataType(DataType.Date)]
        public DateTime? Lancamento { get; set; }

        [Required(ErrorMessage ="Campo Obrigatorio")]
        [Display(Name ="Filmes")]
        public int? FilmeId { get; set; }
        public Filmes temFilme { get; set; }
    }
}
