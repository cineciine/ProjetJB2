using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetJB2.Models
{
    public class ProjetJB2Context : DbContext
    {
        public ProjetJB2Context() : base("name=ProjetJB2Context")
        {
        }

        public System.Data.Entity.DbSet<ProjetJB2.Models.Student> Students { get; set; }
        public System.Data.Entity.DbSet<ProjetJB2.Models.Project> Projects { get; set; }
        public System.Data.Entity.DbSet<ProjetJB2.Models.Teacher> Teachers { get; set; }
        public System.Data.Entity.DbSet<ProjetJB2.Models.Task> Tasks { get; set; }
        public System.Data.Entity.DbSet<ProjetJB2.Models.Step> Steps { get; set; }
        public System.Data.Entity.DbSet<ProjetJB2.Models.Group> Groups { get; set; }
    }
}
