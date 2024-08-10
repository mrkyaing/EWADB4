using CloudHRMSAPI.DAO;
using CloudHRMSAPI.Models;
using CloudHRMSAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudHRMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly CloudHRMSAPIContext _context;

        public EmployeeController(CloudHRMSAPIContext context)
        {
            _context = context;
        }
        // GET: api/<EmployeeController>
        //host:port/api/employee/get
        //host:port/api/{controllerName}/{MethodName}
        [HttpGet]
        public IEnumerable<EmployeeModel> Get()
        {
           IEnumerable<EmployeeModel> employees=_context.Employees.Where(w=>!w.IsInActive).Select(s=>new EmployeeModel
           {
               Code = s.Code,
               Name = s.Name,
               Email = s.Email,
               Phone = s.Phone,
               Gender = s.Gender,
               DOR = s.DOR,
               DOE = s.DOE,
               DOB = s.DOB,
               Address = s.Address,
               BasicSalary = s.BasicSalary,
           }).AsEnumerable();
            return employees;
        }

        // GET api/<EmployeeController>/5
        //host://port/api/employee/e001
        [HttpGet("{code}")]
        public ActionResult<EmployeeModel> Get(string code)
        {
               EmployeeModel employee = _context.Employees.Where(w => !w.IsInActive && w.Code.Equals(code))
                .Select(s => new EmployeeModel
                {
                    Code = s.Code,
                    Name = s.Name,
                    Email = s.Email,
                    Phone = s.Phone,
                    Gender = s.Gender,
                    DOR = s.DOR,
                    DOE = s.DOE,
                    DOB = s.DOB,
                    Address = s.Address,
                    BasicSalary = s.BasicSalary,
                }).FirstOrDefault();
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeModel employeeModel)
        {
            try
            {
                EmployeeEntity employeeEntity = new EmployeeEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = employeeModel.Code,
                    Name = employeeModel.Name,
                    Email = employeeModel.Email,
                    Phone = employeeModel.Phone,
                    Gender = employeeModel.Gender,
                    DepartmentId = employeeModel.DepartmentId,//adding the ralatiosnip key -departmentId
                    PositionId = employeeModel.PositionId,//adding the ralatiosnip key - positionId
                    DOR = employeeModel.DOR,
                    DOE = employeeModel.DOE,
                    DOB = employeeModel.DOB,
                    Address = employeeModel.Address,
                    BasicSalary = employeeModel.BasicSalary,
                    CreatedAt = DateTime.Now,//set the current date time 
                    UserId = employeeModel.UserId
                };
                _context.Employees.Add(employeeEntity);
                _context.SaveChanges();
                return Ok("Success");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        //// PUT api/<EmployeeController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<EmployeeController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
