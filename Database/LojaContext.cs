using LojaVirtual.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Database
{
    public class LojaContext : DbContext
    {
        public LojaContext(DbContextOptions<LojaContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<NewsletterEmail> NewsletterEmails { get; set; }
    }
}