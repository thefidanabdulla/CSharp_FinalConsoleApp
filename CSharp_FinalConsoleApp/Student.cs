using System;
namespace CSharp_FinalConsoleApp
{
	public class Student
	{
		public string FullName { get; set; }
		public int GroupNo { get; set; }
		public int Point { get; set; }

		public Student(string fullName, int groupNo, int point)
		{
			FullName = fullName;
			GroupNo = groupNo;
			Point = point;
		}
	}
}

