using FrontEnd.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Web.Mvc;

namespace FrontEnd.Tests.Controllers
{
    [TestClass]
    public class CrudControllerTest
    {
        /// <summary>
        /// Unit test to verify the Index action method returns
        /// the expected result when called
        /// </summary>
        [TestMethod]
        public void CrudController_Index_View_Should_Be_Return_Successfully()
        {
            //Assemble
            CrudController controller =
                MockRepository.GeneratePartialMock<CrudController>();

            //Act
            ActionResult result = controller.Index();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result is ViewResult);
        }

    }
}
