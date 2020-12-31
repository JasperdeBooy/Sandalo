using Sandalo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sandalo.Services
{
	public class MockDataService :IDataService
	{
		private IList<Sandaal> _sandalen;
		private IList<Categorie> _categorieen;
		private IList<Subcategorie> _subcategorieen;
		public MockDataService()
		{
			InitLijsten();
		}
		private void InitLijsten()
		{
			InitCategorieen();
			InitSubCategorieen();
			InitSandalen();
		}

		private void InitSandalen()
		{
			_sandalen = new List<Sandaal>();
			_sandalen.Add(new Sandaal(1, "strandslipper", "Stevige strandslipper met plastiek band", "strandslipper.jpg", 12.5f,
										"zwart", _subcategorieen[0], "Beschikbaar in vijf verschillende kleuren"));
			_sandalen.Add(new Sandaal(2, "gladiator", "Goed voor bergwandelingen", "otroman.jpg", 49.95f,
										"bruin", _subcategorieen[1], "alleen voor volwassenen"));
			_sandalen.Add(new Sandaal(3, "disco fever", "lekker swingen", "disco.jpg", 75.00f,
										"wit", _subcategorieen[2], "nepdiamanten en glitter"));
			_sandalen.Add(new Sandaal(4, "plateau", "jaren '60", "plateau.jpg", 145.00f,
										"rood", _subcategorieen[2], "nepvis in hiel"));
			_sandalen.Add(new Sandaal(5, "Zori", "japanse sandaal", "zori.jpg", 265.00f,
										"bruin", _subcategorieen[3], "authentiek"));

		}
		private void InitSubCategorieen()
		{
			_subcategorieen = new List<Subcategorie>();
			_subcategorieen.Add(new Subcategorie("Strand", "waterdicht en zoutbestendig", _categorieen[1]));
			_subcategorieen.Add(new Subcategorie("Romeins", "stevig, ideaal voor lange wandelingen", _categorieen[0]));
			_subcategorieen.Add(new Subcategorie("Retro", "jaren '60", _categorieen[1]));
			_subcategorieen.Add(new Subcategorie("Exclusief", "uniek design", _categorieen[0]));
		}
		private void InitCategorieen()
		{
			_categorieen = new List<Categorie>();
			_categorieen.Add(new Categorie("Business", "Voor werkomgeving"));
			_categorieen.Add(new Categorie("Casual", "Voor vrije tijd"));
		}

		public IList<Sandaal> GeefAlleSandalen()
		{
			return _sandalen;
		}

		public IList<Categorie> GeefAlleCategorieen()
		{
			return _categorieen;
		}

		public IList<Subcategorie> GeefAlleSubCategorieen()
		{
			return _subcategorieen;
		}

		public IList<Sandaal> VoegSandaalToe(Sandaal sandaal)
		{
			_sandalen.Add(sandaal);
			return _sandalen;
		}

		public IList<Sandaal> WijzigSandaal(Sandaal sandaal, Sandaal nieuwesandaal)
		{
			//met SQL database
			//_sandalen.Single(s => s.Id ==nieuwesandaal.Id);
			int indexSandaal = _sandalen.IndexOf(sandaal);
			if (indexSandaal >= 0) _sandalen[indexSandaal] = nieuwesandaal;
			return _sandalen;
		}

		public IList<Sandaal> VerwijderSandaal(Sandaal sandaal)
		{
			_sandalen.Remove(sandaal);
			return _sandalen;
		}
	}
}