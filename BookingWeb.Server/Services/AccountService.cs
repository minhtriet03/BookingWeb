using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;
using BookingWeb.Server.ViewModels;

namespace BookingWeb.Server.Services
{
    public class AccountService
    {

        private readonly BookingBusContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(BookingBusContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> addAccount(Taikhoan account)
        {
            try
            {
                if (string.IsNullOrEmpty(account.UserName))
                    throw new ArgumentException("Username không được để trống");

                if (string.IsNullOrEmpty(account.Password))
                    throw new ArgumentException("Password không được để trống");

                bool isExistUsername = await _unitOfWork.accountRepository.IsUsernameExist(account.UserName);

                if (isExistUsername)
                    throw new InvalidOperationException("Username đã tồn tại");

                await _unitOfWork.accountRepository.AddAsync(account);
                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> deleteAccount(int id)
        {
            try
            {
                bool isExist = await _unitOfWork.accountRepository.IsAccountExist(id);

                if (!isExist)
                    throw new InvalidOperationException("Tài khoản không tồn tại");

                await _unitOfWork.accountRepository.DeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> updateAccount(Taikhoan account)
        {
            try
            {
                bool isExist = await _unitOfWork.accountRepository.IsAccountExist(account.IdAccount);

                if (!isExist)
                    throw new InvalidOperationException("Tài khoản không tồn tại");

                await _unitOfWork.accountRepository.UpdateAsync(account);
                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Taikhoan> getAccountByUsername(string username)
        {
            try
            {
                return await _unitOfWork.accountRepository.GetByUsername(username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> IsUsernameExist(string username)
        {
            try
            {
                return await _unitOfWork.accountRepository.IsUsernameExist(username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> IsAccountExist(int id)
        {
            try
            {
                return await _unitOfWork.accountRepository.IsAccountExist(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Register(Taikhoan user)
        {
            try
            {
                return await _unitOfWork.accountRepository.Register(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Login(string userName, string password)
        {
            try
            {
                return await _unitOfWork.accountRepository.Login(userName, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdatePassword(int id, string oldPassword, string newPassword)
        {
            try
            {
                return await _unitOfWork.accountRepository.UpdatePassword(id, oldPassword, newPassword);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public async Task<PagedList<TaiKhoanVM>> GetByPageAsync(int pageNumber, int pageSize)
        {
            var skip = (pageNumber - 1) * pageSize;
            var totalRecords = await _unitOfWork.accountRepository.CountAsync();
            
            var accounts = await _unitOfWork.accountRepository.GetByPageAsync(skip, pageSize);

            var data = accounts.Select(tk => new TaiKhoanVM
            {
                IdAccount = tk.IdAccount,
                UserName = tk.UserName,
                TrangThai = tk.TrangThai
            }).ToList();

            return new PagedList<TaiKhoanVM>
            {
                Items = data,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling((double)totalRecords/pageSize)
            };
        }
        public async Task<bool> DeactivateAsync(int id)
        {
            try
            {
                var tk = await _unitOfWork.accountRepository.GetByIdAsync(id);
                if (tk == null)
                {
                    throw new InvalidOperationException("Id không tồn tại");
                }

                tk.TrangThai = !tk.TrangThai;

                await _unitOfWork.accountRepository.UpdateAsync(tk);
                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
