using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLivros.Models
{
    public class LivroRepository: ILivroRepository
    {
        private readonly LivroContext _context;

        public LivroRepository(LivroContext context)
        {
            _context = context;

            if (_context.Livros.Count() == 0)
                Add(new Livro { Titulo = "Item1" });
        }

        public IEnumerable<Livro> GetAll()
        {
            return _context.Livros.ToList();
        }

        public void Add(Livro item)
        {
            _context.Livros.Add(item);
            _context.SaveChanges();
        }

        public Livro Find(string key)
        {
            return _context.Livros.FirstOrDefault(t => t.ISBN == key);
        }

        public void Remove(string key)
        {
            var entity = _context.Livros.First(t => t.ISBN == key);
            _context.Livros.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Livro item)
        {
            _context.Livros.Update(item);
            _context.SaveChanges();
        }
    }
}
