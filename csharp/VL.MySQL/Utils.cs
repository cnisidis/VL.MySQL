///For examples, see:
///https://thegraybook.vvvv.org/reference/extending/writing-nodes.html#examples

namespace VL.MySQL;


public enum VLSQLTypes
{
    /// <summary>
    /// A FIXED length string (can contain letters, numbers, and special characters). The size parameter specifies the column length in characters - can be from 0 to 255. Default is 1
    /// </summary>
    CHAR,
    /// <summary>
    /// A VARIABLE length string (can contain letters, numbers, and special characters). The size parameter specifies the maximum column length in characters - can be from 0 to 65535
    /// </summary>
    VARCHAR,
    BINARY,
    VARBINARY,
    TINYBLOB,
    TINYTEXT,
    TEXT,
    BLOB,
    MEDIUMTEXT,
    MEDIUMBLOB,
    LONGTEXT,
    LONGBLOB,
    ENUM,
    SET

}

public enum SQLCollation
{
  utf8mb4 = 0,
  armscii8,              
  ascii,                
  big5,                 
  binary,               
  cp1250,               
  cp1251,                 
  cp1256,              
  cp1257,                
  cp850,                
  cp852,               
  cp866,                
  cp932,                
  dec8,                   
  eucjpms,              
  euckr,                  
  gb18030,              
  gb2312,               
  gbk,                    
  geostd8,                
  greek,                
  hebrew,                
  hp8,                   
  keybcs2,               
  koi8r,                
  koi8u,                
  latin1,                
  latin2,                 
  latin5,               
  latin7,                
  macce,                 
  macroman,              
  sjis,                 
  swe7,                  
  tis620,               
  ucs2,                 
  ujis,                   
  utf16,                 
  utf16le,               
  utf32,                
  utf8,           
        

}


public enum SQLEngines
{
    InnoDB,
    MariaDB
}