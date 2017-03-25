using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string SubscribedDate { get; set; }
    }
}
