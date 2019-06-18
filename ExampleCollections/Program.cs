// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections;
using System.Diagnostics;

namespace ExampleCollections
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Examples of collections                    ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var numberMenu = -1;
            while (numberMenu != 0)
            {
                PrintCaption();
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
                Console.WriteLine();
                PrintSwitch(numberMenu);
            }
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        private static void PrintCaption()
        {
            Console.WriteLine();
            Console.WriteLine(" 0. Exit.");
            Console.WriteLine(" 1. ArrayList.");
            Console.WriteLine(" 2. Stack.");
            Console.WriteLine(" 3. Queue (not working yet).");
            Console.WriteLine(" 4. Hashtable (not working yet).");
            Console.WriteLine(" 5. SortedList (not working yet).");
            Console.WriteLine(" 6. BitArray (not working yet).");
            Console.WriteLine("10. Filling byte arrays.");
        }

        private static void PrintSwitch(int numberMenu)
        {
            Console.WriteLine();
            switch (numberMenu)
            {
                case 1:
                    PrintSwitch1();
                    break;
                case 2:
                    PrintSwitch2();
                    break;
                case 3:
                    PrintSwitch3();
                    break;
                case 4:
                    PrintSwitch4();
                    break;
                case 5:
                    PrintSwitch5();
                    break;
                case 6:
                    PrintSwitch6();
                    break;
                case 10:
                    PrintSwitch10();
                    break;
            }
            Console.WriteLine(@"----------------------------------------------------------------------");
        }

        private static void PrintSwitch1()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Example of ArrayList                       ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            ArrayList arrayList = new ArrayList();
            Console.WriteLine($"ArrayList {nameof(arrayList)} = new ArrayList();");
            arrayList.Add(1);
            Console.WriteLine($"{nameof(arrayList)}.Add(1);");
            arrayList.Add("Example");
            Console.WriteLine($"{nameof(arrayList)}.Add(\"Example\");");
            arrayList.Add(true);
            Console.WriteLine($"{nameof(arrayList)}.Add(true);");
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine($"{nameof(arrayList)}.Count: " + arrayList.Count);
            Console.WriteLine($"{nameof(arrayList)}.Contains(1): " + arrayList.Contains(1));
            Console.WriteLine($"{nameof(arrayList)}.Contains(2): " + arrayList.Contains(2));
            Console.WriteLine($"{nameof(arrayList)}.Contains(\"Example\"): " + arrayList.Contains("Example"));
            Console.WriteLine($"{nameof(arrayList)}.Contains(\"Example2\"): " + arrayList.Contains("Example2"));
            Console.WriteLine($"{nameof(arrayList)}[1]: " + arrayList[1]);
            arrayList.RemoveAt(1);
            Console.WriteLine($"{nameof(arrayList)}.RemoveAt(1);");
            Console.WriteLine($"{nameof(arrayList)}[1]: " + arrayList[1]);
        }

        private static void PrintSwitch2()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Example of Stack                           ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Stack stack = new Stack();
            Console.WriteLine($"Stack {nameof(stack)} = new Stack();");
            for (int i = 1; i <= 10; i++)
            {
                stack.Push(i);
                Console.WriteLine($"{nameof(stack)}.Push({i});");
            }
            Console.WriteLine($"{nameof(stack)}.Count: {stack.Count}");

            stack.Pop();
            Console.WriteLine($"{nameof(stack)}.Pop();");

            Console.WriteLine($"{nameof(stack)}.Count: {stack.Count}");

            Console.WriteLine($"{nameof(stack)}.stack.Contains(5): {stack.Contains(5)}");
        }

        private static void PrintSwitch3()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Example of Queue                           ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Queue queue = new Queue();
        }

        private static void PrintSwitch4()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Example of Hashtable                       ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Hashtable hashtable = new Hashtable();
        }

        private static void PrintSwitch5()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Example of SortedList                      ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            SortedList sortedList = new SortedList();
        }

        private static void PrintSwitch6()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Example of BitArray                        ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            BitArray bitArray = new BitArray(10);
        }

        private static void PrintSwitch10()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                Examples of filling byte arrays                 ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var arrayByte = new ClassArrayByte();
            FillByTypeAll(arrayByte, 1_024, "1 KB", 0x_00);
            FillByTypeAll(arrayByte, 1_024 * 1_024, "1 MB", 0x_00);
            FillByTypeAll(arrayByte, 1_024 * 1_024 * 10, "10 MB", 0x_00);
            FillByTypeAll(arrayByte, 1_024 * 1_024 * 100, "100 MB", 0x_00);
        }

        private static void FillByTypeAll(ClassArrayByte arrayByte, int size, string strSize, byte byteFilling)
        {
            Console.WriteLine();
            Console.WriteLine(@"------------------------------------+---------------------------------");
            FillByType(ClassArrayByte.FillType.Parallel, arrayByte, size, strSize, byteFilling);
            FillByType(ClassArrayByte.FillType.For, arrayByte, size, strSize, byteFilling);
            FillByType(ClassArrayByte.FillType.EnumerableRepeat, arrayByte, size, strSize, byteFilling);
            FillByType(ClassArrayByte.FillType.EncodingGetBytes, arrayByte, size, strSize, byteFilling);
            FillByType(ClassArrayByte.FillType.MemSet, arrayByte, size, strSize, byteFilling);

        }

        private static void FillByType(ClassArrayByte.FillType fillType, ClassArrayByte arrayByte,
            int size, string strSize, byte byteFilling)
        {
            var stopWatch = Stopwatch.StartNew();
            byte[] bytes;
            switch (fillType)
            {
                case ClassArrayByte.FillType.Parallel:
                    Console.Write(string.Format("{0,-35}", $@"FillByParallel({strSize}, {byteFilling});"));
                    bytes = arrayByte.FillByParallel(size, byteFilling);
                    break;
                case ClassArrayByte.FillType.For:
                    Console.Write(string.Format("{0,-35}", $@"FillByFor({strSize}, {byteFilling});"));
                    bytes = arrayByte.FillByFor(size, byteFilling);
                    break;
                case ClassArrayByte.FillType.EnumerableRepeat:
                    Console.Write(string.Format("{0,-35}", $@"FillByEnumerableRepeat({strSize}, {byteFilling});"));
                    bytes = arrayByte.FillByEnumerableRepeat(size, byteFilling);
                    break;
                case ClassArrayByte.FillType.EncodingGetBytes:
                    Console.Write(string.Format("{0,-35}", $@"FillByParallel({strSize}, {byteFilling});"));
                    bytes = arrayByte.FillByEncodingGetBytes(size, byteFilling);
                    break;
                case ClassArrayByte.FillType.MemSet:
                    Console.Write(string.Format("{0,-35}", $@"FillByMemSet({strSize}, {byteFilling});"));
                    bytes = arrayByte.FillByMemSet(size, byteFilling);
                    break;
            }
            stopWatch.Stop();
            Console.WriteLine($@" | Elapsed time: {stopWatch.Elapsed}");
            Console.WriteLine(@"------------------------------------+---------------------------------");
        }
    }
}
