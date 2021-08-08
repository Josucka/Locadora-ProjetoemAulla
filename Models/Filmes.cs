using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public class Filmes
    {
        [Display(Name = "#")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo obrigatorio!!")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
   
        [Display(Name = "Sinopse")]
        public string Sinopse { get; set; }
        
        [Display(Name = "Genero")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio!!")]
        [Display(Name = "Lancamento")]
        [DataType(DataType.Date)]
        public DateTime? Lancamento { get; set; }
        
        [Display(Name = "Duracao")]
        public string Duracao { get; set; }
    }
}
