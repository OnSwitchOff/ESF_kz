using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF_kz
{
	//УСД (H)
	[Serializable]
	public class ParticipantV2
	{
		//Информация по товарам (работам, услугам)+
		public List<ProductShare> productShares;

		//БИН реорганизованного лица (H 34.2)-
		public string reorganizedTin;

		//ИИН/БИН участника совместной деятельности (H 34.1)+
		public string tin;

		public ParticipantV2() { }
	}
}
