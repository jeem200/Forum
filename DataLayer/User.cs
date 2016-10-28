using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;
namespace DataLayer
{
    public class User
    {
        [Key]
        public int userID { get; set; }
        public string userName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string userType { get; set; }
        [DefaultValue(0)]
        public int like_recieved { get; set; }
        
    }
}
