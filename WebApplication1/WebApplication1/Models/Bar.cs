using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    [Table("Bar")]
    public class Bar
    {
        [Key]
        public int BarId { get; set; }

        public String Name { get; set; }

        public String Address { get; set; }

        public String LogoPath { get; set; }

        public String Hours { get; set; }
    }
}