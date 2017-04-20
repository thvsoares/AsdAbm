using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebLivros.Models
{
    public class Livro
    {
        [Key]
        [MaxLength(13)]
        public string ISBN { get; set; }

        [Required]
        public string Titulo { get; set; }

        [MinLength(1)]
        public List<string> Autores { get; set; }

        [MinLength(1)]
        public List<string> PalavrasChaves { get; set; }

        public string Criticas { get; set; }

        public DateTime AnoPublicacao { get; set; }

        public byte Edicao { get; set; }

        public string Editora { get; set; }

        public string Descricao { get; set; }

        public List<Livro> LivrosRelacionados { get; set; }
    }
}
