using System;
namespace CSharp_FinalConsoleApp
{
	public class Student
	{
		private int _no = 100;
		public string FullName { get; set; }
		public GroupType GroupType { get; set; }
		public string GroupNo { get; set; }
		public int Point { get; set; }

		public Student(string fullName, int point, GroupType groupType)
		{
			FullName = fullName;
			Point = point;
			GroupType = groupType;
			GroupNo = $"{GroupType.ToString()[0]}{GroupType.ToString()[1]}{_no}";
		}
	}
}

