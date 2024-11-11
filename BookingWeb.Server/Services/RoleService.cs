using BookingWeb.Server.Interfaces;
using BookingWeb.Server.Models;

namespace BookingWeb.Server.Services
{
    public class RoleService
    {

        private readonly BookingBusContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleRepository _roleRepository;

        public RoleService(BookingBusContext context, IUnitOfWork unitOfWork, IRoleRepository roleRepository)
        {
            _context = context;
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }
    }
}
