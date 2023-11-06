using System.Threading.Channels;

namespace Mi_Labs_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TaskScheduler<string, int> scheduler = new();
            scheduler.AddTask("Task 1", 1);
            scheduler.AddTask("Task 2", 2);
            scheduler.AddTask("Task 3", 3);
            scheduler.AddTask("Task 4", 4);


            scheduler.ExecuteNext(bebra =>
            {
                ReadOnlySpan<char> bebraSpan = bebra.AsSpan();
                Console.WriteLine($"Executing task {bebraSpan.ToString()}");
            });

            scheduler.ExecuteNext(Console.WriteLine);
            scheduler.ExecuteNext(Console.WriteLine);
            scheduler.ExecuteNext(Console.WriteLine);
            scheduler.ExecuteNext(Console.WriteLine);

            scheduler.ExecuteNext(Console.WriteLine);

            Console.ReadKey();
        }
    }
}