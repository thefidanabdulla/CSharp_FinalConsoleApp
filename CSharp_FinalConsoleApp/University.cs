using System;
namespace CSharp_FinalConsoleApp
{
	public class University
	{
		public string Name { get; set; }
		public int WorkerLimit { get; set; }
		public int SalaryLimit { get; set; }
		public List<Employee> Employees;
		public List<Student> Students;


		public University(string name, int workerLimit, int salaryLimit)
		{
			Name = name;
			WorkerLimit = workerLimit;
			SalaryLimit = salaryLimit;
		}

		public void CalcSalaryAverage()
		{
            int sum = 0;

            if (Employees.Count > 0)
            {
                foreach (var employee in Employees)
                {
                    sum += employee.Salary;
                }

                int avarage = sum / Employees.Count;

                Console.WriteLine($"Salary avarage of employees: {avarage}");
            }
            else
            {
                Console.WriteLine("You are not added any ");
            }
        }

        public void CalcStudentsAverage()
        {

        }
    }
}

