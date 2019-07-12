// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace ExampleCollections
{
    internal class Program
    {
        #region Main methods

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
            Console.WriteLine("0. Exit.");
            Console.WriteLine("1. System.Collections.");
            Console.WriteLine("   11. ArrayList.");
            Console.WriteLine("   12. Stack.");
            Console.WriteLine("   13. Queue.");
            Console.WriteLine("   14. Hashtable.");
            Console.WriteLine("   15. SortedList.");
            Console.WriteLine("   16. BitArray (not working yet).");
            Console.WriteLine("2. System.Collections.Generic.");
            Console.WriteLine("   21. List<T>.");
            Console.WriteLine("   22. SortedDictionary<T, T>.");
            Console.WriteLine("3. System.Collections.Specialized.");
            Console.WriteLine("4. System.Collections.Concurrent.");
            Console.WriteLine("5. My classes.");
            Console.WriteLine("   51. Filling byte arrays.");
        }

        private static void PrintSwitch(int numberMenu)
        {
            Console.WriteLine();
            switch (numberMenu)
            {
                #region System.Collections
                case 11:
                    PrintSwitchArrayList();
                    break;
                case 12:
                    PrintSwitchStack();
                    break;
                case 13:
                    PrintSwitchQueue();
                    break;
                case 14:
                    PrintSwitchHashtable();
                    break;
                case 15:
                    PrintSwitchSortedList();
                    break;
                case 16:
                    PrintSwitchBitArray();
                    break;
                #endregion
                #region System.Collections.Generic
                case 21:
                    PrintSwitchList();
                    break;
                case 22:
                    PrintSwitchSortedDictionary();
                    break;
                #endregion
                #region System.Collections.Specialized
                //
                #endregion
                #region System.Collections.Concurrent
                //
                #endregion
                #region My classes
                case 51:
                    PrintSwitchByteArraysFilling();
                    break;
                    #endregion
            }
            Console.WriteLine(@"----------------------------------------------------------------------");
        }

        #endregion

        #region System.Collections

        private static void PrintSwitchArrayList()
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

            Console.WriteLine($"foreach (var item in {nameof(arrayList)})");
            foreach (var item in arrayList)
            {
                Console.WriteLine($"  item: {item}");
            }
            Console.WriteLine($"{nameof(arrayList)}.Count: " + arrayList.Count);
            Console.WriteLine($"{nameof(arrayList)}.Contains(1): " + arrayList.Contains(1));
            Console.WriteLine($"{nameof(arrayList)}.Contains(2): " + arrayList.Contains(2));
            Console.WriteLine($"{nameof(arrayList)}.Contains(\"Example\"): " + arrayList.Contains("Example"));
            Console.WriteLine($"{nameof(arrayList)}.Contains(\"Example2\"): " + arrayList.Contains("Example2"));
            Console.WriteLine($"{nameof(arrayList)}[1]: " + arrayList[1]);
            arrayList.RemoveAt(1);
            Console.WriteLine($"{nameof(arrayList)}.RemoveAt(1);");
            Console.WriteLine($"{nameof(arrayList)}[1]: " + arrayList[1]);

            Console.WriteLine($"foreach (var item in {nameof(arrayList)})");
            foreach (var item in arrayList)
            {
                Console.WriteLine($"  item: {item}");
            }
        }

        private static void PrintSwitchStack()
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
            Console.WriteLine($"{nameof(stack)}.stack.Contains(10): {stack.Contains(10)}");

            Console.WriteLine($"foreach (var item in {nameof(stack)})");
            foreach (var item in stack)
            {
                Console.Write($"{item} | ");
            }
            Console.WriteLine();

            stack.Pop();
            Console.WriteLine($"{nameof(stack)}.Pop();");

            Console.WriteLine($"foreach (var item in {nameof(stack)})");
            foreach (var item in stack)
            {
                Console.Write($"{item} | ");
            }
            Console.WriteLine();

            Console.WriteLine($"{nameof(stack)}.Count: {stack.Count}");
            Console.WriteLine($"{nameof(stack)}.stack.Contains(10): {stack.Contains(10)}");
        }

        private static void PrintSwitchQueue()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Example of Queue                           ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Queue queue = new Queue();
            Console.WriteLine($"Queue {nameof(queue)} = new Queue();");
            Console.WriteLine($"for (int i = 1; i <= 10; i++)");
            for (int i = 1; i <= 10; i++)
            {
                queue.Enqueue(i);
                Console.WriteLine($"{nameof(queue)}.Enqueue({i});");
            }
            Console.WriteLine($"{nameof(queue)}.Count: {queue.Count}");
            Console.WriteLine($"{nameof(queue)}.stack.Contains(1): {queue.Contains(1)}");

            Console.WriteLine($"foreach (var item in {nameof(queue)})");
            foreach (var item in queue)
            {
                Console.Write($"{item} | ");
            }
            Console.WriteLine();

            queue.Dequeue();
            Console.WriteLine($"{nameof(queue)}.Dequeue();");

            Console.WriteLine($"foreach (var item in {nameof(queue)})");
            foreach (var item in queue)
            {
                Console.Write($"{item} | ");
            }
            Console.WriteLine();

            Console.WriteLine($"{nameof(queue)}.Count: {queue.Count}");
            Console.WriteLine($"{nameof(queue)}.stack.Contains(1): {queue.Contains(1)}");
        }

        private static void PrintSwitchHashtable()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Example of Hashtable                       ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Hashtable hashtable = new Hashtable();
            Console.WriteLine($"Hashtable {nameof(hashtable)} = new Hashtable();");
            hashtable.Add("001", ".NET");
            Console.WriteLine($"{nameof(hashtable)}.Add(\"001\", \".NET\");");
            hashtable.Add("002", "C#");
            Console.WriteLine($"{nameof(hashtable)}.Add(\"002\", \"C#\");");
            hashtable.Add("003", "ASP.NET");
            Console.WriteLine($"{nameof(hashtable)}.Add(\"003\", \"ASP.NET\");");
            Console.WriteLine($"{nameof(hashtable)}.ContainsKey(\"003\"): " + hashtable.ContainsKey("003"));
            Console.WriteLine($"{nameof(hashtable)}.ContainsValue(\"C#\"): " + hashtable.ContainsValue("C#"));
            Console.WriteLine();

            ICollection keys = hashtable.Keys;
            Console.WriteLine($"ICollection {nameof(keys)} = {nameof(hashtable)}.Keys;");
            foreach (var key in keys)
            {
                Console.Write(key + " | ");
            }
            Console.WriteLine();

            ICollection values = hashtable.Values;
            Console.WriteLine($"ICollection {nameof(values)} = {nameof(hashtable)}.Values;");
            foreach (var value in values)
            {
                Console.Write(value + " | ");
            }
            Console.WriteLine();
        }

        private static void PrintSwitchSortedList()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Example of SortedList                      ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            SortedList sortedList = new SortedList();
            Console.WriteLine($"SortedList {nameof(sortedList)} = new SortedList();");
            for (int i = 10; i > 0; i--)
            {
                sortedList.Add(i, "Value " + i.ToString());
                Console.WriteLine($"{nameof(sortedList)}.Add(i, \"Value " + i.ToString() + "\");");
            }

            ICollection keys = sortedList.Keys;
            Console.WriteLine($"ICollection {nameof(keys)} = {nameof(sortedList)}.Keys;");
            foreach (var key in keys)
            {
                Console.Write(key + " | ");
            }
            Console.WriteLine();

            ICollection values = sortedList.Values;
            Console.WriteLine($"ICollection {nameof(values)} = {nameof(sortedList)}.Values;");
            foreach (var value in values)
            {
                Console.Write(value + " | ");
            }
            Console.WriteLine();
        }

        private static void PrintSwitchBitArray()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Example of BitArray                        ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            BitArray bitArray = new BitArray(10);
        }

        #endregion

        #region System.Collections.Generic

        private static void PrintSwitchList()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Example of BitArray                        ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            List<string> list = new List<string>();
            Console.WriteLine($"List<string> {nameof(list)} = new List<string>();");

            list.Add("Example 1");
            Console.WriteLine($"{nameof(list)}.Add(\"Example 1\");");
            list.Add("Example 3");
            Console.WriteLine($"{nameof(list)}.Add(\"Example 3\");");
            list.Add("Example 2");
            Console.WriteLine($"{nameof(list)}.Add(\"Example 2\");");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine($"foreach (var item in {nameof(list)})");
            foreach (var item in list)
            {
                Console.WriteLine($"  item: {item}");
            }
            Console.WriteLine($"{nameof(list)}.Count: " + list.Count);
            Console.WriteLine($"{nameof(list)}.Contains(\"Example 2\"): " + list.Contains("Example 2"));
            Console.WriteLine($"{nameof(list)}.Contains(\"Example 33\"): " + list.Contains("Example 33"));
            Console.WriteLine($"{nameof(list)}[1]: " + list[1]);
            list.RemoveAt(1);
            Console.WriteLine($"{nameof(list)}.RemoveAt(1);");
            Console.WriteLine($"{nameof(list)}[1]: " + list[1]);

            Console.WriteLine($"foreach (var item in {nameof(list)})");
            foreach (var item in list)
            {
                Console.WriteLine($"  item: {item}");
            }
        }

        private static void PrintSwitchSortedDictionary()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                  Example of SortedDictionary                   ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
            Console.WriteLine($"SortedDictionary<string, string> {nameof(sortedDictionary)} = new SortedDictionary<string, string>();");

            sortedDictionary.Add("txt", "notepad.exe");
            Console.WriteLine($"{nameof(sortedDictionary)}.Add(\"txt\", \"notepad.exe\");");
            sortedDictionary.Add("bmp", "paint.exe");
            Console.WriteLine($"{nameof(sortedDictionary)}.Add(\"bmp\", \"paint.exe\");");
            sortedDictionary.Add("dib", "paint.exe");
            Console.WriteLine($"{nameof(sortedDictionary)}.Add(\"dib\", \"paint.exe\");");
            sortedDictionary.Add("rtf", "wordpad.exe");
            Console.WriteLine($"{nameof(sortedDictionary)}.Add(\"rtf\", \"wordpad.exe\");");
            foreach (KeyValuePair<string, string> item in sortedDictionary)
            {
                Console.WriteLine($"{nameof(sortedDictionary)}[\"" + item.Key + $"\"] = {item.Value}");
            }

            try
            {
                sortedDictionary.Add("txt", "winword.exe");
                Console.WriteLine($"{nameof(sortedDictionary)}.Add(\"txt\", \"winword.exe\");");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with Key = \"txt\" already exists.");
            }

            sortedDictionary["rtf"] = "winword.exe";
            Console.WriteLine($"{nameof(sortedDictionary)}[\"rtf\"] = \"winword.exe\";");

            try
            {
                Console.WriteLine("For key = \"tif\", value = {0}.", sortedDictionary["tif"]);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Key = \"tif\" is not found.");
            }
            Console.WriteLine($"sortedDictionary.ContainsKey(\"rtf\"): " + sortedDictionary.ContainsKey("rtf"));

            foreach (KeyValuePair<string, string> item in sortedDictionary)
            {
                Console.WriteLine($"{nameof(sortedDictionary)}[\"" + item.Key + $"\"] = {item.Value}");
            }

            ICollection keys = sortedDictionary.Keys;
            Console.WriteLine($"ICollection {nameof(keys)} = {nameof(sortedDictionary)}.Keys;");
            foreach (var key in keys)
            {
                Console.Write(key + " | ");
            }
            Console.WriteLine();

            ICollection values = sortedDictionary.Values;
            Console.WriteLine($"ICollection {nameof(values)} = {nameof(sortedDictionary)}.Values;");
            foreach (var value in values)
            {
                Console.Write(value + " | ");
            }
            Console.WriteLine();
        }

        #endregion

        #region System.Collections.Specialized

        #endregion

        #region System.Collections.Concurrent

        #endregion

        #region My classes

        private static void PrintSwitchByteArraysFilling()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                Examples of filling byte arrays                 ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            ClassArrayByte arrayByte = new ClassArrayByte();
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
        
        #endregion
    }
}
