using Management_Hotel.Models;
using System.Windows;
using System.Windows.Controls;

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
            TelephoneTextBox.Text = Employee.Telephone;
            RoleComboBox.SelectedItem = RoleComboBox.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString().ToLower() == Employee.Role.ToLower());
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NomTextBox.Text) || string.IsNullOrWhiteSpace(EmailTextBox.Text) || string.IsNullOrWhiteSpace(TelephoneTextBox.Text) || string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires", "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(NomTextBox.Text) || string.IsNullOrWhiteSpace(EmailTextBox.Text) || string.IsNullOrWhiteSpace(TelephoneTextBox.Text) || string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires", "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!IsEditMode)
                Employee = new Utilisateur();

            Employee.Nom = NomTextBox.Text;
            Employee.Prenom = PrenomTextBox.Text;
            Employee.Email = EmailTextBox.Text;
            Employee.Telephone = TelephoneTextBox.Text;
            Employee.Role = ((ComboBoxItem)RoleComboBox.SelectedItem).Content.ToString().ToLower();
            Employee.Motdepasse = PasswordBox.Password;

            DialogResult = true;
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
