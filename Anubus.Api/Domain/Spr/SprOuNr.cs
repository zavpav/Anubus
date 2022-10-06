namespace Anubus.Api.Domain.Spr;

public class SprOuNr : SprSimpleBaseWithRezerv
{
    /// <summary> Скрывать ли заголовок ОУ при формировании телеграммы </summary>
    [TestFieldDescription("Скрывать в телеграмме")]
    public bool TgHide { get; set; }

    /// <summary> Порядок сортировки ОУ при печати телеграммы </summary>
    [TestFieldDescription("Сортировка в телеграмме")]
    public int TgOrder { get; set; }
}
