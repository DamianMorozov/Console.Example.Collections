// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;

namespace ExampleCollections
{
    internal class Program
    {
        #region Main methods

        private static void Main()
        {
            var numberMenu = -1;
            while (numberMenu != 0)
            {
                PrintCaption();
                try
                {
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
        }

        private static void PrintCaption()
        {
            Console.Clear();
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Examples of collections                    ---");
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine("0. Exit from console.");
            Console.WriteLine("1. System.Collections.");
            Console.WriteLine("   10. ArrayList.");
            Console.WriteLine("   11. BitArray (not working yet).");
            Console.WriteLine("   12. CaseInsensitiveComparer (not working yet).");
            Console.WriteLine("   13. CaseInsensitiveHashCodeProvider (not working yet).");
            Console.WriteLine("   14. DictionaryBase (not working yet).");
            Console.WriteLine("   15. Hashtable.");
            Console.WriteLine("   16. Queue.");
            Console.WriteLine("   17. SortedList.");
            Console.WriteLine("   18. Stack.");
            Console.WriteLine("2. System.Collections.Generic.");
            Console.WriteLine("   20. Dictionary<TKey, TValue>.");
            Console.WriteLine("   21. LinkedList<T>.");
            Console.WriteLine("   22. List<T>.");
            Console.WriteLine("   23. SortedDictionary<TKey, TValue>.");
            Console.WriteLine("3. System.Collections.Specialized.");
            Console.WriteLine("   30. ObservableCollection<T>.");
            Console.WriteLine("4. System.Collections.Concurrent (not working yet).");
            Console.WriteLine("5. My classes.");
            Console.WriteLine("   50. Filling byte arrays.");
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.Write("Type switch: ");
        }

        private static void PrintSwitch(int numberMenu)
        {
            Console.Clear();
            var isPrintMenu = false;
            switch (numberMenu)
            {
                #region System.Collections
                case 10:
                    isPrintMenu = true;
                    PrintArrayList();
                    break;
                case 11:
                    //isPrintMenu = true;
                    //PrintBitArray();
                    break;
                case 12:
                    //isPrintMenu = true;
                    //PrintCaseInsensitiveComparer();
                    break;
                case 13:
                    //isPrintMenu = true;
                    //PrintCaseInsensitiveHashCodeProvider();
                    break;
                case 14:
                    //isPrintMenu = true;
                    //PrintDictionaryBase();
                    break;
                case 15:
                    isPrintMenu = true;
                    PrintHashtable();
                    break;
                case 16:
                    isPrintMenu = true;
                    PrintQueue();
                    break;
                case 17:
                    isPrintMenu = true;
                    PrintSortedList();
                    break;
                case 18:
                    isPrintMenu = true;
                    PrintStack();
                    break;
                #endregion
                #region System.Collections.Generic
                case 20:
                    isPrintMenu = true;
                    PrintDictionary();
                    break;
                case 21:
                    isPrintMenu = true;
                    PrintLinkedList();
                    break;
                case 22:
                    isPrintMenu = true;
                    PrintList();
                    break;
                case 23:
                    isPrintMenu = true;
                    PrintSortedDictionary();
                    break;
                #endregion
                #region System.Collections.Specialized
                case 30:
                    isPrintMenu = true;
                    PrintObservableCollection();
                    break;
                #endregion
                #region System.Collections.Concurrent
                //
                #endregion
                #region My classes
                case 50:
                    isPrintMenu = true;
                    PrintByteArraysFilling();
                    break;
                #endregion
            }
            if (isPrintMenu)
            {
                Console.WriteLine(@"----------------------------------------------------------------------");
                Console.Write("Type any key to return in main menu.");
                Console.ReadKey();
            }
        }

        private static void PrintAllItems(ICollection items)
        {
            Console.WriteLine(@"// Print all items.");
            //Console.WriteLine($"foreach (var item in {nameof(items)})");
            foreach (var item in items)
            {
                Console.Write($"{item} | ");
            }
            Console.WriteLine();
            Console.WriteLine($"{nameof(items)}.Count: {items.Count}");
        }

        #endregion

        #region System.Collections

        private static void PrintArrayList()
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

        private static void PrintHashtable()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Example of Hashtable                       ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var hashtable = new Hashtable();
            Console.WriteLine("var hashtable = new Hashtable();");
            hashtable.Add("001", ".NET");
            Console.WriteLine("hashtable.Add(\"001\", \".NET\");");
            hashtable.Add("002", "C#");
            Console.WriteLine("hashtable.Add(\"002\", \"C#\");");
            hashtable.Add("003", "ASP.NET");
            Console.WriteLine("hashtable.Add(\"003\", \"ASP.NET\");");
            Console.WriteLine($"hashtable.ContainsKey(\"003\"): {hashtable.ContainsKey("003")}");
            Console.WriteLine($"hashtable.ContainsValue(\"C#\"): {hashtable.ContainsValue("C#")}");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var keys = hashtable.Keys;
            Console.WriteLine("var keys = hashtable.Keys;");
            foreach (var key in keys)
            {
                Console.Write(key + " | ");
            }
            Console.WriteLine();
            Console.WriteLine(@"----------------------------------------------------------------------");

            var values = hashtable.Values;
            Console.WriteLine("var values = hashtable.Values;");
            foreach (var value in values)
            {
                Console.Write(value + " | ");
            }
            Console.WriteLine();
        }

        private static void PrintQueue()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Example of Queue                           ---");
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"Queue queue - FIFO collection (First Input First Output).");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Queue queue = new Queue();
            Console.WriteLine($"Queue {nameof(queue)} = new Queue();");
            Console.WriteLine("for (int i = 1; i <= 10; i++)");
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

        private static void PrintSortedList()
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

        private static void PrintStack()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Example of Stack                           ---");
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"Stack<T> - LIFO collection (Last Input First Output).");
            Console.WriteLine(@"Push - adds an element to first place.");
            Console.WriteLine(@"Pop - retrieves and returns the first item.");
            Console.WriteLine(@"Peek - returns the first item without removing it.");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Create new stack.");
            Stack stack = new Stack();
            Console.WriteLine($"Stack {nameof(stack)} = new Stack();");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Push items.");
            for (int i = 1; i <= 5; i++)
            {
                stack.Push(i);
                Console.WriteLine($"{nameof(stack)}.Push({i});");
            }
            for (int i = 6; i <= 10; i++)
            {
                stack.Push("Item " + i.ToString());
                Console.WriteLine($"{nameof(stack)}.Push(\"Item \" + {i}.ToString());");
            }
            Console.WriteLine(@"----------------------------------------------------------------------");

            PrintAllItems(stack);
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Contains item.");
            Console.WriteLine($"{nameof(stack)}.Contains(1): {stack.Contains(1)}");
            Console.WriteLine($"{nameof(stack)}.Contains(10): {stack.Contains(10)}");
            Console.WriteLine($"{nameof(stack)}.Contains(\"Item 10\"): {stack.Contains("Item 10")}");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Pop items.");
            var itemPop = stack.Pop();
            Console.WriteLine($"var itemPop = {nameof(stack)}.Pop();");
            Console.WriteLine($"item: {itemPop}");

            PrintAllItems(stack);
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Peek items.");
            var itemPeek = stack.Peek();
            Console.WriteLine($"var itemPeek = {nameof(stack)}.Peek();");
            Console.WriteLine($"item: {itemPeek}");

            PrintAllItems(stack);
        }

        private static void PrintBitArray()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Example of BitArray                        ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            BitArray bitArray = new BitArray(10);
        }

        #endregion

        #region System.Collections.Generic

        private static void PrintDictionary()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---            Example of Dictionary<TKey, TValue>                 ---");
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"Dictionary<int, string> - LIFO collection (Last Input First Output).");
            Console.WriteLine(@"Add - adds an element to first place.");
            Console.WriteLine(@"Pop - retrieves and returns the first item.");
            Console.WriteLine(@"Peek - returns the first item without removing it.");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            Console.WriteLine($"Dictionary<int, string> {nameof(dictionary)} = new Dictionary<int, string>();");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Add items.");
            for (int i = 1; i < 6; i++)
            {
                dictionary.Add(i, "Example " + i.ToString());
                Console.WriteLine($"{nameof(dictionary)}.Add({i}, \"Example \" + {i}.ToString());");
            }
            Console.WriteLine(@"----------------------------------------------------------------------");

            PrintAllItems(dictionary);
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Remove items.");
            dictionary.Remove(2);
            Console.WriteLine($@"{nameof(dictionary)}.Remove(2);");
            dictionary.Remove(4);
            Console.WriteLine($@"{nameof(dictionary)}.Remove(4);");
            Console.WriteLine(@"----------------------------------------------------------------------");

            PrintAllItems(dictionary);
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Init Dictionary in C# 5.");
            Dictionary<string, string> dictionaryCountry5 = new Dictionary<string, string>()
            { { "Russia", "Moscow"}, { "France", "Paris"}, { "Germany", "Berlin"} };
            Console.WriteLine($"Dictionary<string, string> {nameof(dictionaryCountry5)} = new Dictionary<string, string>()");
            Console.WriteLine("{ { \"Russia\", \"Moscow\"}, { \"France\", \"Paris\"}, { \"Germany\", \"Berlin\"} };");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Init Dictionary in C# 6.");
            Dictionary<string, string> dictionaryCountry6 = new Dictionary<string, string>()
            { ["Russia"] = "Moscow", ["France"] = "Paris", ["Germany"] = "Berlin" };
            Console.WriteLine($"Dictionary<string, string> {nameof(dictionaryCountry6)} = new Dictionary<string, string>()");
            Console.WriteLine("{ [\"Russia\"] = \"Moscow\", [\"France\"] = \"Paris\", [\"Germany\"] = \"Berlin\" };");
            Console.WriteLine(@"----------------------------------------------------------------------");
        }

        private static void PrintLinkedList()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                  Example of LinkedList<T>                      ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            string[] words = { "the", "fox", "jumps", "over", "the", "dog" };
            Console.WriteLine("string[] words = { \"the\",\"fox\", \"jumps\", \"over\", \"the\", \"dog\" };");
            LinkedList<string> linkedList = new LinkedList<string>(words);
            Console.WriteLine($"LinkedList<string> {nameof(linkedList)} = new LinkedList<string>();");
            Console.WriteLine(@"----------------------------------------------------------------------");

            PrintAllItems(linkedList);
            Console.WriteLine(@"----------------------------------------------------------------------");

            linkedList.AddFirst("Example start");
            Console.WriteLine($"{nameof(linkedList)}.linkedList.AddFirst(\"Example start\");");
            linkedList.AddAfter(linkedList.FindLast("the"), "Example after the");
            Console.WriteLine($"{nameof(linkedList)}.linkedList.AddFirst(\"Example after the\");");
            linkedList.AddLast("Example end");
            Console.WriteLine($"{nameof(linkedList)}.linkedList.AddLast(\"Example end\");");
            Console.WriteLine(@"----------------------------------------------------------------------");

            PrintAllItems(linkedList);
        }

        private static void PrintList()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Example of List<T>                         ---");
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

            PrintAllItems(list);
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Contains item.");
            Console.WriteLine($"{nameof(list)}.Contains(\"Example 2\"): " + list.Contains("Example 2"));
            Console.WriteLine($"{nameof(list)}.Contains(\"Example 33\"): " + list.Contains("Example 33"));
            Console.WriteLine($"{nameof(list)}[1]: " + list[1]);
            list.RemoveAt(1);
            Console.WriteLine($"{nameof(list)}.RemoveAt(1);");
            Console.WriteLine($"{nameof(list)}[1]: " + list[1]);
            Console.WriteLine(@"----------------------------------------------------------------------");

            PrintAllItems(list);
        }

        private static void PrintSortedDictionary()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---          Example of SortedDictionary<TKey, TValue>             ---");
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
            Console.WriteLine(@"----------------------------------------------------------------------");

            PrintAllItems(sortedDictionary);
            Console.WriteLine(@"----------------------------------------------------------------------");

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
            Console.WriteLine("sortedDictionary.ContainsKey(\"rtf\"): " + sortedDictionary.ContainsKey("rtf"));
            Console.WriteLine(@"----------------------------------------------------------------------");

            PrintAllItems(sortedDictionary);
            Console.WriteLine(@"----------------------------------------------------------------------");

            ICollection keys = sortedDictionary.Keys;
            Console.WriteLine($"ICollection {nameof(keys)} = {nameof(sortedDictionary)}.Keys;");
            PrintAllItems(keys);
            Console.WriteLine(@"----------------------------------------------------------------------");

            ICollection values = sortedDictionary.Values;
            Console.WriteLine($"ICollection {nameof(values)} = {nameof(sortedDictionary)}.Values;");
            PrintAllItems(values);
        }

        #endregion

        #region System.Collections.Specialized

        private static void PrintObservableCollection()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---             Example of ObservableCollection<T>                 ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Create new ObservableCollection.");
            ObservableCollection<object> observableCollection = new ObservableCollection<object>();
            Console.WriteLine($"ObservableCollection<object> {nameof(observableCollection)} = new ObservableCollection<object>();");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Add items.");
            for (int i = 1; i <= 5; i++)
            {
                observableCollection.Add("Item " + i);
                Console.WriteLine($"{nameof(observableCollection)}.observableCollection.Add(\"Item {i}\");");
            }
            Console.WriteLine(@"----------------------------------------------------------------------");

            observableCollection.CollectionChanged += observableCollection_CollectionChanged;
            Console.WriteLine($@"{nameof(observableCollection)}.CollectionChanged += observableCollection_CollectionChanged;");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Add item.");
            Console.WriteLine($"{nameof(observableCollection)}.observableCollection.Add(\"Item new\");");
            observableCollection.Add("Item new");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Remove item.");
            Console.WriteLine($"{nameof(observableCollection)}.observableCollection.Remove(\"Item 2\");");
            observableCollection.Remove("Item 2");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Replace item.");
            Console.WriteLine($"{nameof(observableCollection)}[3] = \"Item 3 new\";");
            observableCollection[3] = "Item 3 new";
        }

        private static void observableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    object newObject = e.NewItems[0] as object;
                    Console.WriteLine($"- The item \"{newObject}\" was added.");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    object oldObject = e.OldItems[0] as object;
                    Console.WriteLine($"- The item \"{oldObject}\" was removed.");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    object newObject1 = e.NewItems[0] as object;
                    object oldObject1 = e.OldItems[0] as object;
                    Console.WriteLine($"- The item \"{oldObject1}\" was replaced \"{newObject1}\".");
                    break;
            }
        }

        #endregion

        #region System.Collections.Concurrent

        #endregion

        #region My classes

        private static void PrintByteArraysFilling()
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
