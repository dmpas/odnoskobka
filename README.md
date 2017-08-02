# Односкобочник

Компонента для чтения/записи скобочных файлов.

## Пример чтения

```bsl
	ТестовыеДанные = "{{""St""""
	|ring"", 1, 01234567-abcd-efab-cdef-0123456789ab}}";

	Ч = Новый ЧтениеСкобаря;
	Ч.УстановитьСтроку(ТестовыеДанные);

	Ч.Прочитать();
	// Ч.ТипЭлемента = ТипУзлаСкобаря.НачалоЭлемента

	Ч.Прочитать();
	// Ч.ТипЭлемента = ТипУзлаСкобаря.НачалоЭлемента

	Ч.Прочитать();

	// Ч.ТипЭлемента = ТипУзлаСкобаря.Значение
	// Ч.Значение = "St""
	//	            |ring"

	Ч.Прочитать();

	// Ч.ТипЭлемента = ТипУзлаСкобаря.Значение
	// Ч.Значение = 1

	Ч.Прочитать();

	// Ч.ТипЭлемента, ТипУзлаСкобаря.Значение
	// Ч.Значение = Новый УникальныйИдентификатор("01234567-abcd-efab-cdef-0123456789ab")

	Ч.Прочитать();
	// Ч.ТипЭлемента = ТипУзлаСкобаря.КонецЭлемента

	Ч.Прочитать();
	// Ч.ТипЭлемента = ТипУзлаСкобаря.КонецЭлемента  
```
