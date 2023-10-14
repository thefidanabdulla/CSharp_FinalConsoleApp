using System;
using System.Text.RegularExpressions;

namespace CSharp_FinalConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            University university = new University("Harvard", 3, 2500);
             

            GetAvarageOfStudents(university);
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
                    break;
                case 7: // Show employees in university
                    break;
                case 8: // Add employee
                    break;
                case 9: // Update employee
                    break;
                case 10: // Delece employee
                    break;
                case 11: // Search employee
                    break;
                case 12: // Search student
                    break;
                default: // Exit
                    Console.WriteLine("END");
                    break;
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

        }
    }
}