using ListaDesejosAPI.Data;
using ListaDesejosAPI.Models;
using ListaDesejosAPI.Repository.IRepository;

namespace ListaDesejosAPI.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationDBContext db) : base(db)
        {
        }
    }
}
