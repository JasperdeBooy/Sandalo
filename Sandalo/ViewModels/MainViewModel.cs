using Sandalo.Services;
using Sandalo.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sandalo.ViewModels
{
	public class MainViewModel : ObservableObject
	{
		private IDataService _dataService;
		private SubCategorieViewModel _subCategorieVM;
		private CategorieViewModel _categorieVM;
		private SandalenViewModel _sandaalVM;
		public MainViewModel()
		{
			_dataService = new MockDataService();
			_subCategorieVM = new SubCategorieViewModel(_dataService);
			_categorieVM = new CategorieViewModel(_dataService);
			_sandaalVM = new SandalenViewModel(_dataService);
		}
		public SubCategorieViewModel SubCategorieVM
		{
			get { return _subCategorieVM; }
		}
		public CategorieViewModel CategorieVM
		{
			get { return _categorieVM; }
		}
		public SandalenViewModel SandaalVM
		{
			get { return _sandaalVM; }
		}
	}
}
