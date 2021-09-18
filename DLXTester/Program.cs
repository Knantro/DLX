using System;
using DLX;

namespace DLXTester {
    class Program {
        static void Main() {
            FourLinkedList obj = new FourLinkedList();
            int[,] args = new int[,] {
                {0, 1, 1, 0, 1 },
                {1, 0, 1, 0, 0 },
                {0, 0, 0, 1, 1 },
                {0, 1, 1, 1, 1 },
                {1, 0, 0, 1, 0 }
            };
            obj.BuildList(args);
            obj.Describe();
        }
    }
}
