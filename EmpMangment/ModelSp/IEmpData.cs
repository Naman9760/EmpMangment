using EmpMangment.Model;

namespace EmpMangment.ModelSp
{
    public interface IEmpData
    {
        public object GetEmp(string firstName);
        public bool SaveEmp(EmployeeData employeeData);
        public bool UpdateEmp(EmployeeData employeeData);
        public bool DeleteEmp(int id);

    }
}
