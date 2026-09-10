using Microsoft.AspNetCore.Mvc;
using PhoneContacts.Models;


namespace PhoneContacts.Controllers
{
    public class PhoneController : Controller
    {
        private PhoneContext context { get; set; }
        public PhoneController(PhoneContext ctx) => context = ctx;

        public IActionResult List()
        {
            var contacts = context.Phones.OrderBy(c => c.Name).ToList();
            return View(contacts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";            
            return View(new Phone());
        }        
        [HttpPost]
        public IActionResult Add(Phone contact)
        {
            if (ModelState.IsValid)
            {
                context.Phones.Add(contact);                
                context.SaveChanges();
                return RedirectToAction("List");
            }                           
            return View(contact);            
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = context.Phones.Find(id);
            return View(contact);
        }
        [HttpPost]
        public IActionResult Delete(Phone contact)
        {
            context.Phones.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}