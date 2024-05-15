using ListaDesejosAPI.Data;
using ListaDesejosAPI.Models;
using ListaDesejosAPI.Repository.IRepository;

namespace ListaDesejosAPI.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDBContext db) : base(db)
        {
        }
    }
}
