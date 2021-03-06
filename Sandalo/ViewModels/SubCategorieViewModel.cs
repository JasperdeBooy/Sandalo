﻿using Sandalo.Models;
using Sandalo.Services;
using Sandalo.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Sandalo.ViewModels
{
	public class SubCategorieViewModel : ObservableObject
	{
		private IDataService _dataService;
		private ObservableCollection<Subcategorie> _subcategorieen;
		private Subcategorie _selectedSubcategorie;
		public SubCategorieViewModel(IDataService dataservice)
		{
			_dataService = dataservice;
			_subcategorieen = new ObservableCollection<Subcategorie>(_dataService.GeefAlleSubCategorieen());
			if (_subcategorieen.Count > 0) SelectedSubcategorie = _subcategorieen[0];
		}
		public Subcategorie SelectedSubcategorie
		{
			get { return _selectedSubcategorie; }
			set { OnPropertyChanged(ref _selectedSubcategorie, value); }
		}
		public ObservableCollection<Subcategorie> Subcategorieen
		{
			get { return _subcategorieen; }
			set { OnPropertyChanged(ref _subcategorieen, value); }
		}

		internal void Filter(Categorie selectedCategorie)
		{
			Subcategorieen.Clear();
			List<Subcategorie> Zoek = (List<Subcategorie>)_dataService.GeefAlleSubCategorieen();
			foreach (Subcategorie s in Zoek)
			{
				if (s.Categorie == selectedCategorie || selectedCategorie == null)
				{
					Subcategorieen.Add(s);
				}
			}
		}
	}
}