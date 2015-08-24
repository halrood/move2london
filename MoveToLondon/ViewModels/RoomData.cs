using MoveToLondon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoveToLondon.Models
{
    public class RoomData
    {
        public List<Room> _rooms = null;
        public List<RoomPhoto> _roomPhotos = null;

        public RoomData()
        {
            _rooms = new List<Room>();
            
            _roomPhotos = new List<RoomPhoto>();
        }

        public List<Room> Rooms
        {
            get
            {
                return _rooms;
            }
            set
            {
                _rooms = value;
            }
        }
        public List<RoomPhoto> RoomPhotos
        {
            get
            {
                return _roomPhotos;
            }
            set
            {
                _roomPhotos = value;
            }
        }
    }
}