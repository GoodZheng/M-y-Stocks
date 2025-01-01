using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace peano.mystocks.dac.library
{
    public class DBInfo
    {
        public DBSystemType DbType { get; set; }
        public string DbServer { get; set; }
        public string DbInstance { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }

        public int MaxConnection { get; set; }

        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 生成连接串
        /// </summary>
        public string ToConnectionString()
        {
            if (DbType == DBSystemType.sqlserver)
            {
                return "Data Source=" + DbServer + "," + Port + ";Failover Partner=;Initial Catalog=" + DbInstance + ";User ID=" + User + ";Password=" + Password + ";pooling=true;Max Pool Size=1024";
            }
            else if (DbType == DBSystemType.postgresql)
            {
                return string.Format("Host={0};Port={4};Username={1};Password={2};Database={3};MaxPoolSize={5};Connection Idle Lifetime=10;", DbServer, User, Password, DbInstance, Port, 50);
            }
            else if (DbType == DBSystemType.oracle)
            {
                return @"Provider=msdaora;Data Source=" + DbServer + "," + Port + ";User Id=" + User + ";Password=" + Password + ";";
            }
            else if (DbType == DBSystemType.mysql)
            {
                return @"Data Source=" + DbServer + "; Port = " + Port + ";Database=" + DbInstance + ";User Id=" + User + ";Password=" + Password + ";";
            }
            else
            {
                return "Data Source=" + DbServer + "," + Port + ";Failover Partner=" + ";Initial Catalog=" + DbInstance + ";User ID=" + User + ";Password=" + Password + ";pooling=true;Max Pool Size=1024";
            }
        }

        
    }
    public enum DBSystemType
    {
        sqlserver,  //sqlserver数据库
        postgresql,   //pgSQL数据库
        access,       //access数据库
        oracle,       //oracle数据库
        mysql        //mysql数据库
    }
}
