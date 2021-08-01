using System.Threading.Tasks;
using ProEventos.Persistence.Contratos;
using ProEventos.Persistence.Contexto;

namespace ProEventos.Persistence.Services
{
    public class GeralPersist : IGeralPersist
    {
        private readonly ProEventosContext _geralContext;
        public GeralPersist(ProEventosContext geralContext)
        {
            _geralContext = geralContext;

        }
        public void Add<T>(T entity) where T : class
        {
            _geralContext.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _geralContext.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _geralContext.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _geralContext.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _geralContext.SaveChangesAsync()) > 0;
        }
    }
}