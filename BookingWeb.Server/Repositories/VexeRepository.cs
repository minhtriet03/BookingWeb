using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;

namespace BookingWeb.Server.Repositories
{
    public class VexeRepository : GenericRepository<Vexe>,IVexeRepository
    {
        private IVitriRepository _vitriRepository;

        public VexeRepository(BookingBusContext dbContext) : base(dbContext)
        {

        }
    }
}
