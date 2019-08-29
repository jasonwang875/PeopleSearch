using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;

namespace Web_API.Controllers
{
    /// <summary>
    /// Crud Operation Controller
    /// </summary>
    public class CRUDController : ApiController
    {
        private static PeopleDbContext crud = new PeopleDbContext();
        private static int waittingCounter = 2000;

        /// <summary>
        /// Get All People Details
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(IEnumerable<People>))]
        [System.Web.Http.Route("api/GetPeoples")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetPeoples()
        {
            Thread.Sleep(waittingCounter);
            var result = crud.Peoples.ToList();
            return GetResultResponse(result);
        }

        /// <summary>
        /// Get People Details
        /// </summary>
        /// <remarks>
        /// Get People Details based on empid
        /// </remarks>
        /// <param name="peopleid"></param>
        /// <returns></returns>
        [ResponseType(typeof(IEnumerable<People>))]
        [System.Web.Http.Route("api/GetPeople")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetPeople(int peopleid)
        {
            Thread.Sleep(waittingCounter);
            var result = crud.Peoples.Where(a => a.ID == peopleid).ToList();
            return GetResultResponse(result);
        }
        /// <summary>
        /// Add new people
        /// </summary>
        /// <remarks>
        /// Create new people and return inserted people details
        /// </remarks>
        /// <param name="people"></param>
        /// <returns></returns>
        [ResponseType(typeof(IEnumerable<People>))]
        [System.Web.Http.Route("api/AddPeople")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage AddPeople(People people)
        {
            Thread.Sleep(waittingCounter);
            var result = crud.Peoples.Add(people);
            crud.SaveChanges();
            return GetResultResponse(result);
        }
        /// <summary>
        /// Update People Details
        /// </summary>
        /// <remarks>
        /// Update People Details Based on empid
        /// </remarks>
        /// <param name="people"></param>
        /// <returns></returns>
        [ResponseType(typeof(IEnumerable<People>))]
        [System.Web.Http.Route("api/UpdatePeople")]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage UpdatePeople(People people)
        {
            Thread.Sleep(waittingCounter);
            People result = crud.Peoples.Where(a => a.ID == people.ID).FirstOrDefault();
            if (result != null)
            {
                result.FullName = people.FullName;
                result.Phone = people.Phone;
                result.Interests = people.Interests;
                result.Email = people.Email;
                result.Photo = people.Photo;
                result.Age = people.Age;
                result.Address = people.Address;
                crud.Entry(result).State = EntityState.Modified;
                crud.SaveChanges();
            }
            return GetResultResponse(result);
        }
        /// <summary>
        /// Delete People
        /// </summary>
        /// <remarks>
        /// Delete People record based on empid
        /// </remarks>
        /// <param name="people"></param>
        /// <returns></returns>
        [ResponseType(typeof(IEnumerable<People>))]
        [System.Web.Http.Route("api/DeletePeople")]
        [System.Web.Http.HttpDelete]
        public void DeletePeople(People people)
        {
            Thread.Sleep(waittingCounter);
            People result = crud.Peoples.Where(a => a.ID == people.ID).FirstOrDefault();
            if (result != null)
            {
                crud.Entry(result).State = EntityState.Deleted;
                crud.SaveChanges();
            }

        }


        /// <summary>
        /// Get Response for Each result
        /// </summary>
        /// <param name="Result"></param>
        /// <returns></returns>
        public virtual HttpResponseMessage GetResultResponse(object Result)
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, Result);
            }
            return response;
        }
    }
}