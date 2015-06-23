using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveToLondon.Models
{
    public class RoomPhoto
    {
        [Key, ScaffoldColumn(false)]
        public int ID { get; set; }

        private string path;

        public string Path
        {
            get;
            set;
        }
    }
}
