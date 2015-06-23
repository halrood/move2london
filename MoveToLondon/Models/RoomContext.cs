using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveToLondon.Models
{
    public class RoomContext : DbContext
    {
        public RoomContext()
            : base("MoveToLondon")
        {

        }

        public DbSet<Room> Rooms { get; set; }
        //public DbSet<RoomPhoto> RoomPhotos { get; set; }
    }
}
