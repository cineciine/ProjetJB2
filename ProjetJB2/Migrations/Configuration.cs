namespace ProjetJB2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ProjetJB2.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjetJB2.Models.ProjetJB2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ProjetJB2.Models.ProjetJB2Context";
        }

        protected override void Seed(ProjetJB2.Models.ProjetJB2Context context)
        {
            var students = new List<Student>
            {
                new Student{ Id = 1, LastName = "IBN SALAH", FirstName = "Yacine", Login ="ISY", Password="ibnsalahyacine", Email="ibnsalah.yacine@osp.net" },
                new Student{ Id = 2, LastName = "GREY", FirstName = "Steven", Login = "GS", Password = "greysteven", Email = "grey.steven@osp.net" },
                new Student{ Id = 3, LastName = "HASSINI", FirstName = "Mohammed", Login = "HM", Password = "hassinimohammed", Email = "hassini.mohammed@osp.net" }
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var projects = new List<Project>
            {
                new Project{ Id = 1, Name ="Outil de Suivi de Projet", Description="Les élèves doivent développer une API Web permettant aux professeurs de suivre les projets de groupe."}
            };
            projects.ForEach(p => context.Projects.Add(p));
            context.SaveChanges();

            var Groups = new List<Group>
            {
            new Group{GroupId=1, NumGroup=1, ProjectId=1, StudentId=1,},
            };
            Groups.ForEach(s => context.Groups.Add(s));
            context.SaveChanges();
        }

    }
}
