using FirstResponsiveWebAppTreu2;
using FirstResponsiveWebAppTreu2.Controllers;
using System.ComponentModel.DataAnnotations;
using FirstResponsiveWebAppTreu2.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace UnitTestResponsiveWebApp
{
    public class UnitTest1
    {
        [Fact]
        public void ModelValidation_ReturnsCorrectAge()
        {
            //Arrange
            var model = new FirstResponsiveWebAppModel
            {
                BirthYear = 2000
            };

            int? expected = 26;
            int? actual;

            //Act
            actual = model.AgeThisYear();

            //Assert
            Assert.Equal(expected, actual);
        }        

        [Fact]
        public void ModelValidation_BirthYear_Name_ValidInput()
        {
            //Arrange
            var model = new FirstResponsiveWebAppModel
            {
                Name = "Megan",
                BirthYear = 1990
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);

            //Act
            bool isValid = Validator.TryValidateObject(model, validationContext, validationResults, true);

            //Assert
            Assert.True(isValid);
        }

        [Fact]
        public void ModelValidation_BirthYear_Name_InvalidInput()
        {
            //Arrange
            var model = new FirstResponsiveWebAppModel
            {
                Name = "Megan123",
                BirthYear = 1990
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);

            //Act
            bool isValid = Validator.TryValidateObject(model, validationContext, validationResults, true);

            //Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, r => r.ErrorMessage.Contains("Characters are not allowed"));
        }

        private HomeController GetController()
        {
            return new HomeController();
        }

        [Fact]
        public void HomeController_PostAction_CorrectIndexView()
        {
            //Arrange
            var controller = GetController();

            var model = new FirstResponsiveWebAppModel
            {
                Name = "Megan",
                BirthYear = 2000
            };

            controller.ModelState.Clear();

            //Act
            var result = controller.Index(model) as ViewResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(model, result.Model);

            Assert.Equal(model.AgeThisYear(), controller.ViewBag.AgeEndYear);
            Assert.Equal("Megan", controller.ViewBag.NameEntered);
        }

        [Fact]
        public void HomeController_PostAction_ReturnsViewResult()
        {
            //Arrange
            var controller = GetController();

            var model = new FirstResponsiveWebAppModel
            {
                Name = "George",
                BirthYear = 1993
            };            

            //Act
            var result = controller.Index(model);

            //Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
