using System;


namespace ProjetJB2.Models
{
    public class Project
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Nullable<int> TeacherId { get; set; } 
        public virtual Teacher Teacher { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
}
}