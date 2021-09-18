using System;

namespace DLX {
    public class Node {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Down { get; set; }
        public Node Up { get; set; }
        public int RowNumber { get; set; } = -1;
        public Head Header { get; set; }

        public override string ToString() =>
            $"About this Node:\n" +
            $"Coords = [{RowNumber}, {Header?.ColumnNumber}]\n" +
            $"LeftCoords = [{Left?.RowNumber}, {Left?.Header?.ColumnNumber}]\n" +
            $"RightCoords = [{Right?.RowNumber}, {Right?.Header?.ColumnNumber}]\n" +
            $"UpCoords = [{Up?.RowNumber}, {Up?.Header?.ColumnNumber}]\n" +
            $"DownCoords = [{Down?.RowNumber}, {Down?.Header?.ColumnNumber}]\n";

    }
}