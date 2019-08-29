using HealthCatalystApp.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net.Http;
using Web_API.Controllers;

namespace Web_API.Tests.Controllers
{
    [TestClass]
    public class CrudControllerTest
    {
        private CRUDController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            IDbSet<People> people = MockDBHelper.GetMockDbSet(this.CreatePeople());
            controller = MockRepository.GeneratePartialMock<CRUDController>();
            controller.Request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:21969/api/");
            controller.Expect(c => c.GetResultResponse(null)).IgnoreArguments().Return(new HttpResponseMessage() {
                StatusCode = System.Net.HttpStatusCode.OK
            });

        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        /// <summary>
        /// Unit test to verify the AddPeople returns
        /// the expected result when called
        /// </summary>
        [TestMethod]
        public void Crud_AddPeople_Should_Add_People_Successfully()
        {
            // Act
            HttpResponseMessage result = controller.AddPeople(this.CreatePeople()[0]) as HttpResponseMessage;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// Unit test to verify the AddPeople returns
        /// the expected result when called
        /// </summary>
        [TestMethod]
        public void Crud_AddPeople_Should_Get_People_Successfully()
        {
            // Act
            HttpResponseMessage result = controller.GetPeople(1) as HttpResponseMessage;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// Unit test to verify the AddPeople returns
        /// the expected result when called
        /// </summary>
        [TestMethod]
        public void Crud_AddPeople_Should_Get_Peoples_Successfully()
        {
            // Act
            HttpResponseMessage result = controller.GetPeoples() as HttpResponseMessage;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// Unit test to verify the AddPeople returns
        /// the expected result when called
        /// </summary>
        [TestMethod]
        public void Crud_AddPeople_Should_Update_People_Successfully()
        {
            // Act
            HttpResponseMessage result = controller.UpdatePeople(this.CreatePeople()[0]) as HttpResponseMessage;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK);
        }

        private IList<People> CreatePeople()
        {
            IList<People> people = new List<People>()
            {
                new People()
                {
                    FullName = "John Smith",
                    Email = "john.smith@healthcatalyst.com",
                    Phone = "123-123-2121",
                    Address = "1234 Main St, Portland, OR",
                    Age = 34,
                    ID = 1,
                    Interests = "Reading and fishing",
                    Photo = "dummy photo url"
                
                },
                new People()
                {
                    FullName = "John Doe",
                    Email = "john.doe@healthcatalyst.com",
                    Phone = "123-45-2121",
                    Address = "456 Main St, Portland, OR",
                    Age = 78,
                    ID = 2,
                    Interests = "fishing",
                    Photo = "another dummy photo url"

                }
            };

            return people;
        }
    }
}
