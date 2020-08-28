using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF_kz
{
	#region ESF enums
	public enum FillingMethod
    {
        AUTO,
        MANUAL,
        CALENDAR,
        CATALOG,
        AUTO_MANUAL
	}
    public enum FillingType
	{
        NUMBER,
        DIGIT,
        STRING,
        DATE_DDpMMpYYYY,//p-point
        CHECKBOX
    }
    public enum IsRequired
	{
        NOT_REQUIRED,
        REQUIRED,
        CONDITIONALY_REQUIRED
	}
    public enum IsDisplayed
	{
        NOT_DISPLAYED,
        DISPLAYED
	}

    public enum IsPrintable
    {
        NOT_PRINTABLE,
        PRINTABLE
    }
	#endregion

	#region ESFfield's custom attribute
	[System.AttributeUsage(System.AttributeTargets.Field)]
    public class detailsESFfieldAttribute : System.Attribute
    {
        public string tagNameV2;
        public string fieldCode;//Обозначение (код) поля
        public string fieldName;//Наименование поля
        public int minDigitsCount;//Количество символов(min)
        public int maxDigitsCount;//Количество символов(max)
        public FillingType fieldType;//Тип поля
        public FillingMethod filling;//Способ заполнения (Автоматически/Вручную/Выбор из календаря)
        public IsPrintable isPrintable;//Отображение в печатной форме
        public IsDisplayed isDisplayed;//Отображение в интерфейсе
        public IsRequired isRequired;//Обязательность заполнения
        public string details1;//Общие критерии проверки правильности заполнения и сообщения об ошибках 
        public string details2;//Критерии проверки правильности заполнения только при заполнении в приложении
        public string details3;//Критерии проверки правильности заполнения только при импорте или получении ЭСФ по API



        public detailsESFfieldAttribute(string _tagNameV2, string _fieldCode, string _fieldName, int _minDigitsCount, int _maxDigitsCount,FillingType _fieldType, FillingMethod _filling, IsPrintable _isPrintable, IsDisplayed _isDisplayed, IsRequired _isRequired, string _details1="", string _details2 = "", string _details3 = "")
        {
            this.tagNameV2 = _tagNameV2;
            this.fieldCode = _fieldCode;
            this.fieldName = _fieldName;
            this.minDigitsCount = _minDigitsCount;
            this.maxDigitsCount = _maxDigitsCount;
            this.fieldType = _fieldType;
            this.filling = _filling;
            this.isPrintable = _isPrintable;
            this.isDisplayed = _isDisplayed;
            this.isRequired = _isRequired;
            this.details1 = _details1;
            this.details2 = _details2;
            this.details3 = _details3;
        }
    }
	#endregion

	class ESF
    {
        #region Раздел А Общий раздел

        [detailsESFfield("num", "1", "Регистрационный номер", 34, 34, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.NOT_DISPLAYED, IsRequired.REQUIRED,
        "Присваивается автоматически системой при регистрации документа.Поле заблокировано для редактирования.")]
        public string registrationNumber;

        [detailsESFfield("", "1.1", "Номер учетной системы", 1, 30, FillingType.NUMBER, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
         "1) Проверка на обязательность заполнения.При отсутствии реквизита сообщение: Номер учетной системы отсутствует." +
         "2) Проверка на уникальность значения в рамках текущей даты, в рамках одного НП.При несоответствии сообщение: Счет-фактура с таким номером и датой уже существуют, пожалуйста укажите другой номер.")]
        public string accauntingSystemNumber;

        [detailsESFfield("date", "2", "Дата выписки", 10, 10, FillingType.DATE_DDpMMpYYYY, FillingMethod.CALENDAR, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
            "Проверка на обязательность заполнения.При отсутствии реквизита сообщение:Дата выписки отсутствует",
            "Автоматическое заполнение текущей датой.Поле заблокировано для редактирования",
            "Проверка на совпадение с текущей датой.При несоответствии сообщение: Дата выписки СФ отличается от текущей")]
        public DateTime date;

        #region Ввод бумажного ЭСФ

        [detailsESFfield("", "2.1", "Дата выписки на бумажном носителе", 0, 10, FillingType.DATE_DDpMMpYYYY, FillingMethod.CALENDAR, IsPrintable.NOT_PRINTABLE, IsDisplayed.NOT_DISPLAYED, IsRequired.NOT_REQUIRED,
            "Если выбрана причина -Отсутствовало требование по выписке ЭСФ- следующие проверки по указанной дате:" +
            " 1.Если дата бумажного СФ, на который необходимо выписать исправленный и дополнительный ЭСФ, является до 01.01.2018 года(но не больше 5 лет с текущей даты), то проверки осуществлять не нужно." +
            " 2.Если дата бумажного СФ, на который необходимо выписать исправленный и дополнительный ЭСФ, равна 01.01.2018 года и позже, то нужно проверить входитли Пользователь в список крупных компаний.Если пользователь входит в список крупных компаний, то выходит сообщение: Вы не можете вводить бумажный СФ с причиной -Отсутствовало требование по выписке ЭСФ-." +
            " 3.Если дата бумажного СФ, на который необходимо выписать исправленный и дополнительный ЭСФ, равна 01.01.2019 года и позже(но не больше 5 лет с текущей даты), то необходимо проверить является ли Пользователь плательщиком НДС на дату выписки бумажного счетафактуры. При ошибке сообщение: Вы не можете вводить бумажный СФ спричиной -Отсутствовало требование повыписке ЭСФ-",

            "1) Отображается в календаре для выбора доступный период на основании выбранной причины при вводе бумажного СФ." +
            "2) Если выбрана причина -Простой системы-, то отображается период, в котором был простой системы." +
            "3) Если выбрана причина -Блокирование доступа к Системе-, то отображается период, в котором была неправомерная блокировка НП к Системе." +
            "4) Если пользователь выбирает причину -Отсутствовало требование по выписке ЭСФ- отображается календарь за предыдущие 5 лет.",

            "1) Если выбрана причина -Простой системы-,проверка наличия протокола простоя системы за указанную дату.При отсутствии протокола простоя в системе сообщение: Простой системы не зафиксирован." +
            "2) Если выбрана причина -Блокирование доступа к Системе-, проверка наличия протокола блокировки НП к Системе. При отсутствии протокола блокировки НП сообщение: Неправомерная блокировка НП не зафиксирована.")]
        public DateTime writtenESFdate;

        [detailsESFfield("", "", "Причина выписки на бумажном носителе", 0, 999, FillingType.STRING, FillingMethod.CATALOG, IsPrintable.NOT_PRINTABLE, IsDisplayed.NOT_DISPLAYED, IsRequired.NOT_REQUIRED,
            "Выбор из справочника:-Простой системы(DOWN_TIME);-Блокирование доступа к Системе (UNLAWFUL_REMOVAL_REGISTRATION);-Отсутствовало требование по выписке ЭСФ(MISSING_REQUIREMENT).",
            "",
            "Проверка выбранной причины на соответствие справочнику, при несоответствии сообщение: Неизвестная причина выписки ЭСФ на бумажном носителе.")]
        public string writtenESFreason;

        [detailsESFfield("turnoverDate", "3", "Дата совершения оборота", 0, 10, FillingType.DATE_DDpMMpYYYY, FillingMethod.CALENDAR, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
           "Проверка на обязательность заполнения.При отсутствии реквизита сообщение:Дата совершения оборота отсутствует",
           "1)Автоматическое заполнение текущей датой с возможностью для редактирования" +
           "2) Возможность выбора в календаре даты прошлого периода, но не раньше пяти лет, начиная с текущей даты. ",
           "Проверка на заполнение даты не раньше 5 лет, начиная с текущей даты, и не позже текущей даты. При несоответствии сообщение: Дата совершения оборота задана неверно.")]
        public DateTime turnoverDate;
        #endregion

        #region Исправленный ЭСФ <RelatedInvoice> Служит для связки исправленного/дополнительного ЭСФ с основным

        [detailsESFfield("InvoiceType", "4", "Исправленный ЭСФ", 0, 10, FillingType.CHECKBOX, FillingMethod.CATALOG, IsPrintable.NOT_PRINTABLE, IsDisplayed.NOT_DISPLAYED, IsRequired.REQUIRED,
            "Если отмечено поле 4 -Исправленный-, проверка наличия основного ЭСФ по сочетанию следующих полей: - 4.1 Дата выписки; - 4.2 Номер учетной системы; - 4.3 Регистрационный номер. " +
            "При отсутствии данных сообщение: «Основной ЭСФ не найден».",
            "Возможность указания, если не отмечено поле 5 -дополнительный-.",
            "Проверка на отсутствие отметки в поле 5 «дополнительный». При несоответствии сообщение: «Не допускается одновременный выбор отметок «Дополнительный» и «Исправленный»».")]
        public string fixedInvoice;

        [detailsESFfield("date", "4.1", "Дата выписки ЭСФ", 0, 10, FillingType.DATE_DDpMMpYYYY, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
            "1) Проверка на обязательность заполнения, если отмечено поле 4 -Исправленный-. При отсутствии реквизита сообщение: -Дата выписки ЭСФ, к которому выписывается Исправленный ЭСФ, отсутствует-. " +
            "2) Проверка, что дата выписки Исправленного ЭСФ (поле 2) находится в пределах исковой давности с даты выписки основного ЭСФ. " +
            "При несоответствии, сообщение: -Дата выписки ЭСФ, к которому выписывается Исправленный ЭСФ, не может превышать срок исковой давности-.",
            "Если Исправленный ЭСФ создается на основании основного ЭСФ, автоматическое заполнение без возможности редактирования.")]
        public DateTime fixedInvoiceDate;

        [detailsESFfield("num", "4.2", "Исходящий номер ЭСФ в бухгалтерии", 1, 30, FillingType.NUMBER, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
            "Проверка на обязательность заполнения, если отмечено поле 4 -Исправленный-. При отсутствии реквизита сообщение: -Номер ЭСФ, к которому выписывается Исправленный ЭСФ, отсутствует-.",
            "Если Исправленный ЭСФ создается на основании основного ЭСФ, автоматическое заполнение без возможности редактирования.",
            "")]
        public string fixedInvoiceNum;

        [detailsESFfield("", "4.3", "Регистрационный номер", 34, 34, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
           "1) Проверка на обязательность заполнения, если отмечено поле 4 -Исправленный-. При отсутствии реквизита сообщение: -Регистрационный номер ЭСФ, к которому выписывается Исправленный ЭСФ, отсутствует -. " +
           "2) Проверка длины указанного регистрационного номера. При несоответствии сообщение: -Регистрационный номер ЭСФ должен содержать 34 символа-.",
           "Если Исправленный ЭСФ создается на основании основного ЭСФ, автоматическое заполнение без возможности редактирования.",
           "")]
        public string fixedInvoiceRegNum;

        #endregion

        #region Дополнительный ЭСФ <RelatedInvoice> Служит для связки исправленного/дополнительного ЭСФ с основным

        [detailsESFfield("InvoiceType", "5", "Дополнительный ЭСФ", 0, 10, FillingType.CHECKBOX, FillingMethod.CATALOG, IsPrintable.NOT_PRINTABLE, IsDisplayed.NOT_DISPLAYED, IsRequired.REQUIRED,
            "Если отмечено поле 5 -Дополнительный-, проверка наличия основного ЭСФ по сочетанию следующих полей: - 5.1 Дата выписки; - 5.2 Номер учетной системы; - 5.3 Регистрационный номер. " +
            "При отсутствии данных сообщение: «Основной ЭСФ не найден».",
            "Возможность указания, если не отмечено поле 4 -Исправленный-.",
            "Проверка на отсутствие отметки в поле 4 «Исправленный». При несоответствии сообщение: «Не допускается одновременный выбор отметок «Дополнительный» и «Исправленный»».")]
        public string addititonalInvoice;

        [detailsESFfield("date", "5.1", "Дата выписки ЭСФ", 0, 10, FillingType.DATE_DDpMMpYYYY, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
            "1) Проверка на обязательность заполнения, если отмечено поле 5 -Дополнительный-. При отсутствии реквизита сообщение: -Дата выписки ЭСФ, к которому выписывается дополнительный ЭСФ, отсутствует-. " +
            "2) Проверка, что дата выписки дополнительного ЭСФ (поле 2) находится в пределах исковой давности (5 лет) с даты выписки основного ЭСФ. " +
            "При несоответствии, сообщение: -Дата выписки ЭСФ, к которому выписывается дополнительный ЭСФ, не может превышать срок исковой давности-.",
            "Если дополнительный ЭСФ создается на основании основного ЭСФ, автоматическое заполнение без возможности редактирования.")]
        public DateTime addititonalInvoiceDate;

        [detailsESFfield("num", "5.2", "Исходящий номер ЭСФ в бухгалтерии", 1, 30, FillingType.NUMBER, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
            "Проверка на обязательность заполнения, если отмечено поле 5 -Дополнительный-. При отсутствии реквизита сообщение: -Номер ЭСФ, к которому выписывается дополнительный ЭСФ, отсутствует-.",
            "Если дополнительный ЭСФ создается на основании основного ЭСФ, автоматическое заполнение без возможности редактирования.",
            "")]
        public string addititonalInvoiceNum;

        [detailsESFfield("", "5.3", "Регистрационный номер", 34, 34, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
           "1) Проверка на обязательность заполнения, если отмечено поле 5 -Дополнительный-. При отсутствии реквизита сообщение: -Регистрационный номер ЭСФ, к которому выписывается дополнительный ЭСФ, отсутствует -. " +
           "2) Проверка длины указанного регистрационного номера. При несоответствии сообщение: -Регистрационный номер ЭСФ должен содержать 34 символа-.",
           "Если дополнительный ЭСФ создается на основании основного ЭСФ, автоматическое заполнение без возможности редактирования.",
           "")]
        public string addititonalInvoiceRegNum;

        #endregion

        #endregion

        #region Раздел В Реквизиты поставщика

        #region General

        /*Если в поле 10 "Категория поставщика" отмечена категория «Е – Участник СРП» или "F - Участник 
         * договора о совместной деятельности" и заполнено поле 10.1 "Количество", раздел B, связанный с
         * ним раздел B1 и раздел H размножается для каждого участника СРП или совместной деятельности в
         * соответствии с указанным количеством. При этом должна быть возможность удаления разделов B,
         * связанных разделов B1 и разделов Н при изменении количества участников совместной деятельности*/

        [detailsESFfield("tin", "6", "ИИН/БИН", 12, 12, FillingType.NUMBER, FillingMethod.AUTO_MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
         "1. Проверка на обязательность заполнения.При отсутствии реквизита: ИИН/БИН поставщика отсутствует." +
         "2. Проверка наличия ИИН / БИН в БД ИСЭСФ.При отсутствии сообщение: ИИН / БИН поставщика отсутствует в БД ИС ЭСФ." +
         "3. Проверка наличия признака блокировки работы в ИС ЭСФ.Механизм описан в СТПО шифр398.13024001364901.00.01.03 - 01.2017. При наличии признака блокировки работы НП в ИС ЭСФ сообщение: Выписка ЭСФ заблокирована.",

         "1) При авторизации в ИС ЭСФ в качестве сотрудника ЮЛ и создании ЭСФ, автоматическое заполнение данными из ключа ЮЛ." +
         "2) При авторизации в ИС ЭСФ в качестве ИП и создании ЭСФ, автоматическое заполнение данными из ключа ФЛ." +
         "3) Возможность указать ИИН/БИН Доверителя." +
         "4) Возможность указать ИИН/БИН Подрядчика" +
         "5) При автоматическом заполнении поле заблокировано для редактирования." +
         "6) Возможность заполнения вручную при размножении раздела B." +
         "7) Автоматическое заполнение БИН головного предприятия, если в настройках выбрано значение «Отображать в ЭСФ» для выписки ЭСФ за головное предприятие.")]
        public string sellerTin;


        [detailsESFfield("reorganizedTin", "6.1", "БИН реорганизованного лица", 12, 12, FillingType.NUMBER, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
         "При указании значения проверка наличия БИН в БД ИС ЭСФ.При несоответствии сообщение: БИН реорганизованноголица поставщика не найден в БД ИС ЭСФ." +
         "Механизм реорганизации описан в СТПО шифр 398.13024001364901.00.02.01 - 01.2017.")]
        public string sellerReorganizedTin;

        [detailsESFfield("", "", "Код органа государственных доходов", 4, 6, FillingType.NUMBER, FillingMethod.AUTO, IsPrintable.NOT_PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
         "",
         "Автоматическое заполнение кода органа государственных доходов (КОГД) из данных БД ИС ЭСФ.",
         "Автоматическое заполнение кода органа государственных доходов (КОГД) из данных БД ИС ЭСФ.")]
        public string sellerTaxStateDepCode;


        [detailsESFfield("", "", "БИН структурной единицы(филиала)", 12, 12, FillingType.NUMBER, FillingMethod.AUTO_MANUAL, IsPrintable.NOT_PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
         "",
         "1) Автоматическое заполнение БИН филиала / представительства, если в настройках выбран параметр «Отображать ЭСФ»позволяющий выписывать ЭСФ за головное предприятие",
         "1) Проверка наличия в БД связи структурной единицы с головным предприятием.При отсутствии связи сообщение: Указанный БИН не является структурной единицей(филиалом) поставщика, указанного в поле 6-ИИН/БИН."+
         "2) Проверка наличия у филиала/представительства установленного параметра «Отображать ЭСФ», позволяющего выписывать ЭСФ за головное предприятие.В случае отсутствия установленного параметра сообщение: У филиала/представительства отсутствуют полномочия по выписке ЭСФ за головное предприятие.")]
        public string sellerFilialTin;

        [detailsESFfield("name", "7", "Наименование поставщика", 3, 450, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
         "Проверка на обязательность заполнения. При отсутствии реквизита сообщение: Наименование поставщика отсутствует.",
         "Автоматическое заполнение из БД ИС ЭСФ на основании значения в поле 6-ИИН/БИН. Полезаблокировано для редактирования.При выборе интерфейса на казахском языке, если в справочнике отсутствует наименование на казахском языке, указывается наименование на русском языке")]
        public string seller;

        [detailsESFfield("shareParticipation", "7.1", "Доля участия", 0, 9, FillingType.NUMBER, FillingMethod.MANUAL, IsPrintable.NOT_PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
         "Возможность ввода дробных чисел в десятичном виде, но не более шести знаков после запятой. ",
         "1) Отображается, если в поле 10-Категорияпоставщика отмечена категория F-Участник договора о совместной деятельности- и заполнено поле 10.1-Количество." +
         "2) Возможность указать вручную долей участия каждого участника.",
         "Проверка на наличие указания в поле 10-Категория поставщика категории F-Участник договора о совместной деятельности- и заполнение поля 10.1-Количество. При несоответствии сообщение: Поле -Доля участия- не может быть заполнено, если не указана категория поставщика F-Участникдоговора о совместной деятельности-.")]
        public string sellerShareParticipation;

        [detailsESFfield("address", "8", "Адрес места нахождения", 3, 450, FillingType.STRING, FillingMethod.AUTO, IsPrintable.NOT_PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
         "",
         "")]
        public string sellerAddress;

		#endregion

		#region 9 Свидетельство плательщика НДС:

		[detailsESFfield("certificateSeries", "9.1", "серия", 5, 5, FillingType.NUMBER, FillingMethod.AUTO, IsPrintable.NOT_PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
         "",
         "1) Проверка наличия данных о серии и номере свидетельства плательщика НДС."+
         " 1.1) При отсутствии данных в БД ИС ЭСФ или если поставщик не является плательщиком НДС, поля остаются не заполненными."+
         " 1.2) При наличии данных вБД ИС ЭСФ автоматическое заполнение.Поле заблокировано для редактирования. а) Если поставщикомявляется юридическое лицо с признаком -филиал-, заполнение производится данными головного предприятия.",
         "Проверка указанной серии и номера свидетельства НДС в данных БД ИС ЭСФ.При отсутствии сообщение: Неверно указаны реквизиты свидетельства по НДС налогоплательщика")]
        public string sellerCertificateSeries;

        [detailsESFfield("certificateNum", "9.2", "серия", 7, 7, FillingType.NUMBER, FillingMethod.AUTO_MANUAL, IsPrintable.NOT_PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
         "",
         "1) Проверка наличия данных о серии и номере свидетельства плательщика НДС." +
         " 1.1) При отсутствии данных в БД ИС ЭСФ или если поставщик не является плательщиком НДС, поля остаются не заполненными." +
         " 1.2) При наличии данных вБД ИС ЭСФ автоматическое заполнение.Поле заблокировано для редактирования. а) Если поставщикомявляется юридическое лицо с признаком -филиал-, заполнение производится данными головного предприятия.",
         "Проверка указанной серии и номера свидетельства НДС в данных БД ИС ЭСФ.При отсутствии сообщение: Неверно указаны реквизиты свидетельства по НДС налогоплательщика")]
        public string sellerCertificateNum;
        #endregion

        #region 10 Категория поставщика: <statuses>

        [detailsESFfield("status", "10 A", "Kомитент", 0, 10, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
        "Взаимоисключающие категории c Комиссионер")]
        public bool sellerIsCommitent;

        [detailsESFfield("status", "10 B", "Комиссионер", 0, 10, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
        "Взаимоисключающие категории c Kомитент")]
        public bool sellerIsCommissioner;

        [detailsESFfield("status", "10 C", "Экспедитор", 0, 10, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED)]
        public bool sellerIsForwarder;

        [detailsESFfield("status", "10 D", "Лизингодатель", 0, 10, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED)]
        public bool sellerIsLessor;

        [detailsESFfield("status", "10 E", "Участник СРП", 0, 10, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
            "",
            "1) При выборе значения «Е - Участник СРП», проверка наличия БИН поставщика в справочнике -Участники СРП-. Если БИН поставщика отсутствует в справочнике -Участники СРП-, то сообщение: «Указанный БИН не является участником СРП» и галочка снимается.",
            "1) Если поле отмечено, проверка наличия БИН поставщика в справочнике -Участники СРП-. При отсутствии БИН сообщение: Указанный БИН не является участником СРП")]
        public bool sellerIsPartisipantSRP;

        [detailsESFfield("status", "10 F", "Участник договора о совместной деятельности", 1, 1, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
            "",
            "",
            "Проверка на наличие отметки, если имеется тиражирование разделов В и В1.При несоответствии сообщение: «Отсутствует отметка категории «F участник договора о совместной деятельности», тиражирование разделов В и В1 недопустимо».")]
        public bool sellerIsPartisipantAoJA;//participant agreement on joint activities

        [detailsESFfield("status", "10 G", "Экспортер", 0, 10, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED)]
        public bool sellerIsExporter;

        [detailsESFfield("status", "10 H", "Международный перевозчик", 1, 1, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED)]
        public bool sellerIsInternationalCarrier;

        [detailsESFfield("status", "10 I", "Доверитель", 0, 10, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
           "",
           "",
           "Если в разделе I в поле «35 БИН» заполнен БИН Поверенного, проверка обязательности заполнения.При отсутствии реквизита сообщение: Не выбрана категория поставщика I - доверитель")]
        public bool sellerIsPrincipal;

        [detailsESFfield("", "10.1", "Количество", 1, 2, FillingType.NUMBER, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
           "Проверка, что значение, указанное в поле, больше чем 1.При некорректном заполнении отображается сообщение: Единственный поставщик не можетявляться участником совместной деятельности.",
           "1) Поле должно отображаться, если в поле 10 -Категорияпоставщика- отмечена категория F -Участник договора о совместной деятельности-, поумолчанию заполняется значением -1-."+
           "2) Поле отображается только для первого участника договора о совместной деятельности. Для остальных участников в размножаемых разделах B поле не отображается.",
           "1) Проверка на наличие указания в поле 10 -Категория поставщика- категории -F -Участник договора о совместной деятельности-. При несоответствии сообщение: Поле -Количество- не может быть заполнено, если не указана категория поставщика F -Участник договора о совместной деятельности-."+
           "2) Проверка соответствия тиражирования разделов В, В1 и H числовому значению, указанному в поле.При несоответствии сообщение: Количество разделов В, В1 и H не соответствует указанному количеству».")]
        public string sellerParticipantQuantity;

        [detailsESFfield("trailer", "11", "Дополнительные сведения", 0, 255, FillingType.STRING, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED)]
        public string sellerAdditionalDetails;
        #endregion        

        #region Раздел B1 Банковские реквизиты поставщика 
        /*Если в поле 10 "Категория поставщика" отмечена категория «Е- Участник СРП» или "F - Участник договора о совместной деятельности" и заполненополе 10.1 "Количество",
         * раздел B1 размножается для каждого участника совместной деятельности в соответствии с указанным количеством. Раздел B1 привязан к разделу B, 
         * маска отображения разделов: 1й поставщик B B1, 2й поставщик B B1.*/
        /*Проверка указанных данных в разделе B1 с данными БД. При несоответствии сообщение:"Указанных банковскихреквизитов нет в БД ИС ЭСФ".*/

        [detailsESFfield("kbe", "12", "Кбе", 0, 2, FillingType.NUMBER, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "1) Проверка на обязательность заполнения, если в поле 20 -Категория получателя- указана категория E -государственное учреждение-."+
        "2) Проверка на обязательность заполнения, если заполнено одно из полей 13 ИИК, 14 БИК, 15 Наименование банка. При отсутствии реквизита сообщение: Кбе отсутствует.")]
        public string Kbe;


        [detailsESFfield("iik", "13", "ИИК(Расчетный счет)", 20, 20, FillingType.STRING, FillingMethod.AUTO_MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "1) Проверка на обязательность заполнения, если в поле 20 -Категорияполучателя- указана категория E -государственное учреждение- или заполнено одно из полей 12 Кбе, 14 БИК, 15 Наименование банка. При отсутствии реквизита сообщение: ИИК отсутствует" +
        "2) Проверка длины указанного значения. При несоответствии сообщение: ИИК должен содержать 20 символов.",
        "При вводе отображается выпадающий список из счетов НП, сохраненных в БД ИС ЭСФ.")]
        public string sellerIIK;

        [detailsESFfield("bik", "14", "БИК", 0, 8, FillingType.STRING, FillingMethod.AUTO_MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
       "1) Проверка на обязательность заполнения, если в поле 20 -Категория получателя- указана категория E -государственное учреждение- или заполнено одно из полей 12 Кбе, 13 ИИК, 15 Наименование банка.При отсутствии реквизита сообщение: БИК отсутствует." +
       "2)  Проверка длины указанного значения. При несоответствии сообщение: БИК должен содержать 8 символов.",
       "Автоматическое заполнение из данных БД без возможности редактирования на основании выбранного ИИК в поле 13.")]
        public string sellerBIK;

        [detailsESFfield("bank", "15", "Наименование Банка", 1, 200, FillingType.STRING, FillingMethod.AUTO_MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
       "1) Проверка на обязательность заполнения, если в поле 20 -Категория получателя- указана категория E -государственное учреждение- или заполнено одно из полей 12 Кбе, 13 ИИК, 14 БИК.При отсутствии реквизита сообщение: Наименование Банка отсутствует.",
       "Автоматическое заполнение из данных БД без возможности редактирования на основании выбранного ИИК в поле 13.")]
        public string bankName;
        #endregion

        #endregion

        #region Раздел С Реквизиты получателя	

        #region General

        /*1) Если в поле 20 "Категория поставщика" отмечена категория "D - Участник договора о совместной
         * деятельности" или «G - участник СРП или сделки, заключенной в рамках СРП» и заполнено поле 20.1
         * "Количество", раздел C размножается для каждого участника совместной деятельности в
         * соответствии с указанным количеством.
         * 2) При этом должна быть возможность удаления разделов C при изменении количества участников
         * совместной деятельности или участников СРП.*/

        [detailsESFfield("tin", "16", "ИИН/БИН", 1, 50, FillingType.NUMBER, FillingMethod.AUTO_MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
         "1) Не обязательно для заполнения, если в поле 20 выбраны категории F -Нерезидент- или I -Розничная реализация-." +
         "2) Если в поле 20 -Категория получателя- указана категория F -нерезидент-, проверка на размерность поля не выполняется.Возможность ввода значения с 1 до 50 символов." +
         "3) Проверка на обязательность заполнения, если в поле 20 не выбраны категории F -Нерезидент- или I -Розничная реализация-. При отсутствии реквизита сообщение: ИИН/БИН получателя отсутствует. "+
         "4) Если в поле 20 -Категория получателя- не указана категория F -нерезидент-, проверка на размерность поля = 12 символов.При несоответствии сообщение: ИИН/БИН получателя должен быть 12 символов."+
         "5) Если в поле 20 -Категория получателя- не указана категория F -нерезидент-, проверка на наличие ИИН / БИН в БД. При несоответствии сообщение: ИИН/БИН получателя отсутствует в БД ИС ЭСФ"+
         "6) Проверка наличия признака блокировки работы в ИС ЭСФ.Механизм описан в СТПО шифр 398.13024001364901.00.01.03 - 01.2017 При наличии признака блокировки работы НП в ИС ЭСФ сообщение: «Получатель заблокирован».",

         "1) Если указанный ИИН имеет регистрационный учет ИП, то отображать для выбора профили ФЛ и ИП." +
         "2) Возможность вручную указать ИИН / БИН подрядчика, если в разделе J в поле 39 -БИН- заполнено БИН оператора. "+
         "3) Возможность указатьвручную ИИН / БИН доверителя, если в разделе J в поле 39 -БИН- заполнено БИН поверенного.",

         "Если в разделе J заполнено поле 39 -БИН-, проверка на дублирование ИИН / БИН, указанного в поле 16 и в поле 39, не должно быть совпадений. Если имеется совпадение, то выдает сообщение: ИИН / БИН доверителя/подрядчика Получателя совпадает с данными поверенного/оператора, указанного в разделе J.")]
        public string customerTin;


        [detailsESFfield("reorganizedTin", "16.1", "ИИН/БИН", 12, 12, FillingType.NUMBER, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
         "При указании значения проверка наличия БИН в БД ИС ЭСФ.При несоответствии сообщение: БИН реорганизованного лица получателя отсутствует в БД ИС ЭСФ.Механизм реорганизации описан в СТПО шифр 398.13024001364901.00.02.01 - 01.2017.")]
        public string customerReorganizedTin;

        [detailsESFfield("", "", "БИН структурной единицы(филиала)", 12, 12, FillingType.NUMBER, FillingMethod.MANUAL, IsPrintable.NOT_PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
         "Проверка наличия в БД связи структурной единицы с головным предприятием по данным ЕХД.При отсутствии связи сообщение: Указанный БИН не является структурной единицей(филиалом) получателя, указанного в поле 16 -ИИН/БИН-.")]
        public string customerFilialTin;

        [detailsESFfield("name", "17", "Получатель", 3, 450, FillingType.STRING, FillingMethod.AUTO_MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
         "Проверка на обязательность заполнения. При отсутствии реквизита сообщение: Наименование получателя отсутствует.",
         "1)Автоматическое заполнение из БД ИС ЭСФ на основании значения в поле 16-ИИН/БИН. Полезаблокировано для редактирования.При выборе интерфейса на казахском языке, если в справочнике отсутствует наименование на казахском языке, указывается наименование на русском языке"+
         "2) Если в поле 20 -Категория получателя- указана категория I -розничная реализация- и поле 16 -ИИН/БИН- не заполнено, то автоматически проставлять сообщение -Физические лица- без возможности редактирования"+
         "3) Если в поле 20 -Категория получателя- указана категория F -нерезидент- возможность ручного ввода. ")]
        public string customer;

        [detailsESFfield("shareParticipation", "17.1", "Доля участия", 0, 9, FillingType.NUMBER, FillingMethod.MANUAL, IsPrintable.NOT_PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
         "Возможность ввода дробных чисел в десятичном виде, но не более шести знаков после запятой. ",
         "1) Отображается, если в поле 20-Категория получателя- отмечена категория D-Участник договора о совместной деятельности-",
         "Проверка на наличие указания в поле 20-Категория получателя- категории D-Участник договора о совместной деятельности-. При несоответствии сообщение: Поле -Доля участия- не может быть заполнено, если не указана категория поставщика D-Участник договора о совместной деятельности-.")]
        public string customerShareParticipation;

        [detailsESFfield("address", "18", "Адрес места нахождения", 3, 450, FillingType.STRING, FillingMethod.AUTO_MANUAL, IsPrintable.NOT_PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
         "",
         "1) Автоматическое заполнение из данных БД ИС ЭСФ на основании значения в поле -16 - ИИН/БИН- на дату выписки ЭСФ. Поле заблокировано для редактирования." +
         "1.1) При выборе интерфейса на казахском языке, если в БД ИС ЭСФ отсутствует адрес места жительства/ нахождения на казахском языке, указывается адрес места жительства/ нахождения на русском языке." +
         " При отсутствии адреса места жительства/ нахождения в БД ИС ЭСФ на русском и казахском языках, отображается сообщение: -Адрес отсутствует в БД ИС ЭСФ-, и поле остается незаполненным без возможности редактирования. " +
         "2) Если в поле 20 -Категория получателя-указана категория -I - розничная реализация- и поле 16 -ИИН/БИН- не заполнено, то автоматически проставляется сообщение -Розничная торговля-. " +
         "3) Возможность ручного ввода, если в поле 20 -Категория получателя-указана категория -F - нерезидент-. При не заполнении сообщение: -Адрес местонахождения получателя отсутствует-.")]
        public string customerAddress;

        [detailsESFfield("countryCode", "18.1", "Код страны получателя", 0, 2, FillingType.STRING, FillingMethod.CATALOG, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
         "Проверка на обязательность заполнения. При отсутствии реквизита сообщение: Код страны получателя отсутствует.",
         "1) Автоматическое заполнение значением -KZ- без возможности редактирования, если в поле 10 -Категория поставщика- не указана категория -G - экспортер-, -H -международный перевозчик-, -C - экспедитор-. " +
         "2) Возможность выбора из справочника «Страна» если в поле 10 -Категория поставщика- указана одна из категорий -G - экспортер-, -H - международный перевозчик-, -C - экспедитор-.",
         "1) Проверка указанного кода страны с данными БД. При отсутствии данных сообщение: «Код страны получателя не найден в справочнике «Страна»». " +
         "2) Проверка указания кода -KZ-, если в поле 10 -Категория поставщика- не указана одна из категорий -G - экспортер-, -H - международный перевозчик-, -C - экспедитор-. " +
         "При несоответствии сообщение: -Страна получателя не равна значению «Казахстан», в то время как отправитель не является экспортером, экспедитором или международным перевозчиком-.")]
        public string customerCountryCode;

        [detailsESFfield("trailer", "19", "Дополнительные сведения", 0, 255, FillingType.STRING, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED)]
        public string customerAdditionalDetails;
		#endregion

		#region 20 Категория получателя: <statuses>

		[detailsESFfield("status", "20 A", "Kомитент", 0, 10, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
        "Взаимоисключающие категории c Комиссионер")]
        public bool customerIsCommitent;

        [detailsESFfield("status", "20 B", "Комиссионер", 0, 10, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
        "Взаимоисключающие категории c Kомитент")]
        public bool customerIsCommissioner;

        [detailsESFfield("status", "20 C", "Лизингодатель", 0, 10, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED)]
        public bool customerIsLessor;

        [detailsESFfield("status", "20 D", "Участник договора о совместной деятельности", 0, 10, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED)]
        public bool customerIsPartisipantAoJA;//participant agreement on joint activities

        [detailsESFfield("status", "20 E", "государственное учреждение", 0, 10, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED)]
        public bool customerIsGovermentAgency;

        [detailsESFfield("status", "20 F", "нерезидент", 0, 10, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED)]
        public bool customerIsNotResident;

        [detailsESFfield("status", "20 G", "Участник СРП", 0, 10, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
            "",
            "При ручном выборе значения «G - участник СРП или сделки, заключенной в рамках СРП» проверка наличия БИН покупателя в справочнике -Участники СРП-. " +
            "Если БИН покупателя отсутствует в справочнике -Участники СРП-, то отображается сообщение: «Указанный БИН не является участником СРП» и галочка снимается.",
            "1) Если поле отмечено, проверка наличия БИН поставщика в справочнике -Участники СРП-. При отсутствии БИН сообщение: Указанный БИН не является участником СРП")]
        public bool customerIsPartisipantSRP;

        [detailsESFfield("status", "20 H", "Доверитель", 0, 10, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
           "",
           "",
           "Если в разделе J в поле «39 БИН» заполнен БИН Поверенного, проверка обязательности заполнения.При отсутствии реквизита сообщение: Не выбрана категория поставщика H - доверитель")]
        public bool customerIsPrincipal;

        [detailsESFfield("status", "20 I", "Розничная реализация", 0, 10, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
           "Проверка запрета указания, если в поле 20 -Категория получателя-, указаны категории «H - доверитель», «A - комитент», «C - лизингополучатель», «E – государственное учреждение» «G – участник СРП». " +
            "При несоответствии сообщение: -В категории получателя при выборе категории I дополнительно нельзя выбрать категории A, C, E, G, H-.")]
        public bool customerIsRetailer;

        [detailsESFfield("status", "20 I", "Розничная реализация", 0, 10, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.NOT_DISPLAYED, IsRequired.NOT_REQUIRED,
          "Если чек-бокс не выбран и в поле «16 – ИИН / БИН» выбран ИИН, то определять получателя как ИП. Если чек - бокс выбран и в поле «16 – ИИН / БИН» выбран ИИН, то определять получателя как ФЛ.")]
        public bool customerIsPhys;

        [detailsESFfield("", "20.1", "Количество", 0, 2, FillingType.NUMBER, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
           "Проверка, что значение, указанное в поле, больше чем 1.При некорректном заполнении отображается сообщение: Единственный получатель не может являться участником совместной деятельности.",
            "1) Поле должно отображается, если в поле 20 -Категория получателя-отмечена категория -D - участник договора о совместной деятельности-, по умолчанию заполняется значением -1-. " +
            "2) Поле отображается только для первого участника договора о совместной деятельности. Для остальных участников в размножаемых разделах C поле не отображается.",
            "1) Проверка на наличие указания в поле 20 -Категория получателя-категории - D - участник договора о совместной деятельности-. При несоответствии сообщение: «Поле «Количество» не может быть заполнено, если не указана категория получателя -D - Участник договора о совместной деятельности-»." +
            "2) Проверка соответствия тиражирования разделов С и Н числовому значению, указанному в поле. При несоответствии сообщение: «Количество разделов С и Н не соответствует указанному количеству»")]
        public string customerParticipantQuantity;
        #endregion

        #region Раздел C1 Реквизиты государственного учреждения 
        /*Проверка на обязательность заполнения, если в поле 20 "Категория получателя" указана категория "E - государственное учреждение"
         * и в поле 16 "ИИН/БИН" не указан БИН Национального банка (941240001151) или его структурного подразделения. 
         * При отсутствии "Необходимо заполнить раздел С1, если выбрана категория получателя «E - государственное учреждение»".*/

        [detailsESFfield("iik", "21", "ИИК(Расчетный счет)", 0, 20, FillingType.STRING, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "Проверка на обязательность заполнения, если в поле 20 -Категория получателя-указана категория -E - государственное учреждение-. При отсутствии реквизита сообщение: -ИИК государственного учреждения отсутствует-.")]
        public string customerIIK;

        [detailsESFfield("productCode", "22", "Код товаров (работ, услуг)", 0, 10, FillingType.NUMBER, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED)]
        public string productCode;

        [detailsESFfield("payPurpose", "23", "Назначение платежа", 0, 240, FillingType.NUMBER, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "Проверка на обязательность заполнения, если в поле 20 -Категория получателя-указана категория -E - государственное учреждение-. " +
        "При отсутствии реквизита сообщение: -Назначение платежа отсутствует-. Исключить символы: пробел в начале текста, табуляция, двоеточие, enter.")]
        public string payPurpose;

        [detailsESFfield("bik", "24", "БИК", 8, 8, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "",
        "Автоматическое заполнение значением KKMFKZ2A. Заблокировано для редактирования",
        "Проверка на указание значения «KKMFKZ2A». При несоответствии сообщение: «В поле «БИК» должно быть указано значение KKMFKZ2A»")]
        public string customerBIK;
        #endregion

        #endregion

        #region Раздел D Реквизиты грузоотправителя и грузополучателя

        #region 25 Грузоотправитель <Consignor>

        [detailsESFfield("tin", "25.1", "ИИН/БИН", 12, 12, FillingType.NUMBER, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
         "1) При указании значения проверка на наличие ИИН/БИН в БД ИС ЭСФ. При отсутствии сообщение: -ИИН/БИН грузоотправителя не найден в БД ИС ЭСФ-. " +
         "2) Проверка наличия признака блокировки работы в ИС ЭСФ Механизм описан в СТПО шифр 398.13024001364901.00.01.03-01.2017 При наличии признака блокировки работы НП в ИС ЭСФ сообщение: «Грузоотправитель заблокирован».")]
        public string consignorTin;

        [detailsESFfield("name", "25.2", "Наименование", 3, 98, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
         "",
         "Автоматическое заполнение из БД ИС ЭСФ, если заполнено поле 25.1 -ИИН/БИН грузоотправителя- без возможности редактирования.")]
        public string consignorName;

        [detailsESFfield("address", "25.3", "Наименование", 0, 98, FillingType.STRING, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED)]
        public string consignorAddress;

        #endregion

        #region 26 Грузополучатель <Consignee>

        [detailsESFfield("tin", "26.1", "ИИН/БИН", 1, 50, FillingType.NUMBER, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
         "Если в поле 26.4 «Код страны» указана страна «KZ» проверка наличие ИИН/БИН в БД ИС ЭСФ. При отсутствии сообщение: -ИИН/БИН грузополучателя не найден в БД ИС ЭСФ-.",
         "Если в поле 26.4 «Код страны» указана страна не «KZ», поле должно быть заблокировано для выбора")]
        public string consigneeTin;

        [detailsESFfield("name", "26.2", "Наименование", 3, 255, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
         "",
         "Автоматическое заполнение из БД ИС ЭСФ, если заполнено поле 26.1 -ИИН/БИН грузополучателя- без возможности редактирования.")]
        public string consigneeName;

        [detailsESFfield("address", "26.3", "Наименование", 0, 255, FillingType.STRING, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED)]
        public string consigneeAddress;

        [detailsESFfield("countryCode", "26.4", "Код страны получателя", 0, 2, FillingType.STRING, FillingMethod.CATALOG, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
         "Проверка на обязательность заполнения. При отсутствии реквизита сообщение: Код страны грузополучателя отсутствует.",
         "1) Автоматическое заполнение значением -KZ- без возможности редактирования, если в поле 10 -Категория поставщика- не указаны категории -E - участник СРП-, или -G - экспортер-, или -H - международный перевозчик-. " +
         "2) Возможность выбора из справочника «Страна», если в поле 10 -Категория поставщика- указаны категории -E - участник СРП-, -G - экспортер- или -H - международный перевозчик-.",
         "1) Проверка указанного кода страны с данными БД. При отсутствии данных сообщение: «Код страны грузополучателя не найден в справочнике «Страна»». " +
         "2) Проверка указания кода -KZ-, если в поле 10 -Категория поставщика- не указана одна из категорий -E - участник СРП-, -G - экспортер- или -H - международный перевозчик-. " +
         "При несоответствии сообщение: -Страна грузополучателя не равна значению «Казахстан», в то время как отправитель не является экспортером, участником СРП или международным перевозчиком-.")]
        public string consigneeCountryCode;

        #endregion

        #endregion

        #region Раздел E Договор (контракт) <DeliveryTerm>

        [detailsESFfield("hasContract", "27.1", "Договор(контракт) на поставку товаров, работ, услуг", 0, 10, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "Взаимоисключающие поля c 27.2")]
        public bool withoutContract;

        [detailsESFfield("hasContract", "27.2", "Без договора(контракта) на поставку товаров, работ, услуг", 0, 10, FillingType.CHECKBOX, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "Взаимоисключающие поля c 27.1")]
        public bool withContract;

        [detailsESFfield("contractNum", "27.3", "Номер договора(контракт) на поставку товаров (работ, услуг)", 0, 18, FillingType.STRING, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "Проверка на обязательность заполнения, если заполнено поле 27.1 -Договор (контракт) на поставку товаров, работ, услуг-, или 27.4 -Дата-." +
        "При отсутствии реквизита сообщение: -№ Договора (контракта) на поставку товаров, работ, услуг' и 'Дата договора (контракта) на поставку товаров, работ, услуг' должны быть заполнены-.",
        "Поле заблокировано для заполнения, если заполнено поле 27.2 -Без договора (контракта) на поставку товаров, работ, услуг-.")]
        public string contractNum;

        [detailsESFfield("contractDate", "27.4", "Дата договора(контракт) на поставку товаров (работ, услуг)", 0, 10, FillingType.DATE_DDpMMpYYYY, FillingMethod.CALENDAR, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "Проверка на обязательность заполнения, если заполнено поле 27.1 -Договор (контракт) на поставку товаров, работ, услуг-, или 27.3 -Номер-." +
        "При отсутствии реквизита сообщение: -№ Договора (контракта) на поставку товаров, работ, услуг' и 'Дата договора (контракта) на поставку товаров, работ, услуг' должны быть заполнены-.",
        "Поле заблокировано для заполнения, если заполнено поле 27.2 -Без договора (контракта) на поставку товаров, работ, услуг-.")]
        public string contractDate;

        [detailsESFfield("term", "28", "Условия оплаты по договору", 0, 98, FillingType.STRING, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED)]
        public string contractTerm;

        [detailsESFfield("transportTypeCode", "29", "Способ отправления", 0, 2, FillingType.NUMBER, FillingMethod.CATALOG, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,"","",
        "Проверка указанного кода способа отправления в справочнике.При отсутствии данных сообщение: «Способ отправления не найден в справочнике «Способ отправления»».")]
        public string transportTypeCode;

        #region 30 Поставка товаров осуществлена по доверенности

        [detailsESFfield("warrant", "30.1", "Номер доверенности на поставку товаров (работ, услуг)", 0, 18, FillingType.STRING, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "Проверка на обязательность заполнения, если заполнено поле 30.1 При отсутствии реквизита сообщение: Номер доверенности отсутствует.")]
        public string warrantNum;

        [detailsESFfield("warrantDate", "30.2", "Дата доверенности на поставку товаров (работ, услуг)", 0, 10, FillingType.DATE_DDpMMpYYYY, FillingMethod.CALENDAR, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "Проверка на обязательность заполнения, если заполнено поле 30.1 При отсутствии реквизита сообщение: Дата доверенности отсутствует.")]
        public string warrantDate;

        [detailsESFfield("destination", "31", "Пункт назначения поставляемых товаров (работ, услуг)", 0, 98, FillingType.STRING, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED)]
        public string destination;

        [detailsESFfield("deliveryConditionCode", "31.1", "Условия поставки", 0, 3, FillingType.STRING, FillingMethod.CATALOG, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,"","",
        "Проверка указанного кода условия поставки в справочнике. При отсутствии данных сообщение: «Условие поставки не найдено в справочнике «Условия поставки»».")]
        public string deliveryConditionCode;

        #endregion

        #endregion

        #region Раздел F Реквизиты документов, подтверждающих поставку товаров, работ, услуг

        #region Документ, подтверждающий поставку товаров, работ, услуг

        [detailsESFfield("deliveryDocNum", "32.1", "Номер документа, подтверждающего поставку товаров (работ, услуг)", 0, 18, FillingType.STRING, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED)]
        public string deliveryDocNum;

        [detailsESFfield("deliveryDocDate", "32.2", "Дата документа, подтверждающего поставку товаров (работ, услуг)", 0, 10, FillingType.DATE_DDpMMpYYYY, FillingMethod.CALENDAR, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED)]
        public string deliveryDocDate;

        #endregion

        #endregion

        #region Раздел G Данные по товарам, работам, услугам

        [detailsESFfield("currencyCode", "33.1", "Код валюты", 3, 3, FillingType.STRING, FillingMethod.CATALOG, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "Проверка на обязательность заполнения. При отсутствии данных сообщение: Код валюты отсутствует.",
        "1) Автоматическое заполнение значением -KZT- без возможности редактирования, если в поле 10 -Категория поставщика- не указаны категории -E - участник СРП-,или -G - экспортер-, или -H - международный перевозчик- . " +
        "2) Возможность выбора из справочника, если в поле 10 -Категория поставщика- указаны категории -E - участник СРП-, -G - экспортер- или -H - международный перевозчик-.",
        "1) Проверка соответствия указанного кода валюты с кодами в справочнике. При отсутствии данных сообщение: «Код валюты не найден в справочнике». " +
        "2) Если в поле 10 -Категория поставщика- не указаны категории -E - участник СРП-, или -G - экспортер-, или -H - международный перевозчик- проверка указания кода валюта «KZT». " +
        "При несоответствии сообщение: -Поле 'Код Валюты'должно содержать значение KZT, если поставщики не являются экспортерами, международными перевозчиками или участниками СРП-.")]
        public string currencyCode;

        [detailsESFfield("currencyRate", "33.2", "Курс валюты", 1, 6, FillingType.NUMBER, FillingMethod.AUTO_MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "1) Если в поле 10 -Категория поставщика- указаны категории -G - экспортер-, или -H - международный перевозчик-, или -E - участник СРП», то поле обязательно для заполнения. При отсутствии реквизита сообщение: -Курс валюты отсутствует-. " +
        "2) Возможность ввода дробных чисел в десятичном виде, но не более шести знаков после запятой.",
        "1) Если в поле 10 -Категория поставщика-указаны категории -G - экспортер-, -E - участник СРП- или -H - международный перевозчик- и в поле 33.1 -Код валюты- указан код, отличный от -KZT- - автоматическое заполнение рыночным курсом, полученным из Нацбанка РК, на дату оборота, отраженную в ЭСФ. " +
        "2) Возможность редактирования курса, если в поле 10 -Категория поставщика- указана категория -E - участник СРП- и в поле 33.1 -Код валюты- указан код, отличный от -KZT-.",
        "Если в поле 10 -Категория поставщика- указана категории, кроме -E - участник СРП- и в поле 33.1 -Код валюты- указан код, отличный от -KZT-, " +
        "проверка соответствия указанного значения с рыночным курсом валют, полученным из Нацбанка РК, на дату оборота, отраженную в ЭСФ. " +
        "При несоответствии сообщение: -Значение не соответствует курсу валюты, определенному на дату оборота, отраженную в дополнительном ЭСФ, согласно официальным данным Нац.банка РК-.")]
        public string currencyRate;

        [detailsESFfield("", "G1", "№ п/п", 1, 3, FillingType.NUMBER, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "",
        "Автоматическое заполнение, если заполнено любое из полей G2-G18. Переход из графы в графу и на последующие строки предусмотреть через «Enter».",
        "")]
        public string rowNum;

        [detailsESFfield("truOriginCode", "G2", "Признак происхождения ТРУ", 1, 1, FillingType.STRING, FillingMethod.CATALOG, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "Проверка на обязательность заполнения. При отсутствии реквизита сообщение: Признак происхождения товаров, работ, услуг отсутствует.",
        "Ручной выбор из справочника «Признак происхождения».",
        "Проверка указанного признака происхождения ТРУ со справочником в БД. При несоответствии сообщение: «Признак происхождения товаров, работ, услуг не найден в справочнике «Признак происхождения»».")]
        public string truOriginCode;


        [detailsESFfield("description", "G3", "Наименование ТРУ", 2, 400, FillingType.STRING, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "Проверка на обязательность заполнения, если в графе G2 -Признак происхождения товаров, работ, услуг-, указано одно из значений -3-, -4-, -5-, -6-. При отсутствии реквизита сообщение: -Наименование товаров, работ, услуг отсутствует-",
        "",
        "")]
        public string truDescription;

        [detailsESFfield("tnvedName", "G3/1", "Наименование товаров по классификатору ТН ВЭД ЕАЭС", 2, 255, FillingType.STRING, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "Проверка на обязательность заполнения, если в графе G2 -Признак происхождения товаров, работ, услуг-, указано одно из значений -1-, -2-. " +
        "При отсутствии реквизита сообщение: -Наименование товаров в соответствии с Декларацией на товары или заявлением о ввозе товаров и уплате косвенных налогов отсутствует-.",
        "",
        "")]
        public string tnvedName;

        [detailsESFfield("unitCode", "G4", "Код товара (ТНВД ЕАЭС)", 0, 10, FillingType.STRING, FillingMethod.CATALOG, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "1) Проверка на обязательность заполнения, если в графе G2 -Признак происхождения товаров, работ, услуг-, указано одно из значений -1-, -2-, -3-При отсутствии реквизита сообщение: -Код товара (ТН ВЭД ЕАЭС) отсутствует-. " +
        "2) Проверка на обязательность заполнения, если в графе G2 -Признак происхождения товаров, работ, услуг-, указано значение -4-, при условии, что в строке 10 отмечена ячейка «G – экспортер»," +
            " а также в строке 18.1 -Код страны- указана одна из стран с признаком государства-члена ЕАЭС. При отсутствии реквизита сообщение: -Код товара (ТН ВЭД ЕАЭС) отсутствует-. " +
        "3) Если в графе G2 -Признак происхождения товаров, работ, услуг-, указано одно из значений -1- или -3-, то осуществлять проверку указания кода ТН ВЭД с признаком товара изъятия. " +
            "При вводе значения не имеющего признак товара изъятия отображается сообщение: -Код товара (ТН ВЭД ЕАЭС) не соответствует признаку происхождения товаров, работ, услуг-. " +
        "4) Если в графе G2 -Признак происхождения товаров, работ, услуг-, указано одно из значений -2- или -4- то осуществлять проверку указания кода ТН ВЭД без признака товара изъятия. " +
            "При вводе значения имеющего признак товара изъятия сообщение: -Код товара (ТН ВЭД ЕАЭС) не соответствует признаку происхождения товаров, работ, услуг-. " +
        "5) Если в графе G2 -Признак происхождения товаров, работ, услуг-, указано значение -5-, то -Код товара (ТН ВЭД ЕАЭС)- не обязательный к заполнению. " +
        "5.1) Если в графе G2 -Признак происхождения товаров, работ, услуг-, указано значение «5» и в строке 10 отмечена ячейка «G – экспортер», а также в строке 18.1 -Код страны- указана страна без признака государства-члена ЕАЭС, " +
            "то осуществлять проверку указания кода ТН ВЭД без признака товара изъятия. " +
            "При вводе значения имеющего признак товара изъятия отображается сообщение: -Код товара (ТН ВЭД ЕАЭС) не соответствует признаку происхождения товаров, работ, услуг-.",
        "",
        "Проверка указанного значения на соответствие с справочником ТН ВЭД. При несоответствии сообщение: «Код ТН ВЭД ЕАЭС не найден в справочнике «ТН ВЭД ЕАЭС»")]
        public string tnvedCode;

        [detailsESFfield("unitNomenclature", "G5", "Ед.изм", 0, 20, FillingType.STRING, FillingMethod.CATALOG, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "Проверка на обязательность заполнения, если в графе G2 -Признак происхождения товаров, работ, услуг-, указано одно из значений -1-, -2-, -3-, -4-, -5-. При отсутствии реквизита сообщение: -Единица измерения отсутствует-." ,
        "",
        "Проверка указанного значения на соответствие с справочником единиц измерения. При несоответствии сообщение: «Код единицы измерения не найден в справочнике «Единицы измерения»».")]
        public string unitNomenclature;

        [detailsESFfield("quantity", "G6", "Кол-во (объем)", 0, 12, FillingType.NUMBER, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "1) Проверка на обязательность заполнения, если в графе G2 -Признак происхождения товаров, работ, услуг-, указано одно из значений -1-, -2-, -3-, -4-, -5-. При отсутствии реквизита сообщение: -Количество (объем) отсутствует-. " +
        "2) Проверка на указание положительного значения в поле. При вводе некорректного значения сообщение: -Поле 'Кол-во (объем)' не может быть отрицательным-.",
        "",
        "")]
        public string unitQuantity;

        [detailsESFfield("unitPrice", "G7", "Цена (тариф) за единицу ТРУ без косвенных налогов", 0, 12, FillingType.NUMBER, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "1) Проверка на обязательность заполнения. При отсутствии реквизита сообщение: -Цена (тариф) за единицу товара, работы, услуги без косвенных налогов отсутствует-. " +
        "2) Проверка на указание положительного значения в поле. При вводе некорректного значения сообщение: -Поле 'Цена (тариф) за единицу товара, работы, услуги без косвенных налогов' не может быть отрицательным-. " +
        "3) Может быть дробным числом в десятичном виде, но не более двух знаков после запятой.",
        "",
        "")]
        public string unitPrice;

        [detailsESFfield("totalPriceWithoutTax", "G8", "Итоговая стоимость ТРУ без учета НДС", 1, 12, FillingType.NUMBER, FillingMethod.AUTO_MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "1) Проверка на обязательность заполнения. При отсутствии реквизита сообщение: -Стоимость товаров, работ, услуг без косвенных налогов отсутствует-. " +
        "2) Проверка на указание положительного значения в поле. При вводе некорректного значения сообщение: -Поле 'Стоимость товаров, работ, услуг без косвенных налогов' не может быть отрицательным-. " +
        "3) Может быть дробным числом в десятичном виде, но не более двух знаков после запятой.",
        "1) Если заполнены графы G6 и G7, автоматический расчет по формуле G6*G7. " +
        "2) Если не заполнена графа G7, заполнение вручную.",
        "Если заполнены графы G6 и G7, проверка на корректность автоматического расчета по формуле G6*G7. При несоответствии сообщение: «Стоимость товаров, работ, услуг без косвенных налогов указана некорректно».")]
        public string totalPriceWithoutTax;

        [detailsESFfield("exciseRate", "G9", "Акциз-Ставка", 0, 12, FillingType.NUMBER, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED)]
        public string exciseRate;

        [detailsESFfield("exciseAmount", "G10", "Акциз-Сумма", 0, 12, FillingType.NUMBER, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
        "Может быть дробным числом в десятичном виде, но не более двух знаков после запятой.")]
        public string exciseAmount;

        [detailsESFfield("turnoverSize", "G11", "Размер оборота по реализации(облагаемый/необлагаемый оборот)", 0, 12, FillingType.NUMBER, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "1) Может быть дробным числом в десятичном виде, но не более двух знаков после запятой. " +
        "2) Не может иметь отрицательное значение. При несоответствии сообщение: «Размер оборота по реализации (облагаемый/необлагаемый оборот) должен быть положительным».",
        "Автоматический расчет по формуле G8 + G10.",
        "Проверка на корректность автоматического расчета по формуле G8+G10. При несоответствии сообщение: «Размер оборота по реализации (облагаемый/необлагаемый оборот) указан некорректно».")]
        public string turnoverSize;

        [detailsESFfield("ndsRate", "G12", "Ставка НДС", 1, 7, FillingType.NUMBER, FillingMethod.AUTO_MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "1) Проверка на обязательность заполнения. При отсутствии реквизита сообщение: -Ставка НДС отсутствует-. " +
        "2) При указании значения отличного от -Без НДС-, проверка наличия активного регистрационного учета плательщика НДС на дату выписки ЭСФ. " +
        "При отсутствии сведений в рег.данных свидетельства НДС сообщение: -Пользователь не может указывать ставку НДС товаров, т.к. не имеет действующего регистрационного учета по НДС-.")]
        public string ndsRate;

        [detailsESFfield("ndsAmount", "G13", "Сумма НДС", 1, 12, FillingType.NUMBER, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "Может быть дробным числом в десятичном виде, но не более двух знаков после запятой.",
        "1) Автоматический расчет по формуле G11*G12. 2) Если в графе G12 -Ставка НДС- указано значение -Без НДС-, заполняется значение «0».",
        "1) Проверка на корректность автоматического расчета по формуле G11*G12. При несоответствии сообщение: «Сумма НДС указана некорректно». " +
        "2) Если в графе G12 -Ставка НДС- указано значение -Без НДС-, заполняется значение «0». При несоответствии сообщение: «Если в графе G12 -Ставка НДС- указано значение -Без НДС-, в G13 должно быть значение «0»».")]
        public string ndsAmount;

        [detailsESFfield("priceWithTax", "G14", "Стоимость ТРУ с учетом НДС", 1, 12, FillingType.NUMBER, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "1) Проверка на указание положительного значения в поле. При вводе некорректного значения сообщение: -Поле 'Стоимость товаров, работ, услуг с учетом косвенных налогов' не может быть отрицательным-. " +
        "2) Может быть дробным числом в десятичном виде, но не более двух знаков после запятой.",
        "Автоматический расчет по формуле G11 + G13.",
        "Проверка на корректность автоматического расчета по формуле G11+G13. При несоответствии сообщение: «Стоимость товаров, работ, услуг с учетом косвенных налогов указана некорректно».")]
        public string priceWithTax;

        [detailsESFfield("productDeclaration", "G15", "Декларации на товары, заявления в рамках ТС, СТ-1 или СТ-KZ", 11, 20, FillingType.STRING, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "1) Проверка на обязательность заполнения, если в графе G2 -Признак происхождения товаров, работ, услуг-указано значение -1-. " +
            "При отсутствии реквизита сообщение: -№ Декларации на товары, заявления о ввозе товаров и уплате косвенных налогов, СТ-KZ, СТ-1 отсутствует-. " +
        "2) Проверка на обязательность заполнения, если в графе G2 -Признак происхождения товаров, работ, услуг-указано значение -3- при условии, что в строке 10 отмечена ячейка «G – экспортер», " +
            "а также в строке 18.1 -Код страны- указана одна из стран с признаком государства-члена ЕАЭС. " +
            "При отсутствии реквизита сообщение: -№ Декларации на товары, заявления о ввозе товаров и уплате косвенных налогов, СТ-KZ, СТ-1 отсутствует-. " +
        "3) Если в графе G2 -Признак происхождения товаров, работ, услуг-указано значение -1- длина номера декларации или заявления о ввозе товаров и уплате косвенных налогов должна быть 18 или 20 символов. " +
            "При вводе некорректного значения отображается сообщение: -№ декларации на товары или заявления о ввозе товаров и уплате косвенных налогов должен содержать 18 или 20 символов-. " +
        "3.1) Если указано 18 символов, то осуществлять проверку соответствия номера следующему формату: " +
            "- первый фасет содержит 4 цифр; " +
            "- второй фасет содержит 8 цифр и соответствуют формату даты ддммгггг; " +
            "- третий фасет содержит 1 символ и может принимать значения -N- или -I-; " +
            "- четвертый фасет содержит 5 цифр. " +
            "При несоответствии сообщение: «Формат номера должен быть следующим: 1) первый фасет содержит 4 цифр; 2) второй фасет содержит 8 цифр и соответствуют формату даты ддммгггг; 3) третий фасет содержит 1 символ и может принимать значения -N- или -I-; 4) четвертый фасет содержит 5 цифр.» " +
        "3.2) Если указано 20 символов, то осуществлять проверку соответствия номера следующему формату: " +
            "- первый фасет содержит 5 цифр и слеш -/-; " +
            "- второй фасет содержит 6 цифр и соответствуют формату даты ддммгг и слеш -/-; " +
            "- третий фасет содержит 7 цифр. " +
            "При несоответствии сообщение: «Формат номера должен быть следующим: 1) первый фасет содержит 5 цифр и слеш -/-; 2) второй фасет содержит 6 цифр и соответствуют формату даты ддммгг и слеш -/-; 3) третий фасет содержит 7 цифр.». " +
        "3.2.1) Если в строке 10 отмечена ячейка «G – экспортер», а также в строке 18.1 -Код страны- указана страна с признаком государства-члена ЕАЭС и в поле указан 20-значный номер декларации, " +
            "то осуществлять проверку третьего фасета номера. Если в третьем фасете первый символ указан -1-, то отображается сообщение: -Товар является условно выпущенным и подлежит реализации " +
            "только на территории Республики Казахстан-. 4) Если в графе G2 -Признак происхождения товаров, работ, услуг-указано значение -3-, длина номера сертификата СТ-1 или СТ-KZ должна быть 11 или 13 символов. " +
            "При вводе некорректного значения отображается сообщение: -Номер сертификата СТ-1 или СТ-KZ должен содержать 11 или 13 символов-. " +
        "4.1) Если указано 11 символов, то осуществлять проверку соответствия номера следующему формату: - первый фасет содержит значение -KZ-; - второй фасет содержит 9 цифр. " +
            "При несоответствии сообщение: «Формат номера должен быть следующим: 1) первый фасет содержит значение -KZ-; 2) второй фасет содержит 9 цифр.». " +
        "4.2) Если указано 13 символов, то осуществлять проверку соответствия номера следующему формату: - первый фасет содержит значение -KZ-; - второй фасет - 2 символа; - третий фасет содержит 9 цифр. " +
            "При несоответствии сообщение: «Формат номера должен быть следующим: 1) первый фасет содержит значение -KZ-; 2) второй фасет - 2 символа; 3) третий фасет содержит 9 цифр.».")]
        public string productDeclaration;

        [detailsESFfield("productNumberInDeclaration", "G16", "Номер товарной позиции из заявления в рамках ТС или Декларации на товары", 0, 3, FillingType.NUMBER, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "Проверка на обязательность заполнения, если в графе G2 -Признак происхождения товаров, работ, услуг- указано значение -1-. " +
            "При отсутствии реквизита сообщение: -Номер товарной позиции из заявления о ввозе товаров и уплате косвенных налогов или Декларации на товары отсутствует-.")]
        public string productNumberInDeclaration;

        [detailsESFfield("catalogTruId", "G17", "Идентификатор товара, работ, услуг", 0, 36, FillingType.STRING, FillingMethod.CATALOG, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "Проверка на обязательность заполнения. При отсутствии реквизита сообщение: -Идентификатор товара, работ, услуг отсутствует-.")]
        public string catalogTruId;

        [detailsESFfield("additional", "G18", "Дополнительные данные", 0, 255, FillingType.STRING, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED)]
        public string additional;

        [detailsESFfield("", "", "Всего посчету", 1, 12, FillingType.NUMBER, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
            "",
        "Автоматический расчет отдельно по каждой из граф G8, G10, G11, G13, G14. Расчет производится суммированием значений по всем строкам.",
        "Проверка на корректность автоматического расчета. При несоответствии сообщение: «-Всего по счету- указано некорректно».")]
        public string totalBillAmount;

        #endregion

        #region Раздел H Данные по товарам, работам, услугам участников совместной деятельности <Participant>

        /*Раздел H размножается для каждого участника совместной деятельности в соответствии с указанным количеством, в случаях: 
         * 1) Если в поле 10 "Категория поставщика"отмечена категория "F - Участник договора о совместной деятельности"и заполнено поле 10.1 "Количество"; 
         * 2) Если в поле 20 "Категория получателя"отмечена категория "D - Участник договора о совместной деятельности"и заполнено поле 20.1 "Количество".*/

        [detailsESFfield("tin", "34.1", "ИИН/БИН участника совместной деятельности", 12, 12, FillingType.NUMBER, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,"",
        "Автоматическое заполнение значениями, указанными в поле 6 -ИИН/БИН поставщика-или в поле 16 -ИИН/БИН получателя-. Поле заблокировано для редактирования.",
        "Проверка на соответствие со значениями, указанными в поле 6 -ИИН/БИН поставщика- или в поле 16 -ИИН/БИН получателя-. " +
            "При несоответствии сообщение: «ИИН/БИН участника совместной деятельности не соответствует указанному значению в поле 6 -ИИН/БИН поставщика-или в поле 16 -ИИН/БИН получателя-».")]
        public string participantTin;

        [detailsESFfield("reorganizedTin", "34.2", "БИН реорганизованного лица", 12, 12, FillingType.NUMBER, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
        "Механизм реорганизации описан в СТПО шифр 398.13024001364901.00.02.01- 01.2017",
        "Автоматическое заполнение значениями, указанными в поле 6.1 -БИН реорганизованного лица поставщика- или в поле 16.1 -БИН реорганизованного лица получателя-. Поле заблокировано для редактирования.",
        "Проверка на соответствие со значениями, указанными в поле 6.1 -БИН реорганизованного лица поставщика- или в поле 16.1 -БИН реорганизованного лица получателя-. " +
            "При несоответствии сообщение: «БИН реорганизованного лица не соответствует указанному значению в поле 6.1 -БИН реорганизованного лица поставщика- или в поле 16.1 -БИН реорганизованного лица получателя-».")]
        public string reorganizedTin;


        [detailsESFfield("productNumber", "H1", "№ п/п", 1, 3, FillingType.NUMBER, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "",
        "Поле заблокировано для редактирования.",
        "")]
        public string p_rowNum;

        [detailsESFfield("", "H2", "Признак происхождения ТРУ", 1, 1, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "",
        "Автоматическое заполнение значением, указанным в графе G2. Поле заблокировано для редактирования",
        "Проверка на соответствие со значением, указанным в графе G2. При несоответствии сообщение: «H2 Признак происхождения товаров, работ, услуг не соответствует указанному значению в графе G2».")]
        public string p_truOriginCode;


        [detailsESFfield("", "H3", "Наименование ТРУ", 0, 255, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "",
        "Автоматическое заполнение значением, указанным в графе G3. Поле заблокировано для редактирования",
        "Проверка на соответствие со значением, указанным в графе G3. При несоответствии сообщение: «H3 Наименование товаров, работ, услуг не соответствует указанному значению в графе G3».")]
        public string p_truDescription;

        [detailsESFfield("", "H3/1", "Наименование товаров по классификатору ТН ВЭД ЕАЭС", 0, 255, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "",
        "Автоматическое заполнение значением, указанным в графе G3/1. Поле заблокировано для редактирования",
        "Проверка на соответствие со значениями, указанными в графе G3/1. При несоответствии сообщение: «H3/1 не соответствует указанному значению в графе G3/1».")]
        public string p_tnvedName;

        [detailsESFfield("", "H4", "Код товара (ТНВД ЕАЭС)", 0, 10, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "",
        "Автоматическое заполнение значением, указанным в графе G4. Поле заблокировано для редактирования",
        "Проверка на соответствие со значениями, указанными в графе G4. При несоответствии сообщение: «H4 Код товара (ТН ВЭД ЕАЭС) не соответствует указанному значению в графе G4».")]
        public string p_tnvedCode;

        [detailsESFfield("", "H5", "Ед.изм", 0, 10, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "",
        "Автоматическое заполнение значением, указанным в графе G5. Поле заблокировано для редактирования",
        "Проверка на соответствие со значениями, указанными в графе G5. При несоответствии сообщение: «H5 Ед.изм не соответствует указанному значению в графе G5».")]
        public string p_unitNomenclature;

        [detailsESFfield("quantity", "H6", "Кол-во (объем)", 0, 12, FillingType.NUMBER, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED)]
        public string p_unitQuantity;

        [detailsESFfield("priceWithoutTax", "H7", "Стоимость ТРУ без учета НДС", 0, 12, FillingType.NUMBER, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "",
        "Автоматическое заполнение значением, указанным в графе G7. Поле заблокировано для редактирования.",
        "Проверка на соответствие со значениями, указанными в графе G7. При несоответствии сообщение: «H7 не соответствует указанному значению в графе G7».")]
        public string p_unitPrice;

        [detailsESFfield("", "H8", "Итоговая стоимость ТРУ без учета НДС", 1, 12, FillingType.NUMBER, FillingMethod.AUTO_MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "1) Проверка соответствия суммарного значения в разделе H со значением в разделе G, если раздел H заполняется для каждого участника совместной деятельности поставщика. " +
            "При несоответствии сообщение: -Стоимость товаров, работ, услуг без учета косвенных налогов у поставщиков в разделе G не соответствует суммарному значению в разделе H-. " +
        "2) Проверка соответствия суммарного значения в разделе H со значением в разделе G, если раздел H заполняется для каждого участника совместной деятельности получателя. " +
            "При несоответствии сообщение: -Стоимость товаров, работ, услуг без учета косвенных налогов у получателей в разделе G не соответствует суммарному значению в разделе H-. " +
        "3) Может быть дробным числом в десятичном виде, но не более двух знаков после запятой.",
        "1) Если заполнены графы H6 и H7, автоматический расчет по формуле H6*H7. " +
        "2) Если графы H6 и H7 не заполнены, ввод вручную.",
        "Если заполнены графы H6 и H7 проверка на корректность автоматического расчета по формуле H6*H7. При несоответствии сообщение: «H8 Стоимость товаров, работ, услуг без косвенных налогов указана некорректно».")]
        public string p_totalPriceWithoutTax;

        [detailsESFfield("", "H9", "Акциз-Ставка", 0, 12, FillingType.NUMBER, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
        "",
        "Автоматическое заполнение значением, указанным в графе G9. Поле заблокировано для редактирования.",
        "Проверка на соответствие со значениями, указанными в графе G9. При несоответствии сообщение: «H9 Ставка акциза не соответствует указанному значению в графе G9».")]
        public string p_exciseRate;

        [detailsESFfield("exciseAmount", "H10", "Акциз-Сумма", 0, 12, FillingType.NUMBER, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED,
        "1) Проверка соответствия суммарного значения в разделе H со значением в разделе G, если раздел H заполняется для каждого участника совместной деятельности поставщика. " +
            "При несоответствии сообщение: -АкцизСумма у поставщиков в разделе G не соответствует суммарному значению в разделе H-. " +
        "2) Проверка соответствия суммарного значения в разделе H со значением в разделе G, если раздел H заполняется для каждого участника совместной деятельности получателя. " +
            "При несоответствии сообщение: -АкцизСумма получателей в разделе G не соответствует суммарному значению в разделе H-. " +
        "3) Может быть дробным числом в десятичном виде, но не более двух знаков после запятой.")]
        public string p_exciseAmount;

        [detailsESFfield("turnoverSize", "H11", "Размер оборота по реализации(облагаемый/необлагаемый оборот)", 0, 12, FillingType.NUMBER, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "1) Проверка соответствия суммарного значения в разделе H со значением в разделе G, если раздел H заполняется для каждого участника совместной деятельности поставщика. " +
            "При несоответствии сообщение: -Размер оборота по реализации товаров, работ, услуг у поставщиков в разделе G не соответствует суммарному значению в разделе H-. " +
        "2) Проверка соответствия суммарного значения в разделе H со значением в разделе G, если раздел H заполняется для каждого участника совместной деятельности получателя. " +
            "При несоответствии сообщение: -Размер оборота по реализации товаров, работ, услуг у получателей в разделе G не соответствует суммарному значению в разделе H-. " +
        "3) Может быть дробным числом в десятичном виде, но не более двух знаков после запятой.",
        "Автоматический расчет по формуле H8 + H10.",
        "Проверка на корректность автоматического расчета по формуле H8+H10. При несоответствии сообщение: «H11 Размер оборота по реализации (облагаемый/необлагаемый оборот) указан некорректно».")]
        public string p_turnoverSize;

        [detailsESFfield("", "H12", "Ставка НДС", 1, 7, FillingType.NUMBER, FillingMethod.AUTO_MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "",
        "Автоматическое заполнение значением, указанным в графе G12. Поле заблокировано для редактирования.",
        "Проверка на соответствие со значениями, указанными в графе G12. При несоответствии сообщение: «H12 Ставка НДС не соответствует указанному значению в графе G12».")]
        public string p_ndsRate;

        [detailsESFfield("ndsAmount", "H13", "Сумма НДС", 1, 12, FillingType.NUMBER, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "1) Проверка соответствия суммарного значения в разделе H со значением в разделе G, если раздел H заполняется для каждого участника совместной деятельности поставщика. " +
            "При несоответствии сообщение: -НДС-Сумма у поставщиков в разделе G не соответствует суммарному значению в разделе H-. " +
        "2) Проверка соответствия суммарного значения в разделе H со значением в разделе G, если раздел H заполняется для каждого участника совместной деятельности получателя. " +
            "При несоответствии сообщение: -НДС-Сумма у получателей в разделе G не соответствует суммарному значению в разделе H-. " +
        "3) Может быть дробным числом в десятичном виде, но не более двух знаков после запятой.",
        "1) Автоматический расчет по формуле H11*H12. " +
        "2) Если в графе H12 -Ставка НДС- указано значение -Без НДС-, заполняется 0.",
        "1) Проверка на корректность автоматического расчета по формуле H11* H12. При несоответствии сообщение: «H13 Сумма НДС указана некорректно». " +
        "2) Если в графе H12 -Ставка НДС- указано значение -Без НДС-, заполняется значение «0». " +
            "При несоответствии сообщение: «Если в графе H12 -Ставка НДС- указано значение -Без НДС-, в H13 должно быть значение «0»».")]
        public string p_ndsAmount;

        [detailsESFfield("priceWithTax", "H14", "Стоимость ТРУ с учетом НДС", 1, 12, FillingType.NUMBER, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "1) Проверка соответствия суммарного значения в разделе H со значением в разделе G, если раздел H заполняется для каждого участника совместной деятельности поставщика. " +
            "При несоответствии сообщение: -Стоимость товаров, работ, услуг с учетом косвенных налогов у поставщиков в разделе G не соответствует суммарному значению в разделе H-. " +
        "2) Проверка соответствия суммарного значения в разделе H со значением в разделе G, если раздел H заполняется для каждого участника совместной деятельности получателя. " +
            "При несоответствии сообщение: -Стоимость товаров, работ, услуг с учетом косвенных налогов у получателей в разделе G не соответствует суммарному значению в разделе H-. " +
        "3) Может быть дробным числом в десятичном виде, но не более двух знаков после запятой.",
        "Автоматический расчет по формуле H11 + H13.",
        "Проверка на корректность автоматического расчета по формуле H11+H13. При несоответствии сообщение: «H14 Стоимость товаров, работ, услуг с учетом косвенных налогов указана некорректно».")]
        public string p_priceWithTax;

        [detailsESFfield("", "H15", "Декларации на товары, заявления в рамках ТС, СТ-1 или СТ-KZ", 0, 20, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "",
        "Автоматическое заполнение значением, указанным в графе G15. Поле заблокировано для редактирования.",
        "Проверка на соответствие со значениями, указанными в графе G15. " +
            "При несоответствии сообщение: «H15 № Декларации на товары, заявления о ввозе товаров и уплате косвенных налогов, СТ-KZ, СТ-1 не соответствует указанному значению в графе G15»")]
        public string p_productDeclaration;

        [detailsESFfield("", "H16", "Номер товарной позиции из заявления в рамках ТС или Декларации на товары", 0, 4, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "",
        "Автоматическое заполнение значением, указанным в графе G16. Поле заблокировано для редактирования.",
        "Проверка на соответствие со значениями, указанными в графе G16. " +
            "При несоответствии сообщение: «H16 «Номер товарной позиции из заявления о ввозе товаров и уплате косвенных налогов или Декларации на товары» не соответствует указанному значению в графе G16».")]
        public string p_productNumberInDeclaration;

        [detailsESFfield("", "H17", "Идентификатор товара, работ, услуг", 0, 36, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "",
        "Автоматическое заполнение значением, указанным в графе G17. Поле заблокировано для редактирования.",
        "Проверка на соответствие со значениями, указанными в графе G17. При несоответствии сообщение: «H17 Идентификатор товара, работ, услуг не соответствует указанному значению в графе G17».")]
        public string p_catalogTruId;

        [detailsESFfield("additional", "H18", "Дополнительные данные", 0, 255, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED)]
        public string p_additional;

        [detailsESFfield("", "", "Всего посчету", 1, 12, FillingType.NUMBER, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED,
        "1) Итоговая сумма графы H8, H10, H11, H13, H14 по всем поставщикам не может быть больше или меньше итоговой суммы графы G8, G10, G11, G13, G14 и должна быть равна итоговой сумме графы G8, G10, G11, G13, G14. " +
            "При некорректном значении отображается сообщение: - Итоговая сумма графы G8, G10, G11, G13, G14 у поставщиков не соответствует суммарному значению в разделе H-. " +
        "2) Итоговая сумма графы H8, H10, H11, H13, H14 по всем получателям не может быть больше или меньше итоговой суммы графы G8, G10, G11, G13, G14 и должна быть равна итоговой сумме графы G8, G10, G11, G13, G14. " +
            "При некорректном значении отображается сообщение: - Итоговая сумма графы G8, G10, G11, G13, G14 у получателей не соответствует суммарному значению в разделе H-.",
        "Автоматический расчет отдельно по каждой из граф H8, H10, H11, H13, H14. Расчет производится суммированием значений по всем строкам. Расчет производится отдельно по поставщикам и по покупателям. Поле заблокировано для редактирования.",
        "Проверка на корректность автоматического расчета. При несоответствии сообщение: -Всего по счету- указано некорректно».")]
        public string p_totalBillAmount;

        #endregion

        #region Раздел I Реквизиты поверенного(оператора) поставщика

        [detailsESFfield("sellerAgentTin", "35", "БИН", 12, 12, FillingType.STRING, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "Проверка наличия признака блокировки работы в ИС ЭСФ. Механизм описан в СТПО шифр 398.13024001364901.00.01.03-01.2017 " +
            "При наличии признака блокировки работы НП в ИС ЭСФ сообщение: «Поверенный (оператор) поставщика заблокирован».",
        "Возможность указать вручную ИИН/БИН Поверенного или БИН Оператора. При указании категории ЕУчастник СРП, поля 10 проверка на наличие сведений БИН в справочнике СРП.",
        "Проверка на наличие БИН в БД ИС ЭСФ. При отсутствии данных сообщение: «БИН поверенного (оператора) поставщика не найден в БД ИС ЭСФ».")]
        public string sellerAgentTin;

        [detailsESFfield("sellerAgentName", "36", "Поверенный", 3, 500, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "",
        "1) Автоматическое заполнение данными из БД ИС ЭСФ на основании значения в поле 35 -БИН-. Поле заблокировано для редактирования. " +
        "1.1) При выборе интерфейса на казахском языке, если в справочнике отсутствует наименование на казахском языке, указывается наименование на русском языке.",
        "Проверка на соответствие наименования и БИН в поле 35. При несоответствии сообщение: «Наименование не соответствует ИИН/БИН поверенного поставщика».")]
        public string sellerAgentName;

        [detailsESFfield("sellerAgentAddress", "37", "Адрес места нахождения", 3, 98, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "",
        "1) Автоматическое заполнение из БД ИС ЭСФ на основании значения в поле -35 - БИН-. Поле заблокировано для заполнения. " +
        "1.1) При выборе интерфейса на казахском языке, если в справочнике отсутствует адрес места жительства/ нахождения на казахском языке, указывается адрес места жительства/ нахождения на русском языке. " +
        "1.2) При отсутствии адреса места жительства/ нахождения на русском и казахском языках, отображается сообщение: - Адрес отсутствует в БД ИС ЭСФ-, и поле остается незаполненным без возможности редактирования.")]
        public string sellerAgentAddress;

        #region 38 Документ

        [detailsESFfield("sellerAgentDocNum", "38.1", "Документ-Номер", 0, 18, FillingType.STRING, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "Проверка на обязательность заполнения, если заполнено поле 35 -БИН-, или 38.2 -Дата-. При отсутствии реквизита сообщение: -Номер документа, определяющего поверенного (оператора) поставщика, отсутствует-.")]
        public string sellerAgentDocNum;

        [detailsESFfield("sellerAgentDocDate", "38.2", "Документ-Дата", 0, 10, FillingType.DATE_DDpMMpYYYY, FillingMethod.CALENDAR, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "Проверка на обязательность заполнения, если заполнено поле 35 -БИН-, или 38.1 -Номер-. При отсутствии реквизита сообщение: -Дата документа, определяющего поверенного (оператора) поставщика, отсутствует-.")]
        public string sellerAgentDocDate;

        #endregion

        #endregion

        #region Раздел J Реквизиты поверенного(оператора) поставщика
        /*Раздел отображается, если в строке 20 отмечена ячейка «H - доверитель» или «G - участник СРП или сделки, заключенной в рамках СРП».*/

        [detailsESFfield("customerAgentTin", "39", "БИН", 12, 12, FillingType.STRING, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "1) Проверка на наличие БИН в справочнике «Участники СРП». При отсутствии отображается сообщение: -БИН поверенного (оператора) получателя не найден в справочнике «Участники СРП»-. " +
        "2) Проверка наличия регистрационного учета поверенного или оператора. При отсутствии активного регистрационного учета поверенного или оператора сообщение: «Пользователь не является поверенным (оператором)». " +
        "3) Проверка наличия признака блокировки работы в ИС ЭСФ. Механизм описан в СТПО шифр 398.13024001364901.00.01.03-01.2017 При наличии признака блокировки работы НП в ИС ЭСФ сообщение: «Поверенный (оператор) получателя заблокирован».",
        "1) Возможность указать вручную ИИН/БИН Поверенного или БИН Оператора. 2) При указании в поле 20 категории G - участник СРП или сделки, заключенной в рамках СРП, проверка на наличие сведений БИН в справочнике «Участники СРП».",
        "Проверка на наличие БИН в БД ИС ЭСФ. При отсутствии данных сообщение: «БИН поверенного (оператора) покупателя не найден в БД ИС ЭСФ».")]
        public string customerAgentTin;

        [detailsESFfield("customerAgentName", "40", "Поверенный", 3, 500, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "",
        "1) Автоматическое заполнение данными из БД ИС ЭСФ на основании значения в поле 39 -БИН-. Поле заблокировано для редактирования. " +
        "1.1) При выборе интерфейса на казахском языке, если в справочнике отсутствует наименование на казахском языке, указывается наименование на русском языке.",
        "Проверка на соответствие наименования и БИН в поле 39. При несоответствии сообщение: «Наименование не соответствует ИИН/БИН поверенного покупателя».")]
        public string customerAgentName;

        [detailsESFfield("customerAgentAddress", "41", "Адрес места нахождения", 3, 98, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "",
        "1) Автоматическое заполнение из БД ИС ЭСФ на основании значения в поле -39 - БИН-. Поле заблокировано для заполнения. " +
        "1.1) При выборе интерфейса на казахском языке, если в справочнике отсутствует адрес места жительства/ нахождения на казахском языке, указывается адрес места жительства/ нахождения на русском языке. " +
        "1.2) При отсутствии адреса места жительства/ нахождения на русском и казахском языках, отображается сообщение: - Адрес отсутствует в БД ИС ЭСФ-, и поле остается незаполненным без возможности редактирования.")]
        public string customerAgentAddress;

        #region 42 Документ

        [detailsESFfield("customerAgentDocNum", "42.1", "Документ-Номер", 0, 18, FillingType.STRING, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "Проверка на обязательность заполнения, если заполнено поле 39 -БИН-, или 42.2 -Дата-. При отсутствии реквизита сообщение: -Номер документа, определяющего поверенного (оператора) получателя, отсутствует-.")]
        public string customerAgentDocNum;

        [detailsESFfield("customerAgentDocDate", "42.2", "Документ-Дата", 0, 10, FillingType.DATE_DDpMMpYYYY, FillingMethod.CALENDAR, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,
        "Проверка на обязательность заполнения, если заполнено поле 39 -БИН-, или 42.1 -Номер-. При отсутствии реквизита сообщение: -Дата документа, определяющего поверенного (оператора) получателя, отсутствует-.")]
        public string customerAgentDocDate;

        #endregion

        #endregion

        #region Раздел K Дополнительные сведения

        [detailsESFfield("addInf", "43", "Дополнительные сведения", 0, 255, FillingType.STRING, FillingMethod.MANUAL, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.NOT_REQUIRED)]
        public string addInf;

        #endregion

        #region Раздел L Сведения по ЭЦП

        [detailsESFfield("", "44", "ЭЦП юридическо го лица (структурно го подразделе ния юридическо го лица) или индивидуального предпринимателя", 0, 999, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,"",
        "Взаимоисключающие поля 44,45")]
        public string EDSofLE;//electronic digital signature of a legal entity

        [detailsESFfield("", "45", "ЭЦП лица, уполномоченного подписывать счетафактуры", 0, 999, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.CONDITIONALY_REQUIRED,"",
        "Взаимоисключающие поля 44,45")]
        public string EDSofAP;//digital signature of an authorized person

        [detailsESFfield("", "46", "ФИО лица,выписывающее ЭСФ", 0, 255, FillingType.STRING, FillingMethod.AUTO, IsPrintable.PRINTABLE, IsDisplayed.DISPLAYED, IsRequired.REQUIRED)]
        public string userName;

        #endregion
    }
}
