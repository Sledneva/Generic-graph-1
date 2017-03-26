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
            f.NewVertex("Василий");
            f.NewEdge(0, 1, "Друг");
            f.NewEdge(1, 3, "Друг");
            f.NewEdge(2, 3, "Мутит");
            Console.WriteLine(f.ToString());

            Console.WriteLine(f.ReturnId("Дормидон"));
            Console.WriteLine(f.ReturnVert(4));
            //Graph<int, int> g = new Graph<int, int>();
            //g.NewVertex(0);
            //g.NewVertex(1);
            //g.NewVertex(2);
            //g.NewVertex(3);
            //g.NewEdge(0, 1, 1);
            //g.NewEdge(1, 2, 1);
            //g.NewEdge(2, 0, 1);
            //g.NewEdge(2, 3, 1);
            //g.PreDepth(0);
            //g.Width(0);
            //Console.WriteLine(g.ToString());
            //g.DeleteEdge(2, 3);
            //g.DeleteVertex(3);
            //Console.WriteLine(g.ToString());
            Console.ReadKey();
        }
    }
}
