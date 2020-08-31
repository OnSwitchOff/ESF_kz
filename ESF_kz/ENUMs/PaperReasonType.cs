using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF_kz
{
	//Причина выписки на бумажном носителе (2.1)
	enum PaperReasonType
	{
		DOWN_TIME,//Простой системы
		MISSING_REQUIREMENT,//Отсутствовало требование по выписке ЭСФ
		UNLAWFUL_REMOVAL_REGISTRATION//Неправомерное снятие с регистрационного учета
	}
}
