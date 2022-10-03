using System.ComponentModel;

namespace Anubus.Services.Security;

public enum EnumAnubusRole
{
    [Description("Не задано")]
    NotDefined = 0,

    [Description("Пользователь ЦА")]
    Grbs = 1,

    [Description("Пользователь ТО")]
    Rbs,

    [Description("Расширенные режимы работы (СИС)")]
    Internal,

    [Description("Миграция")]
    Migration,

    ///// <summary> Работа отдела АСУД в АСУБС </summary>
    //SF_ASUBS_EXT_OU_ASUD,

    ///// <summary> Работа отдела Оплаты труда FBPF#2951</summary>
    //SF_ASUBS_EXT_LBR_RPMNT,
}
