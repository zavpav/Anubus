// Внешняя информация по действию со строкой
export interface ActionInfo {
    // Имя операции
    operation: string;
    // Куда пересылать
    endpoint?: string;
    // Каким рисунком отображать
    glyph?: string;
    // Какую подсказку писать
    tooltip?: string
}