using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Models
{
    public class ReservationService : IReservationService
    {
        private Dictionary<int, Reservation> _reservations;
        private int _nextId = 1;

        public ReservationService()
        {
            _reservations = new Dictionary<int, Reservation>();
            
            Add(new Reservation { City = "Kraków", Address = "Wysłouchów 12", RoomName = "Apartament Królewski", Owner = "Nowak", Price = 500, Date = System.DateTime.Now.AddDays(5) });
            Add(new Reservation { City = "Miechów", Address = "Polna 44", RoomName = "22", Owner = "Kowalski", Price = 1111, Date = System.DateTime.Now.AddDays(10) });
        }

        public int Add(Reservation item)
        {
            item.Id = _nextId++;
            _reservations.Add(item.Id, item);
            return item.Id;
        }

        public void Delete(int id)
        {
            if (_reservations.ContainsKey(id))
            {
                _reservations.Remove(id);
            }
        }

        public void Update(Reservation item)
        {
            if (_reservations.ContainsKey(item.Id))
            {
                _reservations[item.Id] = item;
            }
        }

        public List<Reservation> FindAll()
        {
            return _reservations.Values.ToList();
        }

        public List<Reservation> FindPage(int pageNumber, int pageSize)
        {
            return _reservations.Values
                .OrderBy(r => r.Date)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int Count()
        {
            return _reservations.Count;
        }

        public Reservation? FindById(int id)
        {
            return _reservations.ContainsKey(id) ? _reservations[id] : null;
        }
    }
}