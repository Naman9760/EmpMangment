using EmpMangment.Model;
using Microsoft.EntityFrameworkCore;

namespace EmpMangment.DbContex
{
    public class EmpDbContex : DbContext
    {
        public EmpDbContex(DbContextOptions<EmpDbContex> options) : base(options)
        {

        }
        public DbSet<EmployeeData> employeeDatas { get; set; }
    }
}
