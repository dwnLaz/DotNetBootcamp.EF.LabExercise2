using LabExercise.EntityFramework_Part2.Data;
using LabExercise.EntityFramework_Part2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LabExercise.EntityFramework_Part2.Repository
{
    internal class EmployeeSkillRepository : MainRepository<EmployeeSkill>, IRepository<EmployeeSkill>
    {
        public EmployeeSkillRepository(RecruitmentContext context) : base(context)
        {
        }
        public IEnumerable<dynamic> FindAll(string employeeCode)
        {
            var skills = this.Context.EmployeeSkills
                .Join(Context.Skills, employee => employee.CSkillCode, skill => skill.CSkillCode, (employee, skill) => new {CEmployeeCode = employee.CEmployeeCode, CSkillCode = skill.VSkill})
                .Where(e => e.CEmployeeCode == employeeCode)
                .ToList();

            return skills;
        }
    }
}
