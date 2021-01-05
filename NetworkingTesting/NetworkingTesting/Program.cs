using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkingTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Server.Start(50, 26950);
            Console.ReadKey();
        }
    }
}
