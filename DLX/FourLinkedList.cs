using System;

namespace DLX {
    public class FourLinkedList {
        private readonly Head _root = new Head();

        public void BuildList(int[,] args) {
            BuildColumns(args);
            LinkHeadAndLastNodeInColumns(args.GetLength(1));
            LinkRows(args);
        }

        public void Describe() {
            var curr = (Head)_root.Right;
            var temp = curr.Down;

            while (!curr.Equals(_root)) {
                Console.WriteLine(curr);

                while (!temp.Equals(curr)) {
                    Console.WriteLine(temp);
                    temp = temp.Down;
                }

                curr = (Head)curr.Right;
                temp = curr.Down;
            }
        }

        /// <summary>
        /// Удаление элемента с возможностью восстановления.
        /// </summary>
        /// <param name="node">Элемент, который требуется удалить.</param>
        public void DeleteNode(Node node) {
            node.Left.Right = node.Right;
            node.Right.Left = node.Left;
        }

        /// <summary>
        /// Восстановление элемента.
        /// </summary>
        /// <param name="node">Элемент, который требуется восстановить.</param>
        public void RestoreNode(Node node) {
            node.Left.Right = node;
            node.Right.Left = node;
        }

        private void BuildColumns(int[,] args) {
            for (var j = 0; j < args.GetLength(1); j++) {
                var head = new Head {
                    ColumnNumber = j + 1,
                    Left = GetHeadFromRoot(_root)
                };
                
                head.Left.Right = head;
                for (var i = 0; i < args.GetLength(0); i++) {
                    if (args[i, j] == 1) {
                        var node = new Node {
                            Header = head,
                            Up = GetNodeInColumn(head),
                            RowNumber = i + 1
                        };
                        head.RowCount++;
                        node.Up.Down = node;
                    }
                }

                if (j == args.GetLength(1) - 1) {
                    head.Right = _root;
                    _root.Left = head;
                }
            }
        }

        private void LinkHeadAndLastNodeInColumns(int columnsCount) {
            var temp = (Head)_root.Right;

            for (var i = 1; i <= columnsCount; i++) {
                var n = GetNodeInColumn(temp);
                temp.Up = n;
                n.Down = temp;
                temp = (Head)temp.Right;
            }
        }

        private void LinkRows(int[,] args) {
            for (var i = 0; i < args.GetLength(0); i++) {
                for (var j = 0; j < args.GetLength(1); j++) {
                    if (args[i, j] == 1) {
                        var curr = GetNodeByIndexes(i, j);
                        var columnOfNextNode = FindColumnNumberOfNextNode(args, i, j);

                        if (columnOfNextNode != -1) {
                            curr.Right = GetNodeByIndexes(i, columnOfNextNode);
                            curr.Right.Left = curr;
                        }
                    }
                }
            }
        }

        private Head GetHeadFromRoot(Head head) {
            var h = head;

            while (h.Right != null) {
                h = (Head)h.Right;
            }

            return h;
        }

        private Node GetNodeInColumn(Node node) {
            var n = node;

            while (n.Down != null) {
                n = n.Down;
            }

            return n;
        }

        private Node GetNodeByIndexes(int row, int column) {
            var h = _root;

            while (h.ColumnNumber != column + 1) {
                h = (Head)h.Right;
            }

            var n = h.Down;
            while (n.RowNumber != row + 1) {
                n = n.Down;
            }

            return n;
        }

        private int FindColumnNumberOfNextNode(int[,] args, int row, int column) {
            var j = column + 1;

            while (true) {
                if (j >= args.GetLength(1) - 1) {
                    j = 0;
                }
                if (args[row, j] == 1) {
                    return j;
                }
                j++;
            }
        }
    }
}