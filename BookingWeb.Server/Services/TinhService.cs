﻿using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.Repositories;

namespace BookingWeb.Server.Services
{
    public class TinhService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TinhService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Tinhthanh> GetByName(string name)
        {
            return await _unitOfWork.tinhs.GetbyNameAsync(name);
        }
        public async Task<List<Tinhthanh>> getAll()
        {
            return await _unitOfWork.tinhs.GetAllAsync();
        }

        public async Task<Tinhthanh> getbyId(int id)
        {
            return await _unitOfWork.tinhs.GetByIdAsync(id);
        }

        public async Task<bool> addTinhThanh(Tinhthanh tinhthanh)
        {
            return await _unitOfWork.tinhs.AddAsync(tinhthanh);
        }
        public async Task<bool> updateTinh(Tinhthanh tinhthanh)
        {
            try
            {
                await _unitOfWork.tinhs.UpdateAsync(tinhthanh);
                if(await _unitOfWork.SaveChangesAsync() == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> deleteTinh(int id)
        {
            try
            {
                return await _unitOfWork.tinhs.deleteTinh(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}