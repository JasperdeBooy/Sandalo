using Sandalo.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sandalo.Models
{
	public class Categorie : ObservableObject
	{
		public string Naam { get; set; }
		public string Beschrijving { get; set; }

		public Categorie(string naam, string beschrijving)
		{
			Naam = naam;
			Beschrijving = beschrijving;
		}
		public override string ToString()
		{
			return string.Format("{0}; {1}",
				this.Naam, this.Beschrijving);
		}
	}

}
