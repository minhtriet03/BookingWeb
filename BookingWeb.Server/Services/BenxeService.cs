using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.Repositories;
using BookingWeb.Server.ViewModels;
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

        public async Task<Benxe> GetById(int id)
        {
            try
            {
                var benXe = await _unitOfWork.benXes.GetByIdAsync(id);
                if (benXe == null)
                {
                    return null;
                }

                return benXe;
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
                await _unitOfWork.SaveChangesAsync();
                return true;
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
                return await _unitOfWork.benXes.deleteBenxe(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<BenXeVM>> GetBenXeByTinhThanhAsync(int idTinhThanh)
        {
            try
            {
                var data = await _unitOfWork.benXes.GetByConditionAsync(bx => bx.IdTinhThanh == idTinhThanh && bx.TrangThai == true);
                
                if (data == null)
                {
                    return null;
                }

                var bxVM = data.Select(bx => new BenXeVM
                {
                    IdBenXe = bx.IdBenXe,
                    IdTinhThanh = bx.IdTinhThanh,
                    TenBenXe = bx.TenBenXe,
                    TrangThai = bx.TrangThai
                }).ToList();
                
                return  bxVM;
            }
            catch (Exception ex)
            {
                return new List<BenXeVM>();
            }
        }
        public async Task<PagedList<BenXeVM>> GetByPageAsync(int pageNumber, int pageSize)
        {
            
            Console.WriteLine("pageNumber: " + pageNumber);
            Console.WriteLine("pageSize: " + pageSize);
            
            var skip = (pageNumber - 1) * pageSize;
            
            var totalRecords = await _unitOfWork.benXes.CountAsync();
            
            var benXes = await _unitOfWork.benXes.GetByPageAsync(skip, pageSize);
            
            var data = benXes.Select(bx => new BenXeVM
            {
                IdBenXe = bx.IdBenXe,
                IdTinhThanh = bx.IdTinhThanh,
                TenBenXe = bx.TenBenXe,
                TrangThai = bx.TrangThai,
                TinhThanhVM = bx.IdTinhThanhNavigation == null ? null : new TinhThanhVM
                {
                    IdTinhThanh = bx.IdTinhThanhNavigation.IdTinhThanh,
                    TenTinhThanh = bx.IdTinhThanhNavigation.TenTinhThanh,
                    TrangThai = bx.IdTinhThanhNavigation.TrangThai
                }
            }).ToList();

            return new PagedList<BenXeVM>
            {
                Items = data,
                TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize),
                CurrentPage = pageNumber
            };
        }
        
        public async Task<bool> DeactivateBenXeAsync(int id)
        {
            var data = await _unitOfWork.benXes.GetByIdAsync(id);
            
            var result = await _unitOfWork.benXes.DeactivateAsync(
                id,
                bx => bx.TrangThai == false || bx.TrangThai == true,
                bx => bx.TrangThai = !bx.TrangThai
            );
        
            await  _unitOfWork.SaveChangesAsync();

            return result;
        }
    }
}
