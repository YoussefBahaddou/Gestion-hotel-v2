using Management_Hotel.Models;
using Management_Hotel.ViewModels;
using Management_Hotel.Views.Dialogs;
using System.Windows;
using System.Windows.Controls;

namespace Management_Hotel.Views
{
    public partial class EmployeeManagementView : UserControl
    {
        private readonly EmployeeViewModel _viewModel;

        public EmployeeManagementView()
        {
            InitializeComponent();
            _viewModel = new EmployeeViewModel();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            EmployeesGrid.ItemsSource = _viewModel.Employees;
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddEditEmployeeDialog();
            if (dialog.ShowDialog() == true)
            {
                _viewModel.AddEmployee(dialog.Employee);
                LoadEmployees();
            }
        }

        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Utilisateur employee)
            {
                var dialog = new AddEditEmployeeDialog(employee);
                if (dialog.ShowDialog() == true)
                {
                    _viewModel.UpdateEmployee(dialog.Employee);
                    LoadEmployees();
                }
            }
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Utilisateur employee)
            {
                var result = MessageBox.Show(
                    "Êtes-vous sûr de vouloir supprimer cet employé ?",
                    "Confirmation",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.DeleteEmployee(employee.Idutilisateur);
                    LoadEmployees();
                }
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadEmployees();
        }
    }
}
