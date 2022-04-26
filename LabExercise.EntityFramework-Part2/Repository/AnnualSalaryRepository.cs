using LabExercise.EntityFramework_Part2.Data;
using LabExercise.EntityFramework_Part2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExercise.EntityFramework_Part2.Repository
{
    public class AnnualSalaryRepository : MainRepository<AnnualSalary>, IRepository<AnnualSalary>
    {
        public AnnualSalaryRepository(RecruitmentContext context) : base(context)
        {
        }
        public IEnumerable<AnnualSalary> FindAll(string employeeCode)
        {
            return this.Context.AnnualSalaries.Where(x => x.CEmployeeCode.Equals(employeeCode)).ToList();
        }
    }
}
