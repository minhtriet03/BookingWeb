using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Repositories
{
    public class TuyenDuongRepository : GenericRepository<Tuyenduong>, ITuyenDuongRepository
    {
        public TuyenDuongRepository(BookingBusContext dbContext) : base(dbContext)
        {
        }
    }
}
