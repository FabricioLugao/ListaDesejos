using ListaDesejosAPI.Data;
using ListaDesejosAPI.Models;
using ListaDesejosAPI.Repository.IRepository;

namespace ListaDesejosAPI.Repository
{
    public class ListaDesejoRepository : Repository<ListaDesejo>, IListaDesejoRepository
    {
        public ListaDesejoRepository(ApplicationDBContext db) : base(db)
        {
        }
    }
}
