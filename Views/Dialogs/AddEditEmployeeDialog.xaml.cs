using Management_Hotel.Models;
using System.Windows;

namespace Management_Hotel.Views.Dialogs
{
    public partial class AddEditEmployeeDialog : Window
    {
        public Utilisateur Employee { get; private set; }
        private bool IsEditMode;

        public AddEditEmployeeDialog(Utilisateur employee = null)
        {
            InitializeComponent();
            IsEditMode = employee != null;

            if (IsEditMode)
            {
                Employee = employee;
                LoadEmployeeData();
            }
        }

        private void LoadEmployeeData()
        {
            NomTextBox.Text = Employee.Nom;
            PrenomTextBox.Text = Employee.Prenom;
            EmailTextBox.Text = Employee.Email;
            //TelephoneTextBox.Text = Employee.Telephone;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsEditMode)
                Employee = new Utilisateur();

            Employee.Nom = NomTextBox.Text;
            Employee.Prenom = PrenomTextBox.Text;
            Employee.Email = EmailTextBox.Text;
            //Employee.Telephone = TelephoneTextBox.Text;
            Employee.Role = "employee";

            if (!string.IsNullOrEmpty(PasswordBox.Password))
                Employee.Motdepasse = PasswordBox.Password;

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
