using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabExercise.EntityFramework_Part2.Models;
using LabExercise.EntityFramework_Part2.Data;


namespace LabExercise.EntityFramework_Part2.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> FindAll();
        T FindByCode(string code);
    }
    public class MainRepository<T> where T : class
    {
        public RecruitmentContext Context { get; set; }

        public MainRepository(RecruitmentContext context)
        {
            this.Context = context;
        }
        public IEnumerable<T> FindAll()
        {
            IQueryable<T> query = this.Context.Set<T>();
            return query.Select(e => e).ToList();
        }

        public T FindByCode(string code)
        {
            var entity = this.Context.Find<T>(code);
            if (entity != null)
            {
                return entity;
            }
            throw new Exception($"Employee with code {code} doesn't exist.");
        }
    }
}
