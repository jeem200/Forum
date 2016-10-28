using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;
namespace DataLayer
{
    public class Post
    {
        [Key]
        public int postId { get; set; }
        public string description { get; set; }
        public string postType { get; set; }
        public int ThreadID { get; set; }
        public DateTime postedAt { get; set; }
        public int postedBy { get; set; }
        public int repliedTo{get;set;}
        [ForeignKey("ThreadID")]
        public Thread Thread { get; set; }
        [DefaultValue(0)]
        public int like_count { get; set; }


    }
}
