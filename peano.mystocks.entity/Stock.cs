using SqlSugar;
using System;

namespace peano.mystocks.entity
{
    [SugarTable("P_Stock")]
    public class Stock
    {
        [SugarColumn(IsPrimaryKey =true)]
        public int Code { get; set; }
        public string Name { get; set; } = null!;

        // 当前价
        [SugarColumn(DecimalDigits =3)]
        public decimal CurrentPrice { get; set; }


        // 上一交易日收盘价
        [SugarColumn(DecimalDigits = 3)]
        public decimal PreviousPrice { get; set; }


        // 较前交易日收盘价的差值
        [SugarColumn(DecimalDigits = 3)]
        public decimal ChangeAmount { get; set; }


        // 较前交易日收盘价的变动百分比
        [SugarColumn(DecimalDigits = 4)]
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


        // 更新时间
        public DateTime UpdateTime { get; set; }
    }
}
