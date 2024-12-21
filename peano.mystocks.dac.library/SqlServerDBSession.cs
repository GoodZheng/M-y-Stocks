using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace peano.mystocks.dac.library
{
    public class SqlServerDBSession:IDBSession
    {
        public SqlSugarClient Db { get; }

        public SqlServerDBSession(DBInfo dBInfo)
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = dBInfo.ToConnectionString(),
                IsAutoCloseConnection = true,
                DbType = DbType.SqlServer,
                ConfigureExternalServices = new ConfigureExternalServices()
                {
                    EntityNameService = (type, entity) =>
                    {
                        entity.IsDisabledDelete = true; //设置禁止删除列
                    }
                }
            });
        }
    }
}
