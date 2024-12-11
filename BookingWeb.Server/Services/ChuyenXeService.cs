﻿using BookingWeb.Server.Dto;
using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.Repositories;
using BookingWeb.Server.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookingWeb.Server.Services
{
    public class ChuyenXeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChuyenXeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Chuyenxe>> GetAllChuyenXe()
        {
            try
            {
                var data = await _unitOfWork.chuyenXeRepository.GetAllChuyenXeVM();

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Chuyenxe>> GetAllChuyenXeByTuyenDuong(int TDId)
        {
            try
            {
                var data = await _unitOfWork.chuyenXeRepository.GetByConditionAsync(cx => cx.IdTuyenDuong == TDId);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ChuyenxeDetailDto>> GetAllChuyenXeByTinh(string noidi, string noiden, DateOnly date)
        {
            try
            {
                var data = await _unitOfWork.chuyenXeRepository.GetChuyenXeTheoTenTinhAsync(noidi, noiden, date);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ChuyenXeVM>> GetAllChuyenXeVM()
        {
            try
            {
                var data = await _unitOfWork.chuyenXeRepository.GetAllChuyenXeVM();
                var result = data.Select(cx => new ChuyenXeVM
                {
                    IdChuyenXe = cx.IdChuyenXe,
                    ThoiGianKh = cx.ThoiGianKh,
                    ThoiGianDen = cx.ThoiGianDen,
                    TrangThai = cx.TrangThai,
                    NgayKhoiHanh = cx.NgayKhoiHanh,
                    

                    XeVM = cx.IdXeNavigation == null
                        ? null
                        : new XeVM
                        {
                            BienSo = cx.IdXeNavigation?.BienSo,
                            TinhTrang = cx.IdXeNavigation.TinhTrang,

                            LoaiXeVM = cx.IdXeNavigation?.IdLoaiNavigation == null
                                ? null
                                : new LoaiXeVM
                                {
                                    TenLoai = cx.IdXeNavigation?.IdLoaiNavigation?.TenLoai,
                                    SoGhe = cx.IdXeNavigation?.IdLoaiNavigation?.SoGhe
                                }
                        },

                    TuyenDuongVM = cx.IdXeNavigation == null
                        ? null
                        : new TuyenDuongVM
                        {
                            TenBenXe = cx.IdTuyenDuongNavigation?.NoiKhoiHanhNavigation?.TenBenXe,
                            NoiDen = cx.IdTuyenDuongNavigation?.NoiDenNavigation?.IdTinhThanhNavigation?.TenTinhThanh,
                            NoiKhoiHanh = cx.IdTuyenDuongNavigation?.NoiKhoiHanhNavigation?.IdTinhThanhNavigation?.TenTinhThanh,
                            KhoangCach = cx.IdTuyenDuongNavigation?.KhoangCach,
                            GiaVe = cx.IdTuyenDuongNavigation?.GiaVe,
                            TenBenXeDen = cx.IdTuyenDuongNavigation?.NoiDenNavigation?.TenBenXe,
                            TenBenXeDi = cx.IdTuyenDuongNavigation?.NoiKhoiHanhNavigation?.TenBenXe
                        }
                });

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ChuyenXeVM>> GetBySearch(string search)
        {
            var data = await _unitOfWork.chuyenXeRepository.GetAllChuyenXeVM();

            var result = data.Select(cx => new ChuyenXeVM
            {
                IdChuyenXe = cx.IdChuyenXe,
                ThoiGianKh = cx.ThoiGianKh,
                ThoiGianDen = cx.ThoiGianDen,
                TrangThai = cx.TrangThai,
                NgayKhoiHanh = cx.NgayKhoiHanh,

                XeVM = cx.IdXeNavigation == null
                    ? null
                    : new XeVM
                    {
                        BienSo = cx.IdXeNavigation?.BienSo,
                        TinhTrang = cx.IdXeNavigation.TinhTrang,

                        LoaiXeVM = cx.IdXeNavigation?.IdLoaiNavigation == null
                            ? null
                            : new LoaiXeVM
                            {
                                TenLoai = cx.IdXeNavigation?.IdLoaiNavigation?.TenLoai,
                                SoGhe = cx.IdXeNavigation?.IdLoaiNavigation?.SoGhe
                            }
                    },

                TuyenDuongVM = cx.IdXeNavigation == null
                    ? null
                    : new TuyenDuongVM
                    {
                        TenBenXe = cx.IdTuyenDuongNavigation?.NoiKhoiHanhNavigation?.TenBenXe,
                        NoiDen = cx.IdTuyenDuongNavigation?.NoiDenNavigation?.IdTinhThanhNavigation?.TenTinhThanh,
                        NoiKhoiHanh = cx.IdTuyenDuongNavigation?.NoiKhoiHanhNavigation?.IdTinhThanhNavigation?.TenTinhThanh,
                        KhoangCach = cx.IdTuyenDuongNavigation?.KhoangCach,
                        GiaVe = cx.IdTuyenDuongNavigation?.GiaVe
                    }
            });

            if (!String.IsNullOrEmpty(search))
            {
                result = result.Where(cx => cx.XeVM.BienSo.Contains(search) || cx.XeVM.LoaiXeVM.TenLoai.Contains(search) || cx.TuyenDuongVM.NoiDen.Contains(search) || cx.TuyenDuongVM.NoiKhoiHanh.Contains(search) || cx.TuyenDuongVM.KhoangCach.ToString().Contains(search) || cx.TuyenDuongVM.GiaVe.ToString().Contains(search)
                );

                return result;
            }

            return result;
        }

        public async Task<Chuyenxe> GetChuyenXeByID(int id)
        {
            try
            {
                var data = await _unitOfWork.chuyenXeRepository.GetByIdAsync(id);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PagedList<ChuyenXeVM>> GetByPageAsync(int pageNumber, int pageSize)
        {

            /*var chuyenXe =await _unitOfWork.chuyenXeRepository.GetAllAsync();*/
            var skip = (pageNumber - 1) * pageSize;
            var totalRecords = await _unitOfWork.chuyenXeRepository.CountAsync();

            var chuyenXes = await _unitOfWork.chuyenXeRepository.GetPagedAsync(skip, pageSize);


            var data = chuyenXes.Select(cx => new ChuyenXeVM
            {
                IdChuyenXe = cx.IdChuyenXe,
                ThoiGianKh = cx.ThoiGianKh,
                ThoiGianDen = cx.ThoiGianDen,
                TrangThai = cx.TrangThai,
                NgayKhoiHanh = cx.NgayKhoiHanh,

                XeVM = cx.IdXeNavigation == null
                    ? null
                    : new XeVM
                    {
                        BienSo = cx.IdXeNavigation?.BienSo,
                        TinhTrang = cx.IdXeNavigation.TinhTrang,

                        LoaiXeVM = cx.IdXeNavigation.IdLoaiNavigation == null
                            ? null
                            : new LoaiXeVM
                            {
                                TenLoai = cx.IdXeNavigation.IdLoaiNavigation.TenLoai,
                                SoGhe = cx.IdXeNavigation.IdLoaiNavigation.SoGhe
                            }
                    },

                TuyenDuongVM = cx.IdXeNavigation == null
                    ? null
                    : new TuyenDuongVM
                    {
                        TenBenXe = cx.IdTuyenDuongNavigation?.NoiKhoiHanhNavigation?.TenBenXe,
                        NoiDen = cx.IdTuyenDuongNavigation?.NoiDenNavigation?.IdTinhThanhNavigation?.TenTinhThanh,
                        NoiKhoiHanh = cx.IdTuyenDuongNavigation?.NoiKhoiHanhNavigation?.IdTinhThanhNavigation?.TenTinhThanh,
                        KhoangCach = cx.IdTuyenDuongNavigation?.KhoangCach,
                        GiaVe = cx.IdTuyenDuongNavigation?.GiaVe
                    }
            }).ToList();



            return new PagedList<ChuyenXeVM>
            {
                Items = data,
                TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize),
                CurrentPage = pageNumber
            };

            /*return new PagedList<ChuyenXeVM>(data, pageNumber, (int)Math.Ceiling((double)totalRecords / pageSize));*/
        }

        public async Task<List<Chuyenxe>> GetChuyenXeTheoNgayLonNhat()
        {
            var data = await _unitOfWork.chuyenXeRepository.LayChuyenXeCoNgayLonNhat();

            if (data == null)
            {
                return null;
            }

            return data;
        }

        public async Task<List<ChuyenXeVM>> GetByTime( int idXe ,string startTIme, string endTime, int IdTuyenDuong, DateOnly date)
        {
            try
            {
                var chuyenXe = await _unitOfWork.chuyenXeRepository.GetChuyenXeByTime( idXe ,startTIme, endTime, IdTuyenDuong, date);
                if (chuyenXe == null)
                {
                    return null;
                }

                var data = chuyenXe.Select(cx => new ChuyenXeVM
                {
                    IdChuyenXe = cx.IdChuyenXe,
                    ThoiGianKh = cx.ThoiGianKh,
                    ThoiGianDen = cx.ThoiGianDen,
                    TrangThai = cx.TrangThai,
                    NgayKhoiHanh = cx.NgayKhoiHanh,
                    XeVM = cx.IdXeNavigation == null
                        ? null
                        : new XeVM
                        {
                            IdXe = cx.IdXeNavigation.IdXe,
                            BienSo = cx.IdXeNavigation.BienSo,
                            TinhTrang = cx.IdXeNavigation.TinhTrang
                        },
                }).ToList();

                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> AddChuyenXe(Chuyenxe chuyenxe)
        {
            try
            {
                await _unitOfWork.chuyenXeRepository.AddAsync(chuyenxe);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateChuyenXe(Chuyenxe chuyenxe)
        {
            try
            {
                await _unitOfWork.chuyenXeRepository.UpdateAsync(chuyenxe);
                return await _unitOfWork.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteChuyenXe(int id)
        {
            return await _unitOfWork.chuyenXeRepository.DeleteAsync(id);
        }

        //===================================TOANLD++++++++++++++++++++++++++++++++++
        public async Task<bool> AddChuyenXeTheoNgay()
        {
            var listChuyenXe = await _unitOfWork.chuyenXeRepository.LayChuyenXeCoNgayLonNhat();

            var listChuyenXeMoi = new List<Chuyenxe>();

            // Duyệt qua từng chuyến xe có ngày lớn nhất
            foreach (var chuyenXe in listChuyenXe)
            {
                for (int i = 1; i <= 7; i++)
                {
                    var chuyenXeMoi = new Chuyenxe
                    {
                        IdXe = chuyenXe.IdXe,
                        IdTuyenDuong = chuyenXe.IdTuyenDuong,
                        ThoiGianKh = chuyenXe.ThoiGianKh,
                        ThoiGianDen = chuyenXe.ThoiGianDen,
                        NgayKhoiHanh = chuyenXe.NgayKhoiHanh.AddDays(i),
                        TrangThai = chuyenXe.TrangThai
                    };

                    listChuyenXeMoi.Add(chuyenXeMoi);
                }
            }

            try
            {
                await _unitOfWork.chuyenXeRepository.AddRangeAsync(listChuyenXeMoi);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần
                // _logger.LogError(ex, "Lỗi khi thêm chuyến xe");
                return false;
            }
        }
        public async Task<bool> DeactivateChuyenXe(int id)
        {
            var data = await _unitOfWork.chuyenXeRepository.GetByIdAsync(id);
            
            var result = await _unitOfWork.chuyenXeRepository.DeactivateAsync(
                id,
                cx => cx.TrangThai == false || cx.TrangThai == true,
                cx => cx.TrangThai = !cx.TrangThai
            );
        
            await  _unitOfWork.SaveChangesAsync();

            return result;
        }
        

    }
}
