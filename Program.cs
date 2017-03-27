using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericGraph_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<string, string> f = new Graph<string, string>();
            f.NewVertex("Василий");
            f.NewVertex("Дормидон");
            f.NewVertex("Пафнутий");
            f.NewVertex("Натаха");
            f.NewVertex("Иван");
            f.NewEdge(0, 1, "Друг");
            f.NewEdge(1, 0, "Друг");
            f.NewEdge(1, 2, "Друг");
            f.NewEdge(2, 1, "Друг");
            f.NewEdge(2, 3, "Друг");
            f.NewEdge(3, 2, "Друг");
            f.NewEdge(3, 4, "Друг");
            f.NewEdge(4, 3, "Друг");

            Console.WriteLine("Обход в глубину:");
            f.PreDepth(0, new Action<string>(x => Console.WriteLine(x)));
            Console.WriteLine("Press ENTER to continue..."); Console.ReadKey();

            Console.WriteLine("Обход в ширину:");
            f.Width(0, new Action<string>(x => Console.WriteLine(x)));
            Console.WriteLine("Press ENTER to continue..."); Console.ReadKey();

            Console.WriteLine("Узлы и дуги:");
            Console.WriteLine(f.ToString());
            Console.WriteLine("Press ENTER to continue..."); Console.ReadKey();

            Console.WriteLine("Найти id узла по его имени: ");
            Console.WriteLine(f.ReturnId(Console.ReadLine()));
            Console.WriteLine();
            Console.WriteLine("Найти узел по его id: ");
            Console.WriteLine(f.ReturnVert(Convert.ToInt32(Console.ReadLine())));



            //Graph<int, int> g = new Graph<int, int>();
            //g.NewVertex(0);
            //g.NewVertex(1);
            //g.NewVertex(2);
            //g.NewVertex(3);
            //g.NewEdge(0, 1, 1);
            //g.NewEdge(1, 2, 1);
            //g.NewEdge(2, 0, 1);
            //g.NewEdge(2, 3, 1);
            //
            //
            //Console.WriteLine(g.ToString());
            //g.DeleteEdge(2, 3);
            //g.DeleteVertex(3);
            //Console.WriteLine(g.ToString());
            Console.WriteLine("\nPress ENTER to EXIT..."); Console.ReadKey();
        }
    }
}
