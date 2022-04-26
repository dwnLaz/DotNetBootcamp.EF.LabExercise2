using LabExercise.EntityFramework_Part2.Data;
using LabExercise.EntityFramework_Part2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExercise.EntityFramework_Part2.Repository
{
    public class PositionRepository : MainRepository<Position>, IRepository<Position>
    {
        public PositionRepository(RecruitmentContext context) : base(context)
        {
        }
    }
}
