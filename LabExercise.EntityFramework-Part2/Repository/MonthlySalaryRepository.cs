using LabExercise.EntityFramework_Part2.Data;
using LabExercise.EntityFramework_Part2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExercise.EntityFramework_Part2.Repository
{
    public class MonthlySalaryRepository : MainRepository<MonthlySalary>, IRepository<MonthlySalary>
    {
        public MonthlySalaryRepository(RecruitmentContext context) : base(context)
        {
        }
        public IEnumerable<MonthlySalary> FindAll(string employeeCode)
        {
            return this.Context.MonthlySalaries.Where(x => x.CEmployeeCode.Equals(employeeCode)).ToList();
        }
    }
}
