﻿Перем юТест;

////////////////////////////////////////////////////////////////////
// Программный интерфейс

Функция ПолучитьСписокТестов(ЮнитТестирование) Экспорт
	
	юТест = ЮнитТестирование;
	
	ВсеТесты = Новый Массив;

	ВсеТесты.Добавить("ТестДолжен_ПроверитьЧтениеЗаписьОдногоЭлемента");

	Возврат ВсеТесты;
	
КонецФункции

Процедура ТестДолжен_ПроверитьЧтениеЗаписьОдногоЭлемента() Экспорт

	З = Новый ЗаписьСкобаря;
	З.ЗаписатьНачалоЭлемента();
	З.ЗаписатьЗначение(1);
	З.ЗаписатьЗначение(2);
	З.ЗаписатьЗначение(3);
	З.ЗаписатьНачалоЭлемента();
	З.ЗаписатьЗначение("""N""");
	З.ЗаписатьЗначение(15);
	З.ЗаписатьКонецЭлемента();
	З.ЗаписатьКонецЭлемента();

	Итог = З.Закрыть();

	юТест.ПроверитьРавенство(Итог, "{1,2,3,
	|{""N"",15}
	|}");

	Ч = Новый ЧтениеСкобаря;
	Ч.УстановитьСтроку(Итог);

	юТест.ПроверитьРавенство(Ч.Прочитать(), Истина, "Первая скобка"); // {
	юТест.ПроверитьРавенство(Строка(Ч.ТипЭлемента), Строка(ТипУзлаСкобаря.НачалоЭлемента));

	юТест.ПроверитьРавенство(Ч.Прочитать(), Истина, "Число 1"); // 1
	юТест.ПроверитьРавенство(Строка(Ч.ТипЭлемента), Строка(ТипУзлаСкобаря.Текст));

	юТест.ПроверитьРавенство(Ч.Прочитать(), Истина, "Число 2"); // 2
	юТест.ПроверитьРавенство(Строка(Ч.ТипЭлемента), Строка(ТипУзлаСкобаря.Текст));

	юТест.ПроверитьРавенство(Ч.Прочитать(), Истина, "Число 3"); // 3
	юТест.ПроверитьРавенство(Строка(Ч.ТипЭлемента), Строка(ТипУзлаСкобаря.Текст));

	юТест.ПроверитьРавенство(Ч.Прочитать(), Истина, "Вторая скобка"); // {
	юТест.ПроверитьРавенство(Строка(Ч.ТипЭлемента), Строка(ТипУзлаСкобаря.НачалоЭлемента));

	юТест.ПроверитьРавенство(Ч.Прочитать(), Истина, "Строка N"); // "N"
	юТест.ПроверитьРавенство(Строка(Ч.ТипЭлемента), Строка(ТипУзлаСкобаря.Текст));

	юТест.ПроверитьРавенство(Ч.Прочитать(), Истина, "Число 15"); // 15
	юТест.ПроверитьРавенство(Строка(Ч.ТипЭлемента), Строка(ТипУзлаСкобаря.Текст));

	юТест.ПроверитьРавенство(Ч.Прочитать(), Истина, "Закрывающая скобка"); // }
	юТест.ПроверитьРавенство(Строка(Ч.ТипЭлемента), Строка(ТипУзлаСкобаря.КонецЭлемента));

	юТест.ПроверитьРавенство(Ч.Прочитать(), Истина, "Закрывающая скобка"); // }
	юТест.ПроверитьРавенство(Строка(Ч.ТипЭлемента), Строка(ТипУзлаСкобаря.КонецЭлемента));

	юТест.ПроверитьРавенство(Ч.Прочитать(), Ложь, "Больше нечего считывать");

КонецПроцедуры
