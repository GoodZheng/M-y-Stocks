using SqlSugar;
using System;
using System.Runtime.Serialization;

namespace peano.mystocks.entity.library
{
    [SugarTable("P_Stock")]
    public class Stock
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)] // 主键，自动增长
        public int Id { get; set; } // 本地数据库用的Id字段

        [SugarColumn(ColumnName = "ts_code")]
        public string TsCode { get; set; } = null!;

        [SugarColumn(ColumnName = "symbol")]
        public string Symbol { get; set; } = null!;

        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; } = null!;

        [SugarColumn(ColumnName = "area", IsNullable =true)]
        public string? Area { get; set; }

        [SugarColumn(ColumnName = "industry", IsNullable =true)]
        public string? Industry { get; set; }

        [SugarColumn(ColumnName = "fullname", IsNullable =true)]
        public string? FullName { get; set; }

        [SugarColumn(ColumnName = "enname", IsNullable = true)]
        public string? EnName { get; set; }

        [SugarColumn(ColumnName = "cnspell", IsNullable = true)]
        public string? CnSpell { get; set; }

        [SugarColumn(ColumnName = "market", IsNullable = true)]
        public string? Market { get; set; }

        [SugarColumn(ColumnName = "exchange", IsNullable = true)]
        public string? Exchange { get; set; }

        [SugarColumn(ColumnName = "curr_type", IsNullable = true)]
        public string? CurrType { get; set; }

        [SugarColumn(ColumnName = "list_status", IsNullable = true)]
        public string? ListStatus { get; set; }

        [SugarColumn(ColumnName = "list_date", IsNullable = true)]
        public DateTime? ListDate { get; set; } // Nullable 类型适应没有值的情况

        [SugarColumn(ColumnName = "delist_date", IsNullable = true)]
        public DateTime? DelistDate { get; set; } // Nullable 类型适应没有值的情况

        [SugarColumn(ColumnName = "is_hs", IsNullable = true)]
        public string? IsHs { get; set; }

        [SugarColumn(ColumnName = "act_name", IsNullable = true)]
        public string? ActName { get; set; }

        [SugarColumn(ColumnName = "act_ent_type", IsNullable = true)]
        public string? act_ent_type { get; set; }
    }
}
