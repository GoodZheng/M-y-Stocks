using peano.mystocks.entity.library;
using SqlSugar;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace peano.mystocks.dac.library
{
    public class MySqlDBSession:IDBSession
    {
        public SqlSugarClient Db { get; }

        public MySqlDBSession(DBInfo dBInfo)
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = dBInfo.ToConnectionString(),
                IsAutoCloseConnection = true,
                DbType = DbType.MySql,
                ConfigureExternalServices = new ConfigureExternalServices()
                {
                    EntityNameService = (type, entity) =>
                    {
                        entity.IsDisabledDelete = true; //设置禁止删除列
                    }
                }
            });
        }
        public async Task<List<Stock>> GetStocksAsync()
        {
            return await Db.Queryable<Stock>().ToListAsync();
        }
    }
}
