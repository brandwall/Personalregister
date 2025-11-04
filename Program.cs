using Personalregister.UI;
using Personalregister.Entities;

namespace Personalregister
{
    internal class Program
    {
        static void Main(string[] args)
        {
			var list = new List<Employee>();

			while (true)
            {
                try
                {
                    
                    IO.OutputEmployees(list);

					var employee = IO.CreateEmployee();

					list.Add(employee);
                    Console.Clear();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Try again. ");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
		}
    }
}
