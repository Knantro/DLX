namespace DLX {
    public class Head : Node {
        public int RowCount { get; set; }
        public int ColumnNumber { get; set; }

        public override string ToString() =>
            $"Head have {RowCount} rows:\n" +
            $"Column number: {ColumnNumber}\n" +
            "About this Node:\n" +
            $"Coords = [{RowNumber}, {Header?.ColumnNumber}]\n" +
            $"LeftCoords = [{((Head)Left)?.RowNumber}, {((Head)Left)?.ColumnNumber}]\n" +
            $"RightCoords = [{((Head)Right)?.RowNumber}, {((Head)Right)?.ColumnNumber}]\n" +
            $"UpCoords = [{Up?.RowNumber}, {Up?.Header?.ColumnNumber}]\n" +
            $"DownCoords = [{Down?.RowNumber}, {Down?.Header?.ColumnNumber}]\n";
    }
}