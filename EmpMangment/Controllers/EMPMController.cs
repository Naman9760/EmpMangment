using EmpMangment.Model;
using EmpMangment.ModelSp;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpMangment.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("[controller]")]
    public class EMPMController : Controller
    {
        private readonly IEmpData  iemp;
        public EMPMController(IEmpData emp)
        {
            iemp = emp;
        }


        [HttpGet]
        [Route("GetEmployee")]       
        [MapToApiVersion("2.0")]
        [MapToApiVersion("1.0")]
        public IActionResult GetEmployee()
        {
            string Obj = string.Empty;
            var employee =iemp.GetEmp (Obj);
            return Json(employee);
        }

        [HttpPost]
        [Route("SaveEmployee")]
        [MapToApiVersion("2.0")]
        [MapToApiVersion("1.0")]
        public IActionResult SaveEmployee(EmployeeData Empdata)
        {
            var employee = iemp.SaveEmp(Empdata);
            return Json(employee);
        }

        [HttpPut]
        [Route("EditEmployee")]
        [MapToApiVersion("2.0")]
        public IActionResult UpdateEmployee(EmployeeData Empdata)
        {
            var employeed = iemp.UpdateEmp(Empdata);
            return Json(employeed);
        }

        [HttpPost]
        [Route("DeleteEmployee")]
        [MapToApiVersion("2.0")]
        public IActionResult Delete(int id)
        {

            var employee = iemp.DeleteEmp(id)
;
            return Json(employee);
        }

    }
}
 