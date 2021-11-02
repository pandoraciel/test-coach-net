using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123Hop_
{
    class Program
    {
        static void Main()
        {
            Console.Write("Input : ");
            var isNumeric = int.TryParse(Console.ReadLine(), out int num);

            if (isNumeric)
            {
                if (num< 1 || num > 20)
                {
                    Console.WriteLine("Range Input tidak boleh kecil dari 1 atau lebih dari 20");
                }
                else if(num > 9)
                {
                    Console.WriteLine("Apa?");
                }
                else
                {
                    Console.Write("Output: ");
                    int i=0;
                    while (i < num)
                    {
                        for (int j = 1; j <= num; j++)
                        {
                            if (j == num)
                            {
                                Console.Write("hops! ");
                            }
                            else
                            {
                                Console.Write(j + " ");
                            }
                        }
                        i++;
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Inputan harus angka!");
            }

            Console.WriteLine();
            Main();
        }
    }
}
