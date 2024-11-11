using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;

namespace BookingWeb.Server.Services
{
    public class AccountService
    {

        private readonly BookingBusContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;

        public AccountService(BookingBusContext context, IUnitOfWork unitOfWork, IAccountRepository accountRepository)
        {
            _context = context;
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }
    }
}
