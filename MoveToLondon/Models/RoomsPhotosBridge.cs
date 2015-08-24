namespace MoveToLondon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoomsPhotosBridge")]
    public partial class RoomsPhotosBridge
    {
        public int RoomId { get; set; }

        public int PhotoId { get; set; }

        public int Id { get; set; }

        public virtual RoomPhoto RoomPhoto { get; set; }

        public virtual Room Room { get; set; }
    }
}
