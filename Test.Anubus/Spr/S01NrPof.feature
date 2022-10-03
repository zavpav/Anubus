﻿Функция: Загрузка справочников

############################################################################################################

Сценарий: Первичная загрузка данных НРПОФ 2016
	Дано  в справочнике 'НРПОФ' количество записей = '0' 
	Когда вводим в справочник 'НРПОФ' запись:
            | Родитель | Код | Краткое наименование                              | Полное наименование                               | Является резервом | Начало     | Конец      |
            |          | 10  | Бюджет                                            | Бюджет                                            | N                 | 01.01.2016 | 01.01.2100 |
            | 10       | 11  | Распределено по ПБС                               | Распределено по ПБС                               | N                 | 01.01.2016 | 01.01.2100 |
            | 10       | 12  | Нераспределенный остаток                          | Нераспределенный остаток                          | Y                 | 01.01.2016 | 01.01.2100 |
            | 10       | 15  | Списано                                           | Списано                                           | Y                 | 01.01.2016 | 01.01.2100 |
            | 10       | 13  | Нераспределенный остаток за счет 5% превышения КУ | Нераспределенный остаток за счет 5% превышения КУ | Y                 | 01.01.2016 | 01.01.2100 |
            | 10       | 16  | Списано превышенных ПОФ                           | Списано превышенных ПОФ                           | Y                 | 01.01.2016 | 01.01.2100 |
            |          | 20  | ДИБФ                                              | ДИБФ                                              | N                 | 01.01.2016 | 01.01.2100 |
            | 20       | 21  | Распределено по ПБС                               | Распределено по ПБС                               | N                 | 01.01.2016 | 01.01.2100 |
            | 20       | 22  | Нераспределенный остаток                          | Нераспределенный остаток                          | Y                 | 01.01.2016 | 01.01.2100 |
            | 20       | 25  | Списано                                           | Списано                                           | Y                 | 01.01.2016 | 01.01.2100 |
            | 20       | 23  | Нераспределенный остаток за счет 5% превышения КУ | Нераспределенный остаток за счет 5% превышения КУ | Y                 | 01.01.2016 | 01.01.2100 |
            | 20       | 26  | Списано превышенных ПОФ                           | Списано превышенных ПОФ                           | Y                 | 01.01.2016 | 01.01.2100 |
	Тогда всё хорошо
