using core_webapi.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace core_webapi.Controllers
{
    //[Route("api/[controller]")]
    [Route("EmpDetails")]
    [ApiController]
    public class EmpDetailsController : ControllerBase
    {
        EmployeeDB dbobj = new EmployeeDB();
        // GET: api/<EmpDetailsController>
        [HttpGet]
        [Route("getalltab")]
        public List<emp_table> Get() //selectDB is list type so, return type is also list type of entity class.
        {
            return dbobj.selectDB();
        }

        // GET api/<EmpDetailsController>/5
        [HttpGet]
        [Route("gettabwithid/{id}")]
        public emp_table Get(int id)
        {
            var getemployee = dbobj.selectDB().Where(x => x.emp_id == id).FirstOrDefault(); //returns based on id from selectDB.
            return getemployee;
        }

        // POST api/<EmpDetailsController>
        [HttpPost]
        [Route("posttab")]
        public void Post([FromBody] emp_table clsobj)
        {
            dbobj.InsertDB(clsobj);
        }

        // PUT api/<EmpDetailsController>/5
        [HttpPut]
        [Route("puttab/{id}")]
        public void Put(int id,[FromBody] emp_table clsobj)
        {
            dbobj.updateprofile(id,clsobj);
        }

        // DELETE api/<EmpDetailsController>/5
        [HttpDelete]
        [Route("deletetab/{id}")]
        public void Delete(int id)
        {
            dbobj.deleteDB(id);
        }
    }
}
