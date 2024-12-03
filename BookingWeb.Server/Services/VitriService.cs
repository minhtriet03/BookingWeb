using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.Repositories;
using BookingWeb.Server.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Services
{
    public class VitriService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VitriService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Vitri>> GetAllVitri()
        {
            return await _unitOfWork.vitris.GetAllAsync();
        }

        public async Task<List<Vitri>> getByPage(int page)
        {
            return await _unitOfWork.vitris.GetByPageAsync(page, 10);
        }

        public async Task InitAsync()
        {
          
            if (await _unitOfWork.vitris.AnyAsync())
                return;

            var vitris = new List<Vitri>();

 
            for (int i = 1; i <= 17; i++)
            {
                vitris.Add(new Vitri { ViTri1 = $"A{i}", TrangThai = true });
            }


            for (int i = 1; i <= 17; i++)
            {
                vitris.Add(new Vitri { ViTri1 = $"B{i}", TrangThai = true });
            }

   
            await _unitOfWork.vitris.AddRangeAsync(vitris);

 
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

