using System;
using LabExercise.EntityFramework_Part2.Models;
using LabExercise.EntityFramework_Part2.Repository;
using LabExercise.EntityFramework_Part2.Data;
using System.Collections.Generic;

namespace LabExercise.EntityFramework_Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConfigurationHelper configurationHelper = ConfigurationHelper.Instance();
            var dbConnectionString = configurationHelper.GetProperty<string>("DbConnectionString");

            using (RecruitmentContext context = new RecruitmentContext(dbConnectionString))
            {
                EmployeeRepository employeeRepository = new EmployeeRepository(context);
                AnnualSalaryRepository annualSalaryRepository = new AnnualSalaryRepository(context);
                MonthlySalaryRepository monthlySalaryRepository = new MonthlySalaryRepository(context);
                EmployeeSkillRepository employeeSkillRepository = new EmployeeSkillRepository(context);
                PositionRepository positionRepository = new PositionRepository(context);

                try
                {
                    Console.Write("Enter Employee Code: ");
                    string code = Console.ReadLine();
                    Employee employeeCode = employeeRepository.FindByCode(code);

                    Console.WriteLine("\n");

                    IEnumerable<AnnualSalary> annualSalary = annualSalaryRepository.FindAll(employeeCode.CEmployeeCode);
                    IEnumerable<MonthlySalary> monthlySalary = monthlySalaryRepository.FindAll(employeeCode.CEmployeeCode);
                    IEnumerable<dynamic> employeeSkills = employeeSkillRepository.FindAll(employeeCode.CEmployeeCode);
                    Position position = positionRepository.FindByCode(employeeCode.CCurrentPosition);


                    Console.WriteLine($"Employee Code: {employeeCode.CEmployeeCode}\n" +
                                      $"First Name: {employeeCode.VFirstName}\n" +
                                      $"Last Name: {employeeCode.VLastName}\n" +
                                      $"Position: {position.VDescription}\n");

                    Console.WriteLine("Employee Annual Salaries");
                    foreach (var salary in annualSalary)
                    {
                        Console.WriteLine($"\t\tYear: {salary.SiYear}" +
                                          $"\tSalary: {salary.MAnnualSalary}");
                    }

                    Console.WriteLine("\nEmployee Monthly Salaries ");
                    foreach (var salary in monthlySalary)
                    {
                        Console.WriteLine($"\t\tSalary: {salary.MMonthlySalary}\t" +
                                          $"Pay Date: {salary.DPayDate}\t" +
                                          $"Referral Bonus: {salary.MReferralBonus}");
                    }

                    Console.WriteLine("\nEmployee Skills");
                    foreach (var skill in employeeSkills)
                    {
                        Console.WriteLine($"\t\t{skill.CSkillCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
