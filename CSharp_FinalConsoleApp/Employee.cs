using System;
namespace CSharp_FinalConsoleApp
{
	public class Employee
	{
		private int _no = 1000;
		public string No { get; set; }
		public string  FullName { get; set; }
		public string Position { get; set; }
		public int Salary { get; set; }
		public DeparmentType DeparmentName { get; set; }
		public EmployeeType EmployeeTypeVar { get; set; }

		public Employee(string fullName, string position, int salary, DeparmentType deparmentName, EmployeeType employeeTypeVar)
		{
			FullName = fullName;
			Position = position;
			Salary = salary;
			DeparmentName = deparmentName;
			EmployeeTypeVar = employeeTypeVar;
			No = $"{DeparmentName.ToString()[0]}{DeparmentName.ToString()[1]}{_no}";
		}
	}
}

