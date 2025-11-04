using Personalregister.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Personalregister.UI
{
	internal static class IO
	{
		public static Employee CreateEmployee()
		{
			Console.Write("Please enter your first name: ");
			string firstName = Console.ReadLine();

			Console.Write("Please enter your last name: ");
			string lastName = Console.ReadLine();

			Console.Write("Please enter your salary: ");
			double salary = Convert.ToDouble(Console.ReadLine());

			return new Employee() { FirstName = firstName, LastName = lastName, Salary = salary };
		}

		public static void OutputEmployees(List<Employee> employees)
		{
			if (employees.Count < 1)
				return;

			// Adjusts the table headers length depending on content length
			int longestName = FindLongestName(employees);
			int longestSalary = FindLongestSalary(employees);

			string tableHeaderName = longestName > 10 ? ("---Name---" + new string('-', (FindLongestName(employees)-10))) : "---Name---";
			string tableHeaderSalary = longestSalary > 10 ? ("--Salary--" + new string('-', (FindLongestName(employees) - 10))) : "--Salary--";

			// Writes the table headers like so: "---Name----|--Salary--"
			Console.WriteLine(tableHeaderName + "-|-" + tableHeaderSalary);

			// Writes the table rows, ex: "Erik Siljeström   |   28000"
			foreach(var emp in employees)
			{
				Console.Write(longestName > emp.Name.Length ? (emp.Name + new string(' ', (longestName - emp.Name.Length))) : emp.Name);
				Console.Write(" | ");
				Console.WriteLine(longestSalary > emp.Salary.ToString().Length ? (emp.Salary + new string(' ', (longestName - emp.Salary.ToString().Length))) : emp.Salary);

			}
			Console.WriteLine();
		}

		private static int FindLongestName(List<Employee> employees) 
		{
			int length = 0;
			foreach (var emp in employees)
			{
				if (emp.Name.Length > length)
					length = emp.Name.Length;
			}
			return length;
		}

		private static int FindLongestSalary(List<Employee> employees)
		{
			int length = 0;
			foreach (var emp in employees)
			{
				int salaryLength = emp.Salary.ToString().Length;

				if (salaryLength > length)
					length = salaryLength;
			}
			return length;
		}


	}
}
