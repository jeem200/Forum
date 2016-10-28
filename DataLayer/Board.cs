using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DataLayer
{
    public class Board
    {
        [Key]
        public int BoardId { get; set; }
        public string BoardTitle { get; set; }
        public List<Thread> thread { get; set; }
 
    }
}
