using Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Executer app;
            string chapter, execution;

            if (args.Length == 2)
            {
                chapter = args[0];
                execution = args[1];
            }
            else
            {
                Console.WriteLine("Введите № главы");
                chapter = "Chapter" + Console.ReadLine();
                Console.WriteLine("Введите № задания");
                execution = chapter + ".Ex" + Console.ReadLine();
            }

            try
            {
                Assembly a = Assembly.Load(chapter);
                Type ex = a.GetType(execution);
                if (ex.IsSubclassOf(typeof(Executer)))
                {
                    app = (Executer)Activator.CreateInstance(ex);
                    app.Execute();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
