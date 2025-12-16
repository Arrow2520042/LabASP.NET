using System.Collections.Generic;

namespace WebApplication1.Models
{
    public interface IReservationService
    {
        int Add(Reservation item);
        void Delete(int id);
        void Update(Reservation item);
        List<Reservation> FindAll();
        Reservation? FindById(int id);
        List<Reservation> FindPage(int pageNumber, int pageSize);
        int Count();
    }
}