using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services;

namespace Controllers
{
    public class HotelController
    {
        private readonly HotelService _hotelService;

        public HotelController()
        {
            _hotelService = new();
        }

        public bool Insert(Hotel hotel)
        {
            return _hotelService.Insert(hotel);
        }

        public List<Hotel> GetHoteis()
        {
            return _hotelService.GetHoteis();
        }
    }
}
