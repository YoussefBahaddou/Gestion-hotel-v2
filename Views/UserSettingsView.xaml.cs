using Management_Hotel.Models;
using System.Windows;

namespace Management_Hotel.Views
{
    public partial class UserSettingsView : Window
    {
        private Utilisateur _currentUser;

        public UserSettingsView(Utilisateur user)
        {
            InitializeComponent();
            _currentUser = user;
            LoadUserData();
        }

        private void LoadUserData()
        {
            NomTextBox.Text = _currentUser.Nom;
            EmailTextBox.Text = _currentUser.Email;
            TelephoneTextBox.Text = _currentUser.Telephone;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidatePasswordChange())
            {
                _currentUser.Nom = NomTextBox.Text;
                _currentUser.Email = EmailTextBox.Text;
                _currentUser.Telephone = TelephoneTextBox.Text;

                if (!string.IsNullOrEmpty(NewPasswordBox.Password))
                {
                    _currentUser.Motdepasse = NewPasswordBox.Password;
                }

                DialogResult = true;
            }
        }

        private bool ValidatePasswordChange()
        {
            if (!string.IsNullOrEmpty(NewPasswordBox.Password))
            {
                if (NewPasswordBox.Password != ConfirmPasswordBox.Password)
                {
                    MessageBox.Show("Les mots de passe ne correspondent pas.");
                    return false;
                }
            }
            return true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
