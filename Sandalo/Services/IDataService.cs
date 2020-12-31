using Sandalo.Models;
using System.Collections.Generic;

namespace Sandalo.Services
{
	public interface IDataService
	{
		IList<Categorie> GeefAlleCategorieen();
		IList<Sandaal> GeefAlleSandalen();
		IList<Subcategorie> GeefAlleSubCategorieen();
		IList<Sandaal> VerwijderSandaal(Sandaal sandaal);
		IList<Sandaal> VoegSandaalToe(Sandaal sandaal);
		IList<Sandaal> WijzigSandaal(Sandaal sandaal, Sandaal nieuwesandaal);
	}
}