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
		public string DeparmentName { get; set; }
		public EmployeeType EmployeeTypeVar { get; set; }

		public Employee(string fullName, string position, int salary, string deparmentName, EmployeeType employeeTypeVar)
		{
			FullName = fullName;
			Position = position;
			Salary = salary;
			DeparmentName = deparmentName;
			EmployeeTypeVar = employeeTypeVar;
			No = $"{DeparmentName[0]}{DeparmentName[1]}{_no}";
		}
	}
}

