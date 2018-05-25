using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetJB2.Models
{
    public class Project
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Nullable<int> TeacherId { get; set; } //Modifier seed
        public virtual Teacher Teacher { get; set; }
    }
}