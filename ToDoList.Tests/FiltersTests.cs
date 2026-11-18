using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Tests
{
    public class FiltersTests
    {
        [Fact]
        public void Constructor_SetStatusId()
        {
            //arrange
            string filter = "todo";

            //act
            Filters filters = new Filters(filter);

            //assert
            Assert.Equal("todo", filters.StatusId);
        }
        [Fact]
        public void HasStatus_ReturnsTrue()
        {
            //arrange
            Filters filters = new Filters("qa");

            //act
            bool result = filters.HasStatus;

            //assert
            Assert.True(result);
        }
        [Fact]
        public void HasStatus_ReturnsFalse()
        {
            //arrange
            Filters filters = new Filters("all");

            //act
            bool result = filters.HasStatus;

            //assert
            Assert.False(result);
        } 
        
        


    }
}
