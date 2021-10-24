using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;


namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = File.ReadAllText(args[0], Encoding.UTF8); ;
            Console.WriteLine(args[0]);
            Console.WriteLine(args[1]);
            Console.ReadKey();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            using (var client = new ServiceReference1.Service1Client())
            {
               
                var ordered = client.GetCounter(str);
                var sout = new StringBuilder();
                foreach (KeyValuePair<string, int> kvp in ordered)
                {

                    sout.Append($"{kvp.Key} {kvp.Value}").AppendLine();

                }

                File.WriteAllText("args[1]", sout.ToString(), Encoding.UTF8);

                Console.WriteLine(sout);

            }


            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;


            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            Console.ReadKey();
        }
    }
}
