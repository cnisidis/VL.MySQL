using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Lib.Collections;

namespace VL.MySQL
{
    public interface IParametrizable
    {
        public Spread<MySqlParameter> GetParameters();
        
        
    }
}
