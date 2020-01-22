// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExampleCollections
{
    internal class ClassArrayByte
    {
        public byte[] FillByParallel(int size, byte byteFilling)
        {
            var byteArray = new byte[size];
            Parallel.For(0, size, i => byteArray[i] = byteFilling);
            return byteArray;
        }

        public byte[] FillByFor(int size, byte byteFilling)
        {
            var bytes = new byte[size];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = byteFilling;
            }
            return bytes;
        }

        public byte[] FillByEnumerableRepeat(int size, byte byteFilling)
        {
            return Enumerable.Repeat(byteFilling, size).ToArray();
        }

        public byte[] FillByEncodingGetBytes(int size, byte byteFilling)
        {
            return Encoding.ASCII.GetBytes(new string((char)byteFilling, size));
        }

        [DllImport("msvcrt.dll", EntryPoint = "memset", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        private static extern IntPtr MemSet(IntPtr dest, int c, int count);

        public byte[] FillByMemSet(int size, byte byteFilling)
        {
            byte[] arrayBytes = new byte[size];
            GCHandle gch = GCHandle.Alloc(arrayBytes, GCHandleType.Pinned);
            MemSet(gch.AddrOfPinnedObject(), byteFilling, arrayBytes.Length);
            return arrayBytes;
        }

        public enum FillType
        {
            Parallel,
            For,
            EnumerableRepeat,
            EncodingGetBytes,
            MemSet
        }
    }

    internal class Week : IEnumerable
    {
        private readonly string[] _days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        public IEnumerator GetEnumerator() => _days.GetEnumerator();
    }

    internal class Node
    {
        Node Next { get; set; } = null;
        int Data { get; set; }

        public Node(int data)
        {
            Data = data;
        }

        public void AppendToTail(int data)
        {
            Node end = new Node(data);
            Node n = this;
            while (n.Next != null)
                n = n.Next;
            n.Next = end;
        }

        public List<int> GetItemsValues()
        {
            List<int> values = new List<int>();
            Node n = this;
            values.Add(n.Data);
            while (n.Next != null)
            {
                n = n.Next;
                values.Add(n.Data);
            }
            return values;
        }
    }
}
