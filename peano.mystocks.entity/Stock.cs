using SqlSugar;
using System;
using System.Runtime.Serialization;

namespace peano.mystocks.entity.library
{
    [SugarTable("P_Stock")]
    public class Stock
    {
        [SugarColumn(IsPrimaryKey =true)]
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;

        // 当前价
        [IgnoreDataMember]
        public decimal CurrentPrice { get; set; }


        // 上一交易日收盘价
        [IgnoreDataMember]
        public decimal PreviousPrice { get; set; }


        // 较前交易日收盘价的差值
        [IgnoreDataMember]
        public decimal ChangeAmount { get; set; }


        // 较前交易日收盘价的变动百分比
        [IgnoreDataMember]
        public decimal ChangePercent { get; set; }


        // 最高价
        [SugarColumn(DecimalDigits = 3)]
        public decimal HighPrice { get; set; }


        // 最低价
        [SugarColumn(DecimalDigits = 3)]
        public decimal LowPrice { get; set; }


        // 开盘价
        [SugarColumn(DecimalDigits = 3)]
        public decimal OpenPrice { get; set; }


        // 成交量
        public long Volume { get; set; }


        // 成交额
        public decimal Amount { get; set; }


        // 日期
        public DateTime UpdateTime { get; set; }
    }
}
