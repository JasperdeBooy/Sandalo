using Contacten1.ViewModels;
using Sandalo.Models;
using Sandalo.Services;
using Sandalo.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Sandalo.ViewModels
{
	public class SandalenViewModel:ObservableObject
	{
		private IDataService _dataService;
		public ObservableCollection<Sandaal> Sandalen { get; set; }
		private Sandaal _selectedSandaal;
		private Sandaal _newSandaal;
		private Sandaal _searchSandaal;

		public ICommand CloseCommand { get; private set; }
		public ICommand DeleteCommand { get; private set; }
		public ICommand AddCommand { get; private set; }

		public SandalenViewModel(IDataService dataservice)
		{
			_dataService = dataservice;
			Sandalen = new ObservableCollection<Sandaal>(_dataService.GeefAlleSandalen());
			if (Sandalen.Count > 0) SelectedSandaal = Sandalen[0];
			DeleteCommand = new RelayCommand(VerwijderSandaal, CanDelete);
			AddCommand = new RelayCommand(VoegSandaalToe);
		}

		private void VoegSandaalToe()
		{
			Sandaal _newSandaal = new Sandaal(0, "jasper", "N/A", "N/A", 0.0f, "N/A", null, "N/A"); ;
			//Sandalen = new ObservableCollection<Sandaal>(_dataService.VoegSandaalToe(_newSandaal));
			//SelectedSandaal = Sandalen[Sandalen.Count - 1];

		}

		private void VerwijderSandaal()
		{
			//TO DO
			//Sandalen = new ObservableCollection<Sandaal>(_dataService.VerwijderSandaal(SelectedSandaal));
			Sandalen.Remove(SelectedSandaal);
			if (Sandalen.Count > 0) SelectedSandaal = Sandalen[0];
		}

		public Sandaal SelectedSandaal
		{
			get { return _selectedSandaal; }
			set { OnPropertyChanged(ref _selectedSandaal, value); }
		}
		public Sandaal NewSandaal
		{
			get { return _newSandaal; }
			set { OnPropertyChanged(ref _newSandaal, value); }
		}
		public Sandaal SearchSandaal
		{
			get { return _searchSandaal; }
			set { OnPropertyChanged(ref _searchSandaal, value); }
		}
		private bool CanDelete()
		{
			return (SelectedSandaal != null);
		}
	}
}
