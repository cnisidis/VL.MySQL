using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Lib.Collections;

namespace VL.MySQL
{
    public class Connection
    {
        private string _connectionString;
        public MySqlConnection connection { private set; get; }
        public Connection(string Server="127.0.0.1", string ID="root", string password="", string database="" )
        {
            _connectionString = $"Server={Server}; User ID={ID}; Password={password}; Database={database}";
        }


        public async void Connect()
        {
            connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
        }

        public async void Close()
        {
            await connection.CloseAsync();
            connection.Dispose();
        }

        public async Task<Spread<string>> Show(ShowElements Elements)
        {
            
            await using var command = new MySqlCommand($"SHOW {Elements.ToString()}", connection);
            await using var reader = await command.ExecuteReaderAsync();

            List<string> result = new List<string>();

            while (await reader.ReadAsync())
            {
                result.Add(reader.GetString(0));
            }
                
            return result.ToSpread();
        }

        public async Task<Spread<Spread<T>>> Select<T>(Func<IDataReader, Spread<T>> Delegate, string textCommand="SELECT FROM ")
        {
            await using var command = new MySqlCommand(textCommand, connection);
            await using var reader = await command.ExecuteReaderAsync( );
            List<Spread<T>> results = new List<Spread<T>>();
            while(await reader.ReadAsync())
            {
                results.Add((Spread<T>)Delegate.DynamicInvoke(reader));
            }
            return results.ToSpread();
        }

        public async Task<int> Insert(string TableName, string FieldName, object Value )
        {
            using (var cmd = new MySqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = $"INSERT INTO {TableName} ({FieldName}) VALUES (@{Value})";
                //cmd.Parameters.AddWithValue("p", "Hello world");
                return await cmd.ExecuteNonQueryAsync();
            }
        }


        public async void CreatTable()
        {
            
        }

        public async Task<int> NonQuery(string textCommand)
        {
            await using var command = new MySqlCommand(textCommand, connection);
            return await command.ExecuteNonQueryAsync();
        }

        public async Task<object> Scalar(string textCommand)
        {
            await using var command = new MySqlCommand(textCommand, connection);
            return await command.ExecuteScalarAsync();
        }

        public string State() => connection.State.ToString();
    }

    public enum ShowElements
    {
        DATABASES,
        TABLES,
        SCHEMAS
    }
}
