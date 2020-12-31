using Sandalo.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sandalo.Models
{
	public class Sandaal : ObservableObject
	{
		public int Id { get; set; }
		public string Naam { get; set; }
		public string Beschrijving { get; set; }
		public string Afbeelding { get; set; }
		public float Prijs { get; set; }
		public string Kleur { get; set; }
		public Subcategorie Subcategorie { get; set; }
		public string Commentaar { get; set; }

		public Sandaal(int id, string naam, string beschrijving, string afbeelding, float prijs, string kleur, Subcategorie subcategorie, string commentaar)
		{
			Id = id;
			Naam = naam;
			Beschrijving = beschrijving;
			Afbeelding = afbeelding;
			Prijs = prijs;
			Kleur = kleur;
			Subcategorie = subcategorie;
			Commentaar = commentaar;
		}

	}
}
