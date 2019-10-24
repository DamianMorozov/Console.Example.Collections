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
            Console.WriteLine("5. My methods.");
            Console.WriteLine("   50. Filling byte arrays.");
            Console.WriteLine("6. IEnumerable and IEnumerator.");
            Console.WriteLine("   60. IEnumerator.");
            Console.WriteLine("   61. IEnumerable and IEnumerator.");
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
                #region My methods
                case 50:
                    isPrintMenu = true;
                    PrintByteArraysFilling();
                    break;
                #endregion
                #region IEnumerable and IEnumerator
                case 60:
                    isPrintMenu = true;
                    PrintIEnumerator();
                    break;
                case 61:
                    isPrintMenu = true;
                    PrintIEnumerable();
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

        private static void PrintAllItems(IEnumerable items, string name)
        {
            Console.WriteLine($@"// Print all {(string.IsNullOrEmpty(name) ? "items" : name)}.");
            var count = 0;
            foreach (var item in items)
            {
                Console.Write($"{item} | ");
                count++;
            }
            Console.Write($"Count: {count}");
            Console.WriteLine();
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

            PrintAllItems(arrayList, nameof(arrayList));
            Console.WriteLine($"{nameof(arrayList)}.Count: " + arrayList.Count);
            Console.WriteLine($"{nameof(arrayList)}.Contains(1): " + arrayList.Contains(1));
            Console.WriteLine($"{nameof(arrayList)}.Contains(2): " + arrayList.Contains(2));
            Console.WriteLine($"{nameof(arrayList)}.Contains(\"Example\"): " + arrayList.Contains("Example"));
            Console.WriteLine($"{nameof(arrayList)}.Contains(\"Example2\"): " + arrayList.Contains("Example2"));
            Console.WriteLine($"{nameof(arrayList)}[1]: " + arrayList[1]);
            arrayList.RemoveAt(1);
            Console.WriteLine($"{nameof(arrayList)}.RemoveAt(1);");
            Console.WriteLine($"{nameof(arrayList)}[1]: " + arrayList[1]);

            PrintAllItems(arrayList, nameof(arrayList));
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

            PrintAllItems(hashtable.Keys, nameof(hashtable.Keys));
            Console.WriteLine(@"----------------------------------------------------------------------");

            PrintAllItems(hashtable.Values, nameof(hashtable.Values));
        }

        private static void PrintQueue()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Example of Queue                           ---");
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"Queue - FIFO collection (First Input First Output).");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var queue = new Queue();
            Console.WriteLine("var queue = new Queue();");
            Console.WriteLine("for (int i = 1; i <= 10; i++)");
            for (var i = 1; i <= 10; i++)
            {
                queue.Enqueue(i);
                Console.WriteLine($"queue.Enqueue({i});");
            }
            Console.WriteLine($"{nameof(queue)}.Count: {queue.Count}");
            Console.WriteLine($"{nameof(queue)}.stack.Contains(1): {queue.Contains(1)}");

            PrintAllItems(queue, nameof(queue));

            queue.Dequeue();
            Console.WriteLine($"{nameof(queue)}.Dequeue();");

            PrintAllItems(queue, nameof(queue));

            Console.WriteLine($"{nameof(queue)}.Count: {queue.Count}");
            Console.WriteLine($"{nameof(queue)}.stack.Contains(1): {queue.Contains(1)}");
        }

        private static void PrintSortedList()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Example of SortedList                      ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var sortedList = new SortedList();
            Console.WriteLine("var sortedList = new SortedList();");
            for (var i = 10; i > 0; i--)
            {
                sortedList.Add(i, "Value " + i.ToString());
                Console.WriteLine($"{nameof(sortedList)}.Add(i, \"Value " + i.ToString() + "\");");
            }
            Console.WriteLine(@"----------------------------------------------------------------------");

            PrintAllItems(sortedList.Keys, nameof(sortedList.Keys));
            Console.WriteLine(@"----------------------------------------------------------------------");

            PrintAllItems(sortedList.Values, nameof(sortedList.Values));
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
            var stack = new Stack();
            Console.WriteLine("var stack = new Stack();");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Push items.");
            for (var i = 1; i <= 5; i++)
            {
                stack.Push(i);
                Console.WriteLine($"stack.Push({i});");
            }
            Console.WriteLine(@"----------------------------------------------------------------------");
            for (var i = 6; i <= 10; i++)
            {
                stack.Push("Item " + i.ToString());
                Console.WriteLine($"stack.Push(\"Item \" + {i}.ToString());");
            }
            Console.WriteLine(@"----------------------------------------------------------------------");

            PrintAllItems(stack, nameof(stack));
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Contains item.");
            Console.WriteLine($"stack.Contains(1): {stack.Contains(1)}");
            Console.WriteLine($"stack.Contains(10): {stack.Contains(10)}");
            Console.WriteLine($"stack.Contains(\"Item 10\"): {stack.Contains("Item 10")}");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Pop items.");
            var itemPop = stack.Pop();
            Console.WriteLine("var itemPop = stack.Pop();");
            Console.WriteLine($"item: {itemPop}");

            PrintAllItems(stack, nameof(stack));
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Peek items.");
            var itemPeek = stack.Peek();
            Console.WriteLine($"var itemPeek = {nameof(stack)}.Peek();");
            Console.WriteLine($"item: {itemPeek}");

            PrintAllItems(stack, nameof(stack));
        }

        private static void PrintBitArray()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Example of BitArray                        ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var bitArray = new BitArray(10);
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

            PrintAllItems(dictionary, nameof(dictionary));
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Remove items.");
            dictionary.Remove(2);
            Console.WriteLine($@"{nameof(dictionary)}.Remove(2);");
            dictionary.Remove(4);
            Console.WriteLine($@"{nameof(dictionary)}.Remove(4);");
            Console.WriteLine(@"----------------------------------------------------------------------");

            PrintAllItems(dictionary, nameof(dictionary));
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

            PrintAllItems(linkedList, nameof(linkedList));
            Console.WriteLine(@"----------------------------------------------------------------------");

            linkedList.AddFirst("Example start");
            Console.WriteLine($"{nameof(linkedList)}.linkedList.AddFirst(\"Example start\");");
            linkedList.AddAfter(linkedList.FindLast("the"), "Example after the");
            Console.WriteLine($"{nameof(linkedList)}.linkedList.AddFirst(\"Example after the\");");
            linkedList.AddLast("Example end");
            Console.WriteLine($"{nameof(linkedList)}.linkedList.AddLast(\"Example end\");");
            Console.WriteLine(@"----------------------------------------------------------------------");

            PrintAllItems(linkedList, nameof(linkedList));
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

            PrintAllItems(list, nameof(list));
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Contains item.");
            Console.WriteLine($"{nameof(list)}.Contains(\"Example 2\"): " + list.Contains("Example 2"));
            Console.WriteLine($"{nameof(list)}.Contains(\"Example 33\"): " + list.Contains("Example 33"));
            Console.WriteLine($"{nameof(list)}[1]: " + list[1]);
            list.RemoveAt(1);
            Console.WriteLine($"{nameof(list)}.RemoveAt(1);");
            Console.WriteLine($"{nameof(list)}[1]: " + list[1]);
            Console.WriteLine(@"----------------------------------------------------------------------");

            PrintAllItems(list, nameof(list));
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

            PrintAllItems(sortedDictionary, nameof(sortedDictionary));
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

            PrintAllItems(sortedDictionary, nameof(sortedDictionary));
            Console.WriteLine(@"----------------------------------------------------------------------");

            PrintAllItems(sortedDictionary.Keys, nameof(sortedDictionary.Keys));
            Console.WriteLine(@"----------------------------------------------------------------------");

            PrintAllItems(sortedDictionary.Values, nameof(sortedDictionary.Values));
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

        #region My methods

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

        #region IEnumerable and IEnumerator

        private static void PrintIEnumerator()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                  Example of IEnumerator                        ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Create new IEnumerator.");
            int[] numbers = { 2, 14, 26, 38, 40 };
            Console.WriteLine(@"int[] numbers = { 0, 2, 4, 6, 8, 10};");
            var enumerator = numbers.GetEnumerator();
            Console.WriteLine(@"var enumerator = numbers.GetEnumerator();");
            Console.WriteLine(@"----------------------------------------------------------------------");
            PrintAllItems(numbers, nameof(numbers));
            Console.WriteLine(@"----------------------------------------------------------------------");

            while (enumerator.MoveNext())
            {
                Console.WriteLine("while (enumerator.MoveNext())");
                if (enumerator.Current != null)
                {
                    var item = (int)enumerator.Current;
                    Console.WriteLine($"var item = (int)enumerator.Current;  // {item}");
                }
                else
                    Console.WriteLine("if (enumerator.Current != null)");
            }
            Console.WriteLine(@"----------------------------------------------------------------------");

            enumerator.Reset();
            Console.WriteLine("enumerator.Reset();");
            enumerator.MoveNext();
            Console.WriteLine("enumerator.MoveNext();");
            Console.WriteLine($"enumerator.Current: {enumerator.Current}");
        }

        private static void PrintIEnumerable()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                  Example of IEnumerable                        ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"// Create new IEnumerable.");
            var week = new Week();
            Console.WriteLine("var week = new Week();");
            Console.WriteLine(@"----------------------------------------------------------------------");

            PrintAllItems(week, nameof(week));
        }

        #endregion
    }

    internal class Week : IEnumerable
    {
        private readonly string[] _days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        public IEnumerator GetEnumerator() => _days.GetEnumerator();
    }
}