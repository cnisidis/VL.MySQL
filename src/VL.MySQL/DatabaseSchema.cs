using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using VL.Lib.Collections;
using Stride.Core.Extensions;

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
                DataTable dataTable = Table.Table;
            }

            this.Tables = Tables;
        }

        public Spread<TableSchema> GetTables()
        {
            return this.Tables;
        }

        public static string ToMySQLSchema()
        {
            return "";
        }

    }


    public class TableSchema
    {
        public DataTable Table { get; private set; }
        public string Name { get; private set; }

        private Spread<ColumnSchema> Columns;
        public TableSchema(string Name, Spread<ColumnSchema> Columns)
        {
            this.Name = Name;
            this.Table = new DataTable(Name);
            this.Columns = Columns;
            if(Columns != null && Columns.Any())
            {
                this.Table.Columns.Clear();
                Table.Columns.AddRange(Columns.Where(x => !x.column.ColumnName.IsNullOrEmpty()).Select(x => x.column).ToArray());
            }
                

            Table.PrimaryKey = new DataColumn[] 
                { 
                    Columns.Where(x => x.isPrimary == true).Select(x => x.column).FirstOrDefault() 
                };
        }

        public string GetPrimaryKeyName()
        {
            return Table.PrimaryKey.FirstOrDefault().ColumnName;
        }

        public void SetColumns(Spread<ColumnSchema> Columns)
        {
            this.Columns = Columns;
            this.Table.Columns.Clear();
            this.Table.Columns.AddRange(Columns.Select(x=>x.column).ToArray());
        }

        public Spread<ColumnSchema> GetColumns()
        {
            return this.Columns;
        }
         
        public void AddRow(object?[] Values )
        {
            this.Table.Rows.Add(Values);
        }

    }

   
    public class ColumnSchema
    {
        public DataColumn column { get; private set; }
        public bool isPrimary = false;
        public string Name { private set; get; }
        public object defaultValue;
        
        public ColumnSchema(string Name, Type type, bool AutoIncrement=false, int AutoIncrementSeed=1, int AutoIncrementStep=1, bool AllowDBNull = true, bool isPrimary=false)
        {
            column = new DataColumn(Name, type);
            this.Name = Name;
            this.isPrimary = isPrimary;
            
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
