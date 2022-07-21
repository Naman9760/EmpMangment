using EmpMangment.DbContex;
using EmpMangment.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmpMangment.ModelSp
{
    public class MEmpData : IEmpData
    {
        private readonly EmpDbContex _DB;
        public MEmpData(EmpDbContex dB)
        {
            _DB = dB;
        }

        bool IEmpData.DeleteEmp(int id)
        {
            if (id > 0)
            {
                var emp = _DB.Database.ExecuteSqlRawAsync("exec Delete_Emp {0}", id);
                if (emp.Result != null) { return true; }
                else { return false; }
            }
            else { return false; }
        }

        object IEmpData.GetEmp(string firstName)
        {
            var emp = _DB.employeeDatas.FromSqlRaw("exec GetEmp");
            if (emp != null) { return emp; }
            else { return null; }
        }

        bool IEmpData.SaveEmp(EmployeeData employeeData)
        {
            //object[] data =
            //{
            //     new SqlParameter("@id",employeeData.id),
            //    new SqlParameter("@FirstName",employeeData.FirstName),
            //    new SqlParameter("@DateOfBirth", employeeData.DateOfBirth),
            //    new SqlParameter("@Age", employeeData.Age),
            //    new SqlParameter("@Designation", employeeData.Designation),
            //    new SqlParameter("@DateOfJoining", employeeData.DateOfJoining),
            //    new SqlParameter("@CTC", employeeData.CTC)
            //};
            //var emp = _DB.Database.ExecuteSqlRawAsync("exec AddEmp {0},{1},{2},{3},{4},{5},{6},{7},{8}",data);
          var emp = _DB.Database.ExecuteSqlRawAsync("exec AddEmp {0},{1},{2},{3},{4},{5},{6},{7}", 0,
              employeeData.FirstName, employeeData.LastName, employeeData.DateOfBirth, employeeData.Age, employeeData.Designation,
              employeeData.DateOfJoining, employeeData.CTC);
            if (emp.Result != null) { return true; }
            else { return false; }
        }
        

        bool IEmpData.UpdateEmp(EmployeeData employeeData)
        {
            if (employeeData.Id != 0)
            {
                var emp = _DB.Database.ExecuteSqlRawAsync("exec Update_Emp {0},{1},{2},{3},{4},{5},{6},{7}", employeeData.Id,
              employeeData.FirstName, employeeData.LastName, employeeData.DateOfBirth, employeeData.Age, employeeData.Designation,
              employeeData.DateOfJoining, employeeData.CTC);
                if (emp.Result != null) { return true; }
                else { return false; }
            }
            else { return false; }
        }
    }
}
