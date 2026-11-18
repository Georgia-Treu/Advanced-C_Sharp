using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private TicketContext context;
        private IRepository<Ticket> ticketData;
        private IRepository<Status> statusData;
        public HomeController(TicketContext ctx, IRepository<Ticket> ticketRep, IRepository<Status> statusRep) 
        {           
            context = ctx;
            ticketData = ticketRep;
            statusData = statusRep;
        }

        public IActionResult Index(string id)
        {
            var filters = new Filters(id);

            ViewBag.Filters = filters;
            ViewBag.Statuses = statusData.List();            

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
            ViewBag.Statuses = statusData.List();
            var ticket = new Ticket();
            return View(ticket);
        }

        [HttpPost]
        public IActionResult Add(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticketData.Insert(ticket);
                ticketData.Save();
                return RedirectToAction("Index");
            }
            else
            {                
                ViewBag.Statuses = statusData.List();
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
            selected = ticketData.Get(selected.Id)!;
            if (selected != null)
            {
                selected.StatusId = "done";
                ticketData.Save();
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
