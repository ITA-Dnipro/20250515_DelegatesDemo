namespace _20250515_DelegatesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Standard delegates

            double[] source = new double[] { -2.4, 1.5, -8.1 };

            Array.ForEach(source, Do);

            #endregion


            Publisher p1 = new Publisher(4);

            p1.Run();

            Console.WriteLine("------------------------------------------");

            Console.ForegroundColor = ConsoleColor.Green;
            #region Subscribe with static methods

            //p1.Subscribe(DoHandler1);
            p1.Started += DoHandler1;

            #endregion

            p1.Run();

            Console.WriteLine("------------------------------------------");

            Console.ForegroundColor = ConsoleColor.Yellow;

            #region Subscribe with static methods

            //p1.Subscribe(DoHandler2);
            p1.Started += DoHandler2;

            #endregion

            p1.Run();

            Console.WriteLine("------------------------------------------");

            Console.ForegroundColor = ConsoleColor.Cyan;

            #region UnSubscribe with static methods

            //p1.UnSubscribe(DoHandler1);
            p1.Started -= DoHandler1;

            #endregion

            p1.Run();
        }

        private static void DoHandler1(int iterationNumber)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\tDoHandler1({iterationNumber})");

            Console.ForegroundColor = oldColor;
        }

        private static void DoHandler2(int iterationNumber)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\t\tDoHandler2({iterationNumber})");

            Console.ForegroundColor = oldColor;
        }

        public static void Do(double item)
        {
            Console.WriteLine(item);
        }
    }
}
