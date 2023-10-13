using System;

namespace CSharp_FinalConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            University university = new University("Harvard", 3, 2500);
            int selectedItem = ShowMenu();

            switch (selectedItem)
            {
                case 1: // Show students

                    break;
                case 2: // Show students with group number
                    break;
                case 3: // Add student
                    break;
                case 4: // Update student
                    break;
                case 5: // Show avarage point of students
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
            foreach (var student in students)
            {
                Console.WriteLine($"{student.No}. {student.FullName} {student.GroupNo} - {student.Point}");
            }
        }

        public static void ShowStudent(List<Student> students, string groupNo)
        {
            foreach (var student in students)
            {
                if(student.GroupNo.ToString() == groupNo)
                {
                    Console.WriteLine($"{student.No}. {student.FullName} {student.GroupNo} - {student.Point}");
                }
            }
        }

        public static void AddStudent()
        {
            Console.WriteLine("You select add student;");
        }
    }
}