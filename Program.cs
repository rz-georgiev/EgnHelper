using System;

namespace EgnHelper
{
    internal class Program
    {
        private static IEgnHelper _egnHelper;

        private static void Main(string[] args)
        {
            // Sample using of the GetEgnData method, using a valid, but still a fake egn
            _egnHelper = new EgnHelper();
            var data = _egnHelper.GetEgnData("6101057509");

            Console.WriteLine($"Gender: {data.Gender}");
            Console.WriteLine($"Current age: {data.CurrentAge}");
            Console.WriteLine($"Birth date: {data.BirthDate:dd.MM.yyyy}");
            Console.WriteLine($"Region: {data.Region}");
            Console.WriteLine($"Born count before this human: {data.BornCountBeforeThisHuman}");
            Console.WriteLine($"Egn status: {data.Status}");
        }
    }
}