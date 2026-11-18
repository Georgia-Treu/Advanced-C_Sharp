using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Filter_PassesFilteredStatusToRoute()
        {
            //arrange
            var ticketRepo = new Mock<IRepository<Ticket>>();
            var statusRepo = new Mock<IRepository<Status>>();
            var controller = new HomeController(null!, ticketRepo.Object, statusRepo.Object);

            //act
            var result = (RedirectToActionResult)controller.Filter("todo");

            //assert
            Assert.Equal("todo", result.RouteValues!["id"]);
        }

        [Fact]
        public void Filter_ReturnsRedirectToActionResult()
        {
            //arrange
            var ticketRepo = new Mock<IRepository<Ticket>>();
            var statusRepo = new Mock<IRepository<Status>>();
            var controller = new HomeController(null!, ticketRepo.Object, statusRepo.Object);

            //act
            var result = controller.Filter("todo");

            //assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Filter_RedirectsToIndex()
        {

            //arrange
            var ticketRepo = new Mock<IRepository<Ticket>>();
            var statusRepo = new Mock<IRepository<Status>>();
            var controller = new HomeController(null!, ticketRepo.Object, statusRepo.Object);

            //act
            var result = (RedirectToActionResult)controller.Filter("todo");

            //assert
            Assert.Equal("Index", result.ActionName);
        }
        [Fact]
        public void Add_GetReturnsViewResult()
        {
            //arrange
            var ticketRepo = new Mock<IRepository<Ticket>>();
            var statusRepo = new Mock<IRepository<Status>>();
            statusRepo.Setup(m => m.List()).Returns(new List<Status>());
            var controller = new HomeController(null!, ticketRepo.Object, statusRepo.Object);

            //act
            var result = controller.Add();

            //assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Add_PostValidTicketRedirectToAction()
        {
            //arrange
            var ticketRepo = new Mock<IRepository<Ticket>>();
            var statusRepo = new Mock<IRepository<Status>>();            
            var controller = new HomeController(null!, ticketRepo.Object, statusRepo.Object);

            Ticket ticket = new Ticket
            {
                Name = "Create Admin",
                Description = "Create Admin Page",
                SprintNumber = 1,
                PointValue = 5,
                StatusId = "todo"
            };

            //act
            var result = controller.Add(ticket);

            //assert
            Assert.IsType<RedirectToActionResult>(result);
        }
        [Fact]
        public void Add_PostValidTicketRedirectToIndex()
        {
            //arrange
            var ticketRepo = new Mock<IRepository<Ticket>>();
            var statusRepo = new Mock<IRepository<Status>>();
            var controller = new HomeController(null!, ticketRepo.Object, statusRepo.Object);

            Ticket ticket = new Ticket
            {
                Name = "Create Admin",
                Description = "Create Admin Page",
                SprintNumber = 1,
                PointValue = 5,
                StatusId = "todo"
            };

            //act
            var result = (RedirectToActionResult)controller.Add(ticket);

            //assert
            Assert.Equal("Index", result.ActionName);
        }        
    }
}
