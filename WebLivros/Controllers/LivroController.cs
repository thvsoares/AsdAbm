using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebLivros.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebLivros.Controllers
{
    [Route("api/[controller]")]
    public class LivroController : Controller
    {
        private readonly ILivroRepository _livroRepository;

        public LivroController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Livro> GetAll()
        {
            return _livroRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{isbn}")]
        public Livro GetByIsbn(string isbn)
        {
            return _livroRepository.Find(isbn);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Livro livro)
        {
            if (livro == null)
            {
                return BadRequest();
            }

            _livroRepository.Add(livro);

            return CreatedAtRoute(nameof(GetByIsbn), new { ISBN = livro.ISBN }, livro);
        }

        // PUT api/values/5
        [HttpPut("{isbn}")]
        public IActionResult Update(string isbn, [FromBody] Livro livro)
        {
            if (livro == null || livro.ISBN != isbn)
            {
                return BadRequest();
            }

            var livroBanco = _livroRepository.Find(isbn);
            if (livroBanco == null)
            {
                return NotFound();
            }

            livroBanco.ISBN = livro.ISBN;
            livroBanco.Titulo = livro.Titulo;
            livroBanco.Autores = livro.Autores;
            livroBanco.PalavrasChaves = livro.PalavrasChaves;
            livroBanco.Criticas = livro.Criticas;
            livroBanco.AnoPublicacao = livro.AnoPublicacao;
            livroBanco.Edicao = livro.Edicao;
            livroBanco.Editora = livro.Editora;
            livroBanco.Descricao = livro.Descricao;
            livroBanco.LivrosRelacionados = livro.LivrosRelacionados;

            _livroRepository.Update(livroBanco);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{isbn}")]
        public IActionResult Delete(string isbn)
        {
            var livro = _livroRepository.Find(isbn);
            if (livro == null)
            {
                return NotFound();
            }

            _livroRepository.Remove(isbn);
            return new NoContentResult();
        }
    }
}
