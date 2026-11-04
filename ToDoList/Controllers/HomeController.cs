using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private TicketContext context;
        public HomeController(TicketContext ctx) => context = ctx;

        public IActionResult Index(string id)
        {
            var filters = new Filters(id);

            ViewBag.Filters = filters;
            ViewBag.Statuses = context.Statuses.ToList();            

            IQueryable<Ticket> query = context.Tickets
                .Include(t => t.Status); 
            
            if (filters.HasStatus)
            {
                //query.AsQueryable().Where(t => t.Status.StatusId == filters.StatusId);
                query = query.Where(t => t.Status.StatusId == filters.StatusId);
            }
            
            var tickets = query.OrderBy(t => t.Name).ToList();
            return View(tickets);
        }

        [HttpGet]
        public IActionResult Add()
        {            
            ViewBag.Statuses = context.Statuses.ToList();
            var ticket = new Ticket { StatusId = "todo" };
            return View(ticket);
        }

        [HttpPost]
        public IActionResult Add(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                context.Tickets.Add(ticket);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {                
                ViewBag.Statuses = context.Statuses.ToList();
                return View(ticket);
            }
        }

        [HttpPost]
        public IActionResult Filter(string filter)
        {            
            return RedirectToAction("Index", new { id = filter});
        }

        [HttpPost]
        public IActionResult MarkDone([FromRoute] string id, Ticket selected)
        {
            selected = context.Tickets.Find(selected.Id)!;
            if (selected != null)
            {
                selected.StatusId = "done";
                context.SaveChanges();
            }
            return RedirectToAction("Index", new {id = id});
        }

        [HttpPost]
        public IActionResult DeleteDone(string id)
        {
            var toDelete = context.Tickets
                .Where(t => t.StatusId == "done").ToList();

            foreach (var ticket in toDelete)
            {
                context.Tickets.Remove(ticket);
            }
            context.SaveChanges();
            return RedirectToAction("Index", new { id = id });
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
