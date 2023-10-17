using System;
using System.Text.RegularExpressions;

namespace CSharp_FinalConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            University university = new University("Harvard", 3, 2500);

            while (true)
            {
                int selectedItem = ShowMenu();

                switch (selectedItem)
                {
                    case 1: // Show students
                        ShowStudent(university.Students);
            
                        break;
                    case 2: // Show students with group number
                        ShowStudentByGroupType(university.Students);
                        break;
                    case 3: // Add student
                        university.AddStudent(AddStudent());
                        break;
                    case 4: // Update student
                        university.UpdateStudent(GetStudentGroupNo(), GetStudentGroupType());
                        break;
                    case 5: // Show avarage point of students
                        GetAvarageOfStudents(university);
                        break;
                    case 6: // Show employees list
                        ShowEmployees(university.Employees);
                        break;
                    case 7: // Show employees by deparment
                        ShowEmployeesByDepartment(university.Employees);
                        break;
                    case 8: // Add employee
                        university.AddEmployee(AddEmployee());
                        break;
                    case 9: // Update employee
                        university.UpdateEmployee(GetEmployeeNo(), GetEmployeePosition(), GetEmployeeSalary());
                        break;
                    case 10: // Delete employee
                        university.DeleteEmployee(GetEmployeeNo());
                        break;
                    case 11: // Search employee
                        SearchEmployees(university.Employees);
                        break;
                    case 12: // Search student
                        SearchStudents(university.Students);
                        break;
                    default: // Exit
                        Console.WriteLine("END");
                        return;
                }

            }
            

            Console.ReadLine();
        }

        public static int ShowMenu()
        {
            Console.WriteLine("Select the number of your choice:");

            Console.WriteLine("1. Show students");
            Console.WriteLine("2. Show students with group number;");
            Console.WriteLine("3. Add student;");
            Console.WriteLine("4. Update student;");
            Console.WriteLine("5. Show avarage point of students");
            Console.WriteLine("6. Show employees list");
            Console.WriteLine("7. Show employees in university;");
            Console.WriteLine("8. Add employee;");
            Console.WriteLine("9. Update employee");
            Console.WriteLine("10. Delece employee");
            Console.WriteLine("11. Search emloyee");
            Console.WriteLine("12. Search student;");
            Console.WriteLine("13. Exit;");

            string selectedItemStr;
            int selectedItem;

            do
            {
                Console.WriteLine("Select the number of your choice:");
                selectedItemStr = Console.ReadLine();
            } while (!int.TryParse(selectedItemStr, out selectedItem) || !(selectedItem > 0 && selectedItem < 14));

            return selectedItem;
        }

        public static void ShowStudent(List<Student> students)
        {
            Console.WriteLine(students.Count);
            if(students.Count > 0)
            {
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.GroupNo}. {student.FullName} {student.GroupNo} - {student.Point}");
                }
            }
            else
            {
                Console.WriteLine("You are not added any student yet;");
            }
        }

        public static void ShowStudentByGroupType(List<Student> students)
        {
            if(students.Count > 0)
            {
                string groupTypeStr;
                GroupType groupType;
                do
                {
                    Console.WriteLine("Enter the group type(Programming, Design, System) of student: ");
                    groupTypeStr = Console.ReadLine();
                } while (!Enum.TryParse(groupTypeStr, out groupType));


                foreach (var student in students)
                {
                    if (student.GroupType == groupType)
                    {
                        Console.WriteLine($"{student.GroupNo}. {student.FullName} {student.GroupNo} - {student.Point}");
                    }
                }
            }
            else
            {
                Console.WriteLine("You are not added any student yet;");
            }
        }

        public static Student AddStudent()
        {
            Console.WriteLine("You select add student;");
            bool IsFullNameIsTrue = false;
            string fullName = "";
            do
            {
                Console.WriteLine("Enter the name and surname of student:");
                bool IsWordContainsNumbers = false;
                string fullnameStr = Console.ReadLine();
                string[] words = fullnameStr.Split(' ');

                if (words.Length == 2)
                {
                    foreach (var word in words)
                    {
                        if(word.Length > 2)
                        {
                            Regex regex = new Regex("[^a-zA-Z]");
                            if (regex.IsMatch(word))
                            {
                                IsWordContainsNumbers = true;
                                Console.WriteLine("Please just enter letters");
                            }
                            else
                            {
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            IsWordContainsNumbers = true;
                            Console.WriteLine("Every word must be contains minimum 3 letters.");
                        }
                    }
                }
                else
                {
                    IsWordContainsNumbers = true;
                    Console.WriteLine("You must add name and surname as 2 words.");
                }
                if (!IsWordContainsNumbers)
                {
                    fullName = fullnameStr;
                }
                IsFullNameIsTrue = !IsWordContainsNumbers;


            } while (!IsFullNameIsTrue);

            GroupType groupType = GetStudentGroupType();
            
            string pointStr;
            int point;
            do
            {
                Console.WriteLine("Enter the point of Student");
                pointStr = Console.ReadLine();
            } while (!int.TryParse(pointStr, out point) || !(point > 0 && point < 100));

            Student student = new Student(fullName, point, groupType);

            return student;
        }

        public static string GetStudentGroupNo()
        {
            Console.WriteLine("You select update student. Please enter the groupNo of student for update");

            string groupNo = Console.ReadLine();

            return groupNo;
            
            
        }

        public static GroupType GetStudentGroupType()
        {
            string groupTypeStr;
            GroupType groupType;
            do
            {
                Console.WriteLine("Enter the group type(Programming, Design, System) of student: ");
                groupTypeStr = Console.ReadLine();
            } while (!Enum.TryParse(groupTypeStr, out groupType));

            return groupType;
        }

        public static EmployeeType GetEmployeeType()
        {
            string employeeTypeStr;
            EmployeeType employeeType;
            do
            {
                Console.WriteLine("Enter the type of employee(Fulltime, Parttime, Adjunct):");
                employeeTypeStr = Console.ReadLine();
            } while (!Enum.TryParse(employeeTypeStr, out employeeType));

            return employeeType;
        }

        public static DeparmentType GetEmployeeDeparmentType()
        {
            string deparmentTypeStr;
            DeparmentType deparmentType;
            do
            {
                Console.WriteLine("Enter the deparment type(IT, Maliyye, Marketing) of employee:");
                deparmentTypeStr = Console.ReadLine();
            } while (!Enum.TryParse(deparmentTypeStr, out deparmentType));

            return deparmentType;
        }

        public static void GetAvarageOfStudents(University university)
        {
            if(university.Students.Count > 0)
            {
                Console.WriteLine("You select show avarage of students. Do you want all stundets' avarage(a) or spesific students avarage(b)?");
                string enteredLetter;
                do
                {
                    Console.WriteLine("Select a or b:");
                    enteredLetter = Console.ReadLine();
                } while (!(enteredLetter == "a" || enteredLetter == "b"));

                if(enteredLetter == "a")
                {
                    university.CalcStudentsAverage();
                }else if(enteredLetter == "b")
                {
                    GroupType groupType = GetStudentGroupType();
                    university.CalcStudentsAverage(groupType);
                }
            }
            else
            {
                Console.WriteLine("You are not added any employee yet!");
            }
        }

        public static DeparmentType GetDeparmentTypeOfEmployee()
        {
            string deparmentTypeStr;
            DeparmentType deparmentType;
            do
            {
                Console.WriteLine("Enter the group type(Programming, Design, System) of student: ");
                deparmentTypeStr = Console.ReadLine();
            } while (!Enum.TryParse(deparmentTypeStr, out deparmentType));

            return deparmentType;
        }

        public static void ShowEmployees(List<Employee> employees)
        {
            if (employees.Count > 0)
            {
                foreach (var emp in employees)
                {
                    Console.WriteLine($"{emp.No}. {emp.FullName} {emp.DeparmentName} - {emp.Salary}");
                }
            }
            else
            {
                Console.WriteLine("You are not added any employee yet;");
            }
        }

        public static void ShowEmployeesByDepartment(List<Employee> employees)
        {
            if (employees.Count > 0)
            {
                string deparmentNameStr;
                DeparmentType deparmentName;
                do
                {
                    Console.WriteLine("Enter the department type(IT, Maliyye, Marketing) of student: ");
                    deparmentNameStr = Console.ReadLine();
                } while (!Enum.TryParse(deparmentNameStr, out deparmentName));


                foreach (var emp in employees)
                {
                    if (emp.DeparmentName == deparmentName)
                    {
                        Console.WriteLine($"{emp.No}. {emp.FullName} {emp.DeparmentName} - {emp.Salary}");
                    }
                }
            }
            else
            {
                Console.WriteLine("You are not added any employee yet;");
            }
        }

        public static string GetEmployeeNo()
        {
            Console.WriteLine("Enter employee no:");
            string employeeNo = Console.ReadLine();

            return employeeNo;
        }

        public static string GetEmployeePosition()
        {
            bool IsPositionTrue = false;
            string position = "";
            do
            {
                Console.WriteLine("Enter the position of employee");
                bool IsWordContainsNumbers = false;
                string postionStr = Console.ReadLine();

                if (postionStr.Length > 2)
                {
                    Regex regex = new Regex("[^a-zA-Z]");
                    if (regex.IsMatch(postionStr))
                    {
                        IsWordContainsNumbers = true;
                        Console.WriteLine("Please just enter letters");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
                else
                {
                    IsWordContainsNumbers = true;
                    Console.WriteLine("Position must be contains minimum 3 letters.");
                }

                if (!IsWordContainsNumbers)
                {
                    position = postionStr;
                }
                IsPositionTrue = !IsWordContainsNumbers;


            } while (!IsPositionTrue);

            return position;
        }

        public static int GetEmployeeSalary()
        {
            string salaryStr;
            int salary;
            do
            {
                Console.WriteLine("Enter the salary of employee.");
                salaryStr = Console.ReadLine();
            } while (!int.TryParse(salaryStr, out salary));

            return salary;
        }

        public static Employee AddEmployee()
        {
            Console.WriteLine("You select add employee;");
            bool IsFullNameIsTrue = false;
            string fullName = "";
            do
            {
                Console.WriteLine("Enter the name and surname of student:");
                bool IsWordContainsNumbers = false;
                string fullnameStr = Console.ReadLine();
                string[] words = fullnameStr.Split(' ');

                if (words.Length == 2)
                {
                    foreach (var word in words)
                    {
                        if (word.Length > 2)
                        {
                            Regex regex = new Regex("[^a-zA-Z]");
                            if (regex.IsMatch(word))
                            {
                                IsWordContainsNumbers = true;
                                Console.WriteLine("Please just enter letters");
                            }
                            else
                            {
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            IsWordContainsNumbers = true;
                            Console.WriteLine("Every word must be contains minimum 3 letters.");
                        }
                    }
                }
                else
                {
                    IsWordContainsNumbers = true;
                    Console.WriteLine("You must add name and surname as 2 words.");
                }
                if (!IsWordContainsNumbers)
                {
                    fullName = fullnameStr;
                }
                IsFullNameIsTrue = !IsWordContainsNumbers;


            } while (!IsFullNameIsTrue);

            string position = GetEmployeePosition();

            int salary = GetEmployeeSalary();

            DeparmentType deparmentType = GetEmployeeDeparmentType();

            EmployeeType employeeType = GetEmployeeType();

            Employee employee = new Employee(fullName, position, salary, deparmentType, employeeType);

            return employee;


        }

        public static void SearchEmployees(List<Employee> employees)
        {
            DeparmentType deparmentType = GetDeparmentTypeOfEmployee();

            foreach (var emp in employees)
            {
                if(emp.DeparmentName == deparmentType)
                {
                    Console.WriteLine($"{emp.No}. {emp.FullName} - {emp.DeparmentName} - {emp.Salary}");
                }
            }
        }

        public static void SearchStudents(List<Student> students)
        {
            GroupType groupType = GetStudentGroupType();
            foreach (var student in students)
            {
                if(student.GroupType == groupType)
                {
                    Console.WriteLine($"{student.GroupNo} {student.FullName} {student.GroupType} - {student.Point}");
                }
            }
        }
    }
}