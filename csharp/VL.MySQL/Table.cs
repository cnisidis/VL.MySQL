
using System.Data;

using VL.Lib.Collections;

namespace VL.MySQL
{
    

    public class Table
    {
        DataSet dataSet { get; set; }
        
        public string Name { get; private set; }
        HashSet<Column> columns = new HashSet<Column>();    
        public Table(string name, Spread<Column> Columns)
        {
            dataSet = new DataSet();
            dataSet.DataSetName = name;
            
            Name = name;
            this.columns = Columns.ToHashSet();
        }

        public List<Column> GetColumns()
        {
            return this.columns.ToList();
        }
        
    }

    public class Column
    {
        string Name;
        int Index;
        DbType Type;

        public Column(int index, string name, DbType type)
        {
            Name=name;
            Index=0;
            Type = type;
        }
    }
}
