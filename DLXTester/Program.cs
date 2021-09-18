using System;
using DLX;

namespace DLXTester {
    class Program {
        private static void Main() {
            var obj = new FourLinkedList();
            var args = new[,] {
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
