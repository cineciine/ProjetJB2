using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetJB2.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public int NumGroup { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public Nullable<int> StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}