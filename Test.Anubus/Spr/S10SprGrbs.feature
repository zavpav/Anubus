Функция: Ввод справочника ГРБС
Заполнение справочника ГРБС

@регрес
Сценарий: Первичная загрузка данных ГРБС
	Дано  в справочнике 'ГРБС' количество записей = '0' 
	Когда вводим в справочник 'ГРБС' запись:
			| Родитель | Код | Полное наименование                     | Краткое наименование | Начало     | Конец      |
			|          | 320 | Федеральная служба исполнения наказаний | ФСИН России          | 01.01.1900 | 01.01.2100 |
	Тогда в справочнике 'ГРБС' есть запись с 'Код'='320'