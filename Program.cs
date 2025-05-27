namespace _20250515_DelegatesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k = 10;

            int k2 = Common.Sqr(k);
            

            int k3 = k.Sqr();

            int k4 = k.Sqr().Sqr();    // Common.Sqr(Common.Sqr(k));

            #region Standard delegates

            double[] source = new double[] { -2.4, 1.5, -8.1 };

            Array.ForEach(source, Do);


            double s1 = 0.0;
            Array.ForEach(source, 
                delegate(double item)
                { 
                    s1 += item;
                }
                );

            double s2 = 0.0;
            Array.ForEach(source,
                (double item) =>
                {
                    s2 += item;
                }
                );

            double s3 = 0.0;
            Array.ForEach(source,
                item =>
                {
                    s3 += item;
                }
                );

            double s4 = 0.0;
            Array.ForEach(source,
                    item => s4 += item
                );

            #endregion

            Publisher p1 = new Publisher(4);

            p1.Run();           

            Console.WriteLine("------------------------------------------");

            Console.ForegroundColor = ConsoleColor.Green;
            #region Subscribe with static methods
            
            p1.Started += DoHandler1;   //p1.Subscribe(DoHandler1);

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

            p1.Started += delegate (object sender, IterationEventArgs args)
            {
                ConsoleColor oldColor = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\t\t\tNoNameMethod({args.IterationNumber})");

                Console.ForegroundColor = oldColor;
            };

            p1.Started += (object sender, IterationEventArgs args) =>
            {
                ConsoleColor oldColor = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\t\t\t\tLambda({args.IterationNumber})");

                Console.ForegroundColor = oldColor;
            };

            #endregion

            p1.Run();
        }
        
        private static void DoHandler1(object sender, IterationEventArgs args)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\tDoHandler1({args.IterationNumber})");

            Console.ForegroundColor = oldColor;
        }

        private static void DoHandler2(object sender, IterationEventArgs args)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\t\tDoHandler2({args.IterationNumber})");

            Console.ForegroundColor = oldColor;
        }

        public static void Do(double item)
        {
            Console.WriteLine(item);
        }
    }
}
