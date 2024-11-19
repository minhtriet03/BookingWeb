using BookingWeb.Server.Models;
using BookingWeb.Server.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Services
{
    public class VexeService
    {
        private readonly UnitOfWork _unitOfWork;

        public VexeService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Vexe>> getAll()
        {
            return await _unitOfWork.vexes.GetAllAsync();
        }
        public async Task<bool> addVeXe(Vexe vexe)
        {
            return await _unitOfWork.vexes.AddAsync(vexe);
        }
    }
}
