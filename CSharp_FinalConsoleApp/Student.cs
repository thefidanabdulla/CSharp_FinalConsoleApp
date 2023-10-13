using System;
namespace CSharp_FinalConsoleApp
{
	public class Student
	{
		private int _no = 1000;
		public string No { get; set; }
		public string FullName { get; set; }
		public StudentGroup GroupNo { get; set; }
		public int Point { get; set; }

		public Student(string fullName, StudentGroup groupNo, int point)
		{
			FullName = fullName;
			GroupNo = groupNo;
			Point = point;
			No = $"{FullName[0]}{FullName[1]}{_no}";
		}
	}
}

