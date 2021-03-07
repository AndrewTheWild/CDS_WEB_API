
namespace CDS.DynamicAPI.Mockup
{
    public sealed class ColumnSet
    {
        public DataCollection<string> Columns { get; } = new DataCollection<string>();
        public ColumnSet() { }
        public ColumnSet(bool allColumns)
            => AllColumns = allColumns;
        public ColumnSet(params string[] columns)
        {
            Columns.AddRange(columns);
        }
        public bool AllColumns { get; set; }
        public void AddColumn(string column)
            => Columns.Add(column);
        public void AddColumns(params string[] columns)
            => Columns.AddRange(columns);
    }
}
