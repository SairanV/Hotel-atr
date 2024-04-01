using Hotel_atr.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_atr
{
    public class HotelAtrContext : DbContext
    {
        public HotelAtrContext
            (DbContextOptions<HotelAtrContext> options) 
            :base(options)
        {

        }

        public DbSet<Room> Rooms { get; set; }
    }
}
