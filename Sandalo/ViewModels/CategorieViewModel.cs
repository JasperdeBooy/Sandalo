using Sandalo.Models;
using Sandalo.Services;
using Sandalo.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Sandalo.ViewModels
{

	public class CategorieViewModel : ObservableObject
	{
		private IDataService _dataService;
		private ObservableCollection<Categorie> _categorieen;
		private Categorie _selectedCategorie;


		public CategorieViewModel(IDataService dataservice)
		{
			_dataService = dataservice;
			_categorieen = new ObservableCollection<Categorie>(_dataService.GeefAlleCategorieen());
			if (_categorieen.Count > 0) SelectedCategorie = _categorieen[0];
		}
		public Categorie SelectedCategorie
		{
			get { return _selectedCategorie; }
			set { OnPropertyChanged(ref _selectedCategorie, value); }
		}

		public ObservableCollection<Categorie> Categorieen
		{
			get { return _categorieen; }
			set { OnPropertyChanged(ref _categorieen, value); }
		}
	}
}