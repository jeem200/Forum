using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Like
    {
        public int id { get; set; }
        public int post_liked { get; set; }
        public int liked_by { get; set; }
    }
}
