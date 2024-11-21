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

        public async Task<List<Vitri>> GetByIdXe(int idXe)
        {
            try
            {
                return await _unitOfWork.vitris.getByIdXe(idXe);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<Vitri> listvitri(int idxe)
        //{
        //    List<Vitri> vitris = new List<Vitri>();
        //    for (int i = 0; i < 17; i++)
        //    {
        //        Vitri vt = new Vitri();
                
        //    }
        //}

        //public async Task<bool> addVitriGhe(int idxe)
        //{
        //    try
        //    {
                
        //    }

        //}
    }
}
