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
        public bool Insert(Hotel hotel)
        {
            return new HotelService().Insert(hotel);
        }

        public List<Hotel> GetHoteis()
        {
            return new HotelService().GetHoteis();
        }
    }
}
