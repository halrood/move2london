using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveToLondon.Models
{
    public class Room
    {
        [Key, ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //private string title;

        public string Title
        {
            get;
            set;
        }

        //private ICollection<RoomPhoto> listRoomPhoto;

        public virtual ICollection<RoomPhoto> ListRoomPhoto
        {
            get;
            set;
        }
        //public List<string> Photos
        //{
        //    get;
        //    set;
        //}

        //private string roomType;    //: Double Room / Single Room

        public string RoomType
        {
            get;
            set;
        }

        //private string availabilityStatus;

        public string AvailabilityStatus
        {
            get;
            set;
        }

        //private int rentPerMonth;

        public int RentPerMonth
        {
            get;
            set;
        }

        //private int bookingFee;

        public int BookingFee
        {
            get;
            set;
        }

        //private string address;

        public string Address
        {
            get;
            set;
        }

        //private string description;

        public string Description
        {
            get;
            set;
        }
    }
}