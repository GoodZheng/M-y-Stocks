using SqlSugar;
using System;

namespace peano.mystocks.entity
{
    [SugarTable("P_Stock")]
    public class Stock
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal PreviousPrice { get; set; }
        public decimal ChangeAmount { get; set; }
        public decimal ChangePercent { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Open { get; set; }
        public long Volume { get; set; }
        public decimal Amount { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
