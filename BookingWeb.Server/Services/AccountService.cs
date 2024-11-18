using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;

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




    }
}
