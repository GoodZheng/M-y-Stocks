using peano.mystocks.dac.library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetStocksDataService.Service
{
    public class GetStocksDataService
    {
         IDBSession dBSession = DBSessionFactory.GetDBSession(DBCode.ALi_MySql_378);

        public void StartService()
        {
            
        }
    }
}
