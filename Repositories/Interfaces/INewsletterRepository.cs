using System.Collections.Generic;
using LojaVirtual.Models;

namespace LojaVirtual.Repositories.Interfaces
{
    public interface INewsletterRepository
    {
        void Cadastrar(NewsletterEmail newsletter);
        IEnumerable<NewsletterEmail> ObterTodasNewsletter();   
    }
}