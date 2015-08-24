using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveToLondon.Models
{
//    public class RoomInitializer : DropCreateDatabaseIfModelChanges<RoomContext>
//    {
//        public RoomInitializer()
//        {

//        }

//        protected override void Seed(RoomContext context)
//        {
//            List<Room> rooms = GetRooms();
//            context.Rooms.AddRange(rooms);
//            context.SaveChanges();
//        }

//        private List<Room> GetRooms()
//        {
//            List<RoomPhoto> room1Photos = new List<RoomPhoto> { new RoomPhoto() { Path = @"/Assets/Room1Image1.jpg" },
//                new RoomPhoto() {Path = @"/Assets/Room1Image2.jpg"},
//                new RoomPhoto() {Path = @"/Assets/Room1Image3.jpg"}};
//            List<RoomPhoto> room2Photos = new List<RoomPhoto> { new RoomPhoto() {Path = @"/Assets/Room2Image1.jpg" },
//                new RoomPhoto() {Path = @"/Assets/Room2Image2.jpg"},
//                new RoomPhoto() {Path = @"/Assets/Room2Image3.jpg"}};
//            List<RoomPhoto> room3Photos = new List<RoomPhoto> { new RoomPhoto() { Path = @"/Assets/Room3Image1.jpg" },
//                new RoomPhoto() {Path = @"/Assets/Room3Image2.jpg"},
//                new RoomPhoto() {Path = @"/Assets/Room3Image3.jpg"}};

//            #region Descriptions

//            string Room1_Description = @"Bright and lovely room with a lot of storages available for couple.
//                                        In the room, there are a double bed, a desk, a big wardrobe, 2 shelves, 
//                                        2 chest of drawers and a fridge.
//                                        2 Bathrooms
// 
// 
//                                        5 min walk away from Stoke Newington station 
//                                        (Rail train, zone 2)
//                                        5 min by bus from Manor House station
//                                        (Piccadilly line, zone 2)
// 
//                                        Deposit : £750 (£30 Check out fee) 
//                                        Bills included (cleaning included) - except gas and electricity
//                                        Ask us before booking";

//            string Room2_Description = @"(Couples allowed, £140/week)
// 
//                                        Double bed, wardrobe, desk, bathroom, 2 toilets. 
//                                        Lovely flatshare with young professionals.
//                                        Bills included (council tax, water and internet). 
//                                        Gas and electricity aprox £20 per month
// 
//                                        5 minutes walk away from Seven Sisters station
//                                        (zone 3, Victoria Line)
//                                        15 minutes from d'Oxford Circus by metro
//                                        Good connections by public transports
// 
//                                        Ask us before booking";

//            string Room3_Description = @"Double room well situated at Essex Road (zone 1), available for one person only.
//                                        The lighting bedroom has a double bed, a big wardrobe and a desk.
// 
//                                        Houseshare with fully equiped kitchen, a louge / dining room and a bathroom
//                                        All bills included
// 
//                                        Near to the Angel station (Northern line, zone 1)
// 
//                                        Ask us before booking";

//            #endregion Descriptions

//            Room r1 = new Room { Address = "OLDHILL STREET N16 6NA- LONDON", AvailabilityStatus = "Available", BookingFee = 150, Description = Room1_Description, RentPerMonth = 700, RoomType = "Double", Title = "Double Room", ListRoomPhoto = room1Photos };
//            Room r2 = new Room { Address = "SEVEN SISTERS N15 5HP - LONDON", AvailabilityStatus = "Available", BookingFee = 150, Description = Room2_Description, RentPerMonth = 130, RoomType = "Double", Title = "Double Room", ListRoomPhoto = room2Photos };
//            Room r3 = new Room { Address = "ESSEX ROAD N1 2FX- LONDON", AvailabilityStatus = "Available", BookingFee = 150, Description = Room3_Description, RentPerMonth = 175, RoomType = "Double", Title = "Double Room", ListRoomPhoto = room3Photos };
//            var rooms = new List<Room> { r1, r2, r3 };

//            return rooms;
//        }
//    }
}
