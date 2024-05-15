using ListaDesejosAPI.Data;
using ListaDesejosAPI.Models;
using ListaDesejosAPI.Repository.IRepository;

namespace ListaDesejosAPI.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDBContext db) : base(db)
        {
        }
    }
}
