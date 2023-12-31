﻿using System;
namespace CSharp_FinalConsoleApp
{
	public class University
	{
		public string Name { get; set; }
		public int WorkerLimit { get; set; }
		public int SalaryLimit { get; set; }
		public List<Employee> Employees { get; set; }
		public List<Student> Students { get; set; }

        private List<Student> filteredStudents;

        public University(string name, int workerLimit, int salaryLimit)
		{
			Name = name;
			WorkerLimit = workerLimit;
			SalaryLimit = salaryLimit;
            Employees = new List<Employee>();
            Students = new List<Student>();
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
                Console.WriteLine("You are not added any employee yet :/");
            }
        }

        public void CalcStudentsAverage()
        {
            int sum = 0;
            int avarage;
            foreach (var student in Students)
            {
                sum += student.Point;
            }
            avarage = sum / Students.Count;
            Console.WriteLine($"Avarage of student's point: {avarage}");
        }

        public void CalcStudentsAverage(GroupType groupType)
        {
            int sum = 0;
            int avarage;

 
            foreach (var student in Students)
            {
                if(student.GroupType == groupType)
                {
                    filteredStudents.Add(student);
                }
            }

            if (filteredStudents.Count > 0)
            {
                foreach (var student in filteredStudents)
                {
                    sum += student.Point;
                }

                avarage = sum / filteredStudents.Count;

                Console.WriteLine($"Avarage of {groupType} - student's point: {avarage}");
            }
            else
            {
                Console.WriteLine("You are not aded any student with this group number yet :/");
            }
        }

        public void AddEmployee(Employee employee)
        {
            if(Employees.Count <= WorkerLimit)
            {
                if(employee.Salary > 250 && employee.Salary < 2500)
                {
                    Employees.Add(employee);
                }
                else
                {
                    Console.WriteLine("Employee salary must be between 250 and 2500 :/");
                }
            }
            else
            {
                Console.WriteLine("Worker limit of university is fulled");
            }
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void UpdateEmployee(string employeeNo, string position, int salary)
        {
            bool isAlreadyExist = false;
            

            foreach (var emp in Employees)
            {
                if(emp.No == employeeNo)
                {
                    isAlreadyExist = true;

                    Console.WriteLine($"{emp.No}. {emp.FullName} - {emp.Salary} - {emp.DeparmentName}");
                    emp.Position = position;
                    emp.Salary = salary;

                    Console.WriteLine($"{emp.No}. {emp.FullName} - {emp.Salary} - {emp.DeparmentName}");
                }
            }

            if (!isAlreadyExist)
            { 
                Console.WriteLine("You are not added any employee with this no :/");
            }

        }

        public void UpdateStudent(string groupNo, GroupType groupType)
        {
            bool isAlreadyExist = false;


            foreach (var stu in Students)
            {
                if (stu.GroupNo == groupNo)
                {
                    isAlreadyExist = true;

                    Console.WriteLine($"{stu.GroupNo}. {stu.FullName} - {stu.GroupType} ");
                    stu.GroupType = groupType;

                    Console.WriteLine($"{stu.GroupNo}. {stu.FullName} - {stu.GroupType}");
                }
            }

            if (!isAlreadyExist)
            {
                Console.WriteLine("You are not added any student with this groupNo :/");
            }

        }

        public void DeleteEmployee(string employeeNo)
        {
            bool isEmployeeExist = false;
            foreach (var emp in Employees)
            {
                if(emp.No == employeeNo)
                {
                    isEmployeeExist = true;
                    Employees.Remove(emp);
                }
            }

            if (!isEmployeeExist)
            {
                Console.WriteLine("There is no any employee with this no :/");
            }
        }
    }
}

