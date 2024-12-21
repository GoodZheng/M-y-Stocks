using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static peano.mystocks.dac.library.DBInfo;

namespace peano.mystocks.dac.library
{
    public static class DBSessionFactory
    {
        private static ConcurrentBag<DBConfig> dBConfigs = new ConcurrentBag<DBConfig>();

        public static IDBSession CreateDBSession(DBCode dBCode)
        {
            DBInfo? dbInfo = null;
            if (!dBConfigs.Any(d => d.DBCode == dBCode))
            {
                var configuration = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build();
                dBConfigs = configuration.GetSection("DBConfigs").Get<ConcurrentBag<DBConfig>>() ?? dBConfigs;
            }

            dbInfo = dBConfigs.First(d => d.DBCode == dBCode).DBInfo;
            return dbInfo.DbType switch
            {
                DBSystemType.mysql => new MySqlDBSession(dbInfo),
                DBSystemType.sqlserver => new SqlServerDBSession(dbInfo),
                _ => throw new NotImplementedException(),
            };
        }
    }

    class DBConfig
    {
        public DBCode DBCode { get; set; }

        public DBInfo DBInfo { get; set; }
    }

    public enum DBCode
    {
        ALi_MySql_378 = 101,
        Ali_SqlServer_379 = 201
    }
}
