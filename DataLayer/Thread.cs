using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Data.Entity;
namespace DataLayer
{
    public class Thread
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public List<Post> post { get; set; }
        public int BoardId { get; set; }
        public string startpost { get; set; }
        public string status { get; set; }
        [ForeignKey("BoardId")]
        public Board board { get; set; }

    }
}
