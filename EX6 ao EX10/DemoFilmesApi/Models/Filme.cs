using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoFilmesApi.Models
{
    public class Filme
    {
        public int Id { get; set;}


        [Required(ErrorMessage = "O campo Nome é de preenchimento obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo Nome não pode exceder 200 caracteres")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo Diretor é de preenchimento obrigatório")]
        public string Diretor { get; set; }

        [Required(ErrorMessage = "O campo Genero é de preenchimento obrigatório")]
        public string Genero { get; set; }

        public int Duracao { get; set; }
    }
}
