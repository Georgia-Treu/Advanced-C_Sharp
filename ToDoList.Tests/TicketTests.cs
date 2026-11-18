using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Tests
{
    public class TicketTests
    {
        [Fact]
        public void Ticket_NameReturnsString()
        {
            //arrange
            Ticket ticket = new Ticket
            {
                Name = "Create Admin"               
            };

            //act
            string result = ticket.Name;

            //assert
            Assert.IsType<string>(result);           
        }
        [Fact]
        public void Ticket_StatusIdReturnsTodo()
        {
            //arrange
            Ticket ticket = new Ticket
            {
                StatusId = "todo"
            };

            string expected = "todo";

            //act
            string result = ticket.StatusId;

            //assert
            Assert.Equal(expected, result);

        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        public void Ticket_SprintNumberReturnsCorrectValue(int sprintNumber)
        {
            //arrange
            Ticket ticket = new Ticket
            {
                SprintNumber = sprintNumber
            };

            //act
            int? result = ticket.SprintNumber;

            //assert
            Assert.Equal(sprintNumber, result);
        }
        [Theory]
        [InlineData("Create Admin Page")]
        [InlineData("Plant Rose Garden")]
        [InlineData("Update Navigation Menu")]
        public void Ticket_DescriptionReturnsCorrectValue(string description)
        {
            //arrange
            Ticket ticket = new Ticket
            {
                Description = description
            };

            //act
            string result = ticket.Description;

            //assert
            Assert.Equal(description, result);
        }



    }
}
