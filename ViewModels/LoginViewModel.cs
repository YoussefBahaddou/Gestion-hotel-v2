//using Management_Hotel.Connection;
using Management_Hotel.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Management_Hotel.ViewModels
{
    public class LoginViewModel
    {
        private readonly HotelDbContext _context;

        public LoginViewModel()
        {
            _context = new HotelDbContext();
        }

        public (bool success, string role) ValidateLogin(string email, string password)
        {
            var user = _context.Utilisateurs.FirstOrDefault(u =>u.Email == email && u.Motdepasse == password);

            if (user != null)
            {
                return (true, user.Role);
            }
            return (false, null);
        }
    }
}
