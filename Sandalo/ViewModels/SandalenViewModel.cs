using Sandalo.Models;
using Sandalo.Services;
using Sandalo.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Sandalo.ViewModels
{
	public class SandalenViewModel : ObservableObject
	{
		private bool _addmode;
		private IDataService _dataService;
		private bool _editmode;
		private Sandaal _sandaal;
		private ObservableCollection<Sandaal> _sandalen;
		private Sandaal _selectedSandaal;
		private bool _searchmode;
		private bool _showDetail;
		private bool _showGrid;
		public ICommand AddCommand { get; private set; }
		public ICommand CancelCommand { get; private set; }
		public ICommand DeleteCommand { get; private set; }
		public ICommand EditCommand { get; private set; }
		public ICommand SaveCommand { get; private set; }
		public ICommand SearchCommand { get; private set; }
		public ICommand UpdateCommand { get; private set; }
		public ICommand ZoekCommand { get; private set; }

		public SandalenViewModel(IDataService dataservice)
		{
			_dataService = dataservice;
			Sandalen = new ObservableCollection<Sandaal>(_dataService.GeefAlleSandalen());
			if (Sandalen.Count > 0) SelectedSandaal = Sandalen[0];
			Addmode = false;
			AddCommand = new RelayCommand(InitAddSandaal);
			CancelCommand = new RelayCommand(Cancel);
			DeleteCommand = new RelayCommand(VerwijderSandaal, CanDelete);
			EditCommand = new RelayCommand(InitWijzigSandaal, CanDelete);
			Editmode = false;
			SaveCommand = new RelayCommand(VoegSandaalToe);
			SearchCommand = new RelayCommand(InitSearchSandaal);
			Searchmode = false;
			ShowDetail = false;
			ShowGrid = true;
			UpdateCommand = new RelayCommand(WijzigSandaal);
			ZoekCommand = new RelayCommand(ZoekSandalen);
		}
		public bool Addmode
		{
			get { return _addmode; }
			set { OnPropertyChanged(ref _addmode, value); }
		}
		private void Cancel()
		{
			Addmode = false;
			Editmode = false;
			Searchmode = false;
			ShowDetail = false;
			ShowGrid = true;
		}
		private bool CanDelete()
		{
			return (SelectedSandaal != null);
		}
		public bool Editmode
		{
			get { return _editmode; }
			set { OnPropertyChanged(ref _editmode, value); }
		}
		private void InitAddSandaal()
		{
			Addmode = true;
			Sandaal = new Sandaal(0, "", "", "", 0.0f, "", null, "");
			ShowDetail = true;
			ShowGrid = false;
		}
		private void InitWijzigSandaal()
		{
			Editmode = true;
			Sandaal = SelectedSandaal;
			ShowDetail = true;
			ShowGrid = false;
		}
		public void InitSearchSandaal()
		{
			Sandaal = new Sandaal(0, "", "", "", 0.0f, "", null, "");
			Searchmode = true;
			ShowDetail = true;
			ShowGrid = false;
		}
		public ObservableCollection<Sandaal> Sandalen
		{
			get { return _sandalen; }
			set { OnPropertyChanged(ref _sandalen, value); }
		}
		public Sandaal Sandaal
		{
			get { return _sandaal; }
			set { OnPropertyChanged(ref _sandaal, value); }
		}
		public bool Searchmode
		{
			get { return _searchmode; }
			set { OnPropertyChanged(ref _searchmode, value); }
		}
		public Sandaal SelectedSandaal
		{
			get { return _selectedSandaal; }
			set { OnPropertyChanged(ref _selectedSandaal, value); }
		}
		public bool ShowDetail
		{
			get { return _showDetail; }
			set { OnPropertyChanged(ref _showDetail, value); }
		}
		public bool ShowGrid
		{
			get { return _showGrid; }
			set { OnPropertyChanged(ref _showGrid, value); }
		}
		private void VerwijderSandaal()
		{
			string checkMessage = "Bent u zeker dat u " + _selectedSandaal.Naam + " wilt verwijderen?";

			var result = System.Windows.MessageBox.Show(checkMessage, "Delete", MessageBoxButton.OKCancel);
			if (result == MessageBoxResult.OK)
			{
				Sandalen = new ObservableCollection<Sandaal>(_dataService.VerwijderSandaal(SelectedSandaal));
				if (Sandalen.Count > 0)
				{
					SelectedSandaal = Sandalen[0];
				}
			}
		}
		private void VoegSandaalToe()
		{
			Sandalen = new ObservableCollection<Sandaal>(_dataService.VoegSandaalToe(_sandaal));
			SelectedSandaal = Sandalen[Sandalen.Count - 1];
			Cancel();
		}
		private void WijzigSandaal()
		{
			Sandalen = new ObservableCollection<Sandaal>(_dataService.WijzigSandaal(_selectedSandaal, _sandaal));
			SelectedSandaal = _selectedSandaal;
			Cancel();
		}
		private void ZoekSandalen()
		{
			string checkMessage = "Zoek naar " + Sandaal.ToString();
			System.Windows.MessageBox.Show(checkMessage, "Search", MessageBoxButton.OKCancel);
			Cancel();
		}
	}
}
