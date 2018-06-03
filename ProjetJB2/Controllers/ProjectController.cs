using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetJB2.Models;

namespace ProjetJB2.Controllers
{
    public class ProjectController : Controller
    {
        private ProjetJB2Context db = new ProjetJB2Context();

        // GET: Project
       /*public async Task<ActionResult> Index()
       {
            var projects = db.Projects.Include(p => p.Teacher); ATTENTION EN ENLEVANT CE CODE (ERREURS FUTURES POSSIBLES GENEREES)
            return View(await projects.ToListAsync());
        }*/
         
        public ViewResult Index (String searchString)
        {
            var projects = from p in db.Projects
                           select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                projects = projects.Where(p => p.Name.Contains(searchString) || p.Description.Contains(searchString));
            }
            return View(projects.ToList());
        }

        // GET: Project/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = await db.Projects.FindAsync(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        /*[ChildActionOnly]
        [AllowAnonymous]
        public ActionResult Menu(string dropdownMenuTitle)
        {
            ViewBag.DropdownMenuTitle = dropdownMenuTitle;

            var projectsQuery = from d in db.Projects
                                  select d;
            return PartialView(projectsQuery);
        } */    

        // GET: Project/Create
        public ActionResult Create()
        {
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "LastName");
            return View();
        }

        //METHODE STACK OVERFLOW
        /*[HttpPost]
        public ActionResult Index()
        {
            var projectlist = db.Projects.Select(p => p.Id);
            var projects = db.Projects.Where(p => projectlist.Contains(p.Id));  //your method to fetch projectList
            ViewBag.ProjectList = projects;
            return View(); //View must be binded

        }*/

        /*private object GetProjectList()
        {
            throw new NotImplementedException();
        }*/

        // POST: Project/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,TeacherId,BeginDate,EndDate")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "LastName", project.TeacherId);
            return View(project);
        }
        

        // GET: Project/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = await db.Projects.FindAsync(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "LastName", project.TeacherId);
            return View(project);
        }
        
        // POST: Project/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,TeacherId,BeginDate,EndDate")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "LastName", project.TeacherId);
            return View(project);
        }

        //Methode de mouseclic event sur la dropliste avec en sortie l'url du projet selectionné : Project/Detail/Id
        /*public async Task<ActionResult> _Layout([Bind(Include = "Id,Name,Description,TeacherId,BeginDate,EndDate")] Project project)
        {
            ViewBag.TeacherId = new SelectList(db.Projects, "Id", "Name", project.Id);
            return RedirectToAction("Index/Details/"+project.Id);
        }*/
        //public virtual ActionResult MyAction()


        // GET: Project/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = await db.Projects.FindAsync(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Project project = await db.Projects.FindAsync(id);
            db.Projects.Remove(project);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
