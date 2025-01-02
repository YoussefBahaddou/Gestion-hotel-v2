using System.Windows;
using System.Windows.Controls;
using Management_Hotel.ViewModels;
using Management_Hotel.Views.Dialogs;
using Management_Hotel.Models;

namespace Management_Hotel.Views
{
    public partial class RoomTypeManagementView : UserControl
    {
        private readonly RoomTypeViewModel _viewModel;

        public RoomTypeManagementView()
        {
            InitializeComponent();
            _viewModel = new RoomTypeViewModel();
            LoadRoomTypes();
        }

        private void LoadRoomTypes()
        {
            RoomTypesGrid.ItemsSource = _viewModel.RoomTypes;
        }

        private void AddRoomType_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddEditRoomTypeDialog();
            if (dialog.ShowDialog() == true)
            {
                var result = _viewModel.AddRoomType(dialog.GetRoomType());
                if (result)
                {
                    MessageBox.Show("Type de chambre ajouté avec succès!", "Succès",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadRoomTypes();
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'ajout du type de chambre", "Erreur",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void EditRoomType_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Typechambre roomType)
            {
                var dialog = new AddEditRoomTypeDialog();
                dialog.SetRoomType(roomType);
                if (dialog.ShowDialog() == true)
                {
                    var updatedRoomType = dialog.GetRoomType();
                    _viewModel.UpdateRoomType(updatedRoomType);
                    LoadRoomTypes();
                }
            }
        }

        private void DeleteRoomType_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Typechambre roomType)
            {
                var result = MessageBox.Show(
                    "Êtes-vous sûr de vouloir supprimer ce type de chambre ?",
                    "Confirmation",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.DeleteRoomType(roomType.Idtype);
                    LoadRoomTypes();
                }
            }
        }
    }
}
