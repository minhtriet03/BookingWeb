using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.Repositories;
using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;

namespace BookingWeb.Server.Services
{
    public class BenxeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BenxeService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Benxe>> getAll()
        {
            return await _unitOfWork.benXes
                .GetAllAsync();
        }

        public async Task<List<Benxe>> getbyPage(int page)
        {
            return await _unitOfWork.benXes.GetByPageAsync(page, 10);
        }
        public async Task<Benxe> getByName(string name)
        {
            try
            {
                return await _unitOfWork.benXes.GetByName(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> addBenXe(Benxe benxe)
        {
            try
            {
                await _unitOfWork.benXes.AddAsync(benxe);
                return await _unitOfWork.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> updateBenxe(Benxe benxe)
        {
            try
            {
                _unitOfWork.benXes.UpdateAsync(benxe);
                return await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> deleteBenXe(int id)
        {
            try
            {
                await _unitOfWork.benXes.deleteBenxe(id);
                return await _unitOfWork.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
