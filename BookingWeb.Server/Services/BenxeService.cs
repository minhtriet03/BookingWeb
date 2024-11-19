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
                return await _unitOfWork.benXes.AddAsync(benxe);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
