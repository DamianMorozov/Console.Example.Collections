using System;
using System.Collections;
using System.Collections.Generic;

namespace ExampleCollections
{
    internal class Program
    {
        private static void Main()
        {
            PrintCaption();
            var numberMenu = MakeSwitch();
            PrintSwitch(numberMenu);
            Console.ReadLine();
        }

        private static void PrintCaption()
        {
            Console.WriteLine("Switch example.");
            Console.WriteLine("1. ArrayList.");
            Console.WriteLine("2. Stack.");
            Console.WriteLine("3. Queue.");
            Console.WriteLine("4. Hashtable.");
            Console.WriteLine("5. SortedList.");
            Console.WriteLine("6. BitArray.");
        }

        private static int MakeSwitch()
        {
            var numberMenu = 0;
            while (numberMenu <= 0)
            {
                try
                {
                    Console.Write("Type switch: ");
                    numberMenu = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error: " + exception.Message);
                    numberMenu = -1;
                }
            }
            return numberMenu;
        }

        private static void PrintSwitch(int numberMenu)
        {
            Console.WriteLine("------------------------------------------------------------");
            switch (numberMenu)
            {
                case 1:
                    ArrayList arrayList = new ArrayList();
                    Console.WriteLine("ArrayList arrayList = new ArrayList();");
                    arrayList.Add(1);
                    Console.WriteLine("arrayList.Add(1);");
                    arrayList.Add("Example");
                    Console.WriteLine("arrayList.Add(\"Example\");");
                    arrayList.Add(true);
                    Console.WriteLine("arrayList.Add(true);");
                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine("arrayList.Count: " + arrayList.Count);
                    Console.WriteLine("arrayList.Contains(1): " + arrayList.Contains(1));
                    Console.WriteLine("arrayList.Contains(2): " + arrayList.Contains(2));
                    Console.WriteLine("arrayList.Contains(\"Example\"): " + arrayList.Contains("Example"));
                    Console.WriteLine("arrayList.Contains(\"Example2\"): " + arrayList.Contains("Example2"));
                    Console.WriteLine("arrayList[1]: " + arrayList[1]);
                    arrayList.RemoveAt(1);
                    Console.WriteLine("arrayList.RemoveAt(1);");
                    Console.WriteLine("arrayList[1]: " + arrayList[1]);
                    Console.WriteLine("------------------------------------------------------------");
                    break;
                case 2:
                    Stack stack = new Stack();
                    break;
                case 3:
                    Queue queue = new Queue();
                    break;
                case 4:
                    Hashtable hashtable = new Hashtable();
                    break;
                case 5:
                    SortedList sortedList = new SortedList();
                    break;
                case 6:
                    BitArray bitArray = new BitArray(10);
                    break;
            }
            Console.WriteLine("Press enter to exit.");
        }
    }
}
