using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLivros.Models
{
    public class LivroContext:DbContext
    {
        public LivroContext(DbContextOptions<LivroContext> options)
            : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
    }
}
