//using Management_Hotel.Connection;
using Management_Hotel.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace Management_Hotel.ViewModels
{
    public class RoomTypeViewModel
    {
        private readonly HotelDbContext _context;
        public ObservableCollection<Typechambre> RoomTypes { get; set; }

        public RoomTypeViewModel()
        {
            _context = new HotelDbContext();
            LoadRoomTypes();
        }

        private void LoadRoomTypes()
        {
            var types = _context.Typechambres.ToList();
            RoomTypes = new ObservableCollection<Typechambre>(types);
        }

        public void AddRoomType(Typechambre roomType)
        {
            _context.Typechambres.Add(roomType);
            _context.SaveChanges();
            RoomTypes.Add(roomType);
        }

        public void UpdateRoomType(Typechambre roomType)
        {
            _context.Typechambres.Update(roomType);
            _context.SaveChanges();
            LoadRoomTypes();
        }

        public void DeleteRoomType(int typeId)
        {
            var roomType = _context.Typechambres.Find(typeId);
            if (roomType != null)
            {
                _context.Typechambres.Remove(roomType);
                _context.SaveChanges();
                RoomTypes.Remove(roomType);
            }
        }
    }
}
