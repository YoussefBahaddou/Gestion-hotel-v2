//using Management_Hotel.Connection;
using Management_Hotel.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace Management_Hotel.ViewModels
{
    public class EmployeeViewModel
    {
        private readonly HotelDbContext _context;
        public ObservableCollection<Utilisateur> Employees { get; set; }

        public EmployeeViewModel()
        {
            _context = new HotelDbContext();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            var employees = _context.Utilisateurs.ToList();
            Employees = new ObservableCollection<Utilisateur>(employees);
        }

        //This is the method that shows only the Employee in the table in the "Gestion des employee"
        /*
        private void LoadEmployees()
        {
            var employees = _context.Utilisateurs
                .Where(u => u.Role.ToLower() == "employee")
                .ToList();
            Employees = new ObservableCollection<Utilisateur>(employees);
        }
        */
        public bool AddEmployee(Utilisateur employee)
        {
            try
            {
                _context.Utilisateurs.Add(employee);
                _context.SaveChanges();
                Employees.Add(employee);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void UpdateEmployee(Utilisateur employee)
        {
            _context.Utilisateurs.Update(employee);
            _context.SaveChanges();
            LoadEmployees();
        }

        public void DeleteEmployee(int employeeId)
        {
            var employee = _context.Utilisateurs.Find(employeeId);
            if (employee != null)
            {
                _context.Utilisateurs.Remove(employee);
                _context.SaveChanges();
                Employees.Remove(employee);
            }
        }
    }
}
