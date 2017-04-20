using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLivros.Models
{
    public interface ILivroRepository
    {
        void Add(Livro item);
        IEnumerable<Livro> GetAll();
        Livro Find(string key);
        void Remove(string key);
        void Update(Livro item);
    }
}
