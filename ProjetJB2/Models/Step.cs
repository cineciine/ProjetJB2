using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetJB2.Models
{
    public class Step
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}