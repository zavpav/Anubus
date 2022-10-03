using System.ComponentModel;

namespace Anubus.Api.Domain.Brs;

public enum EnumBrType
{
    /// <summary> Не понятно. Не определен </summary>
    NotDefine = 0,
        
    /// <summary>  Роспись расходов </summary>
	[Description("Расходов")]
    Expense = 1,
        
    /// <summary> Роспись доходов </summary>
	[Description("Доходов")]
    Income = 2,

    /// <summary> Роспись ПОФ </summary>
    [Description("ПОФ")]
    Pof = 5
}

