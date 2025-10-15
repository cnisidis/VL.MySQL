using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using VL.Lib.Collections;

namespace VL.MySQL
{
    public class DatabaseSchema
    {
        public DataSet dataSet {  get; private set; }
        public string Name { get; private set; }
        private Spread<TableSchema> Tables;
        public DatabaseSchema(string Name, Spread<TableSchema> Tables)
        {
            this.Name = Name;
            dataSet = new DataSet(Name);
            foreach (var Table in Tables) 
            { 
                DataTable dataTable = Table.table;
            }

            this.Tables = Tables;
        }

        public Spread<TableSchema> GetTables()
        {
            return this.Tables;
        }

    }


    public class TableSchema
    {
        public DataTable table { get; private set; }
        public string Name { get; private set; }
        public TableSchema(string Name, Spread<ColumnSchema> Columns)
        {
            this.Name = Name;
            this.table = new DataTable(Name);
            table.Columns.AddRange(Columns.Select(x=>x.column).ToArray());

            table.PrimaryKey = new DataColumn[] 
                { 
                    Columns.Where(x => x.isPrimary == true).Select(x => x.column).FirstOrDefault() 
                };
        }


         
        

    }

    public interface IColumnSchema
    {

    }
    public class ColumnSchema
    {
        public DataColumn column { get; private set; }
        public bool isPrimary = false;
        public ColumnSchema(string Name, Type type, bool AutoIncrement=false, int AutoIncrementSeed=1, int AutoIncrementStep=1, bool AllowDBNull = true)
        {
            column = new DataColumn(Name, type);
            if (AutoIncrement)
            {
                column.AutoIncrement = AutoIncrement;
                column.AutoIncrementSeed = AutoIncrementSeed;
                column.AutoIncrementStep = AutoIncrementStep;
                column.AllowDBNull = AllowDBNull;
            }
            
        }
    }
}
