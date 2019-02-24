using ITWORX.TGP.EGYPT.SchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Routing;
using ITWORX.TGP.EGYPT.SchoolSystem_WebAPI_.ActionResults;

namespace ITWORX.TGP.EGYPT.SchoolSystem.Controllers
{
    [RoutePrefix("schools")]
    public class SchoolsController : ApiController
    {
        [HttpGet]
        [Route]
        public IHttpActionResult Get([FromUri]SearchCriteria search)
        {
            var returnedList = School.Schools.AsQueryable();
            if (search != null)
            {
                if (!string.IsNullOrWhiteSpace(search.Name))
                    returnedList = returnedList.Where(sch => sch.Name.Contains(search.Name));

                if (search.City.Equals(null))
                    returnedList = returnedList.Where(sch => sch.City.Equals(search.City));
            }

            return Ok(returnedList);
        }

        [HttpGet]
        [Route("System/{system}")]
        public IHttpActionResult Get(string system)
        {
            if (system.Length > 2 || system.Length < 2)
                return BadRequest("System must only be 2 letters");

            //mutiple schools
            var school = School.Schools.FirstOrDefault(sch => sch.System == system);
            
            if (school == null)
                return NotFound();

            return Ok(school);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if(id <= 0)
                return BadRequest("Id must be greater than 0");

            var school = School.Schools.FirstOrDefault(sch => sch.Id == id);

            if(school == null)
                return NotFound();

            return Ok(school);
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id must be greater than 0");

            // use any
            var school = School.Schools.FirstOrDefault(sch => sch.Id == id);

            if (school == null)
                return NotFound();

            School.Schools.Remove(school);

            return new NoContent();
        }

        [HttpPost]
        [Route]
        public IHttpActionResult Post(School school)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var location = Request.RequestUri.Scheme + "://" + Request.RequestUri.Authority + "/schools/" + school.Id;
            return Created(location, school);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Put(int id , School school)
        {
            if (id <= 0)
                return BadRequest("Id must be greater than 0");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var schoolToModify = School.Schools.FirstOrDefault(sch => sch.Id == id);

            if (school == null)
                return NotFound();

            schoolToModify.Name = school.Name;
            schoolToModify.City = school.City;
            schoolToModify.System = school.System;
            schoolToModify.AverageNumberOfStudentsInClass = school.AverageNumberOfStudentsInClass;
            schoolToModify.Website = school.Website;
            schoolToModify.Contact = school.Contact;

            return new NoContent();
        }
    }
}