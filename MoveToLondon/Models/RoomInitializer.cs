using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveToLondon.Models
{
    public class RoomInitializer : CreateDatabaseIfNotExists<RoomContext>
    {
        public RoomInitializer()
        {

        }

        protected override void Seed(RoomContext context)
        {
            List<Room> rooms = GetRooms();
            context.Rooms.AddRange(rooms);
            context.SaveChanges();
        }

        private List<Room> GetRooms()
        {
            //List<RoomPhoto> room1Photos = new List<RoomPhoto> { new RoomPhoto() { Path = string.Empty } };
            //List<RoomPhoto> room2Photos = new List<RoomPhoto> { new RoomPhoto() { Path = string.Empty } };
            //List<RoomPhoto> room3Photos = new List<RoomPhoto> { new RoomPhoto() { Path = string.Empty } };

            Room r1 = new Room { Address = "", AvailabilityStatus = "Available", BookingFee = 175, Description = "abcd", RentPerMonth = 30, RoomType = "Double", Title = "abcd", Photos = null };
            Room r2 = new Room { Address = "", AvailabilityStatus = "Available", BookingFee = 165, Description = "abcd", RentPerMonth = 30, RoomType = "Double", Title = "abcd", Photos = null };
            Room r3 = new Room { Address = "", AvailabilityStatus = "Available", BookingFee = 155, Description = "abcd", RentPerMonth = 30, RoomType = "Double", Title = "abcd", Photos = null };
            var rooms = new List<Room> { r1, r2, r3 };

            return rooms;
        }
    }
}
