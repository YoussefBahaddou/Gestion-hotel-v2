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
                var newRoomType = dialog.GetRoomType();
                _viewModel.AddRoomType(newRoomType);
                LoadRoomTypes();
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
