namespace MoveToLondon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            RoomsPhotosBridges = new HashSet<RoomsPhotosBridge>();
        }

        public int ID { get; set; }

        public string Title { get; set; }

        public string RoomType { get; set; }

        public string AvailabilityStatus { get; set; }

        public int RentPerMonth { get; set; }

        public int BookingFee { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public bool IsFrench { get; set; }

        public int RoomSequence { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoomsPhotosBridge> RoomsPhotosBridges { get; set; }
    }
}
