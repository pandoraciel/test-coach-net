using System;
using System.Linq;

namespace KamusPanda
{
    class Program
    {
        static void Main()
        {
            Console.Write("Input : ");
            var input = Convert.ToString(Console.ReadLine()).Trim();
            var len = input.Length;
            Console.Write("Output : ");

            if(len == 0)
            {
                Console.Write("Input tidak boleh kosong");
            }
            else if(len == 1)
            {
                Console.Write(len);
            }
            else
            {
                var vs = new char[len];
                int total = 0;
                for (int i = 0; i < len; i++)
                {
                    if (vs.Contains(input[i]))
                    {
                        //total tidak bertambah
                    }
                    else
                    {
                        vs[i] = input[i];
                        total += 1;
                    }
                }
                Console.Write(total);
            }

            Console.WriteLine();
            Console.WriteLine();

            Main();
        }
    }
}
