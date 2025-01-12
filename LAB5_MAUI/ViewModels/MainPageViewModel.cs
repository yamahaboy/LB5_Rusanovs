using LAB5_MAUIDATA.Interfaces;
using LAB5_MAUIDATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace LAB5_MAUI.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IDataRepository _dataRepository;

        public MainPageViewModel(IDataRepository dataRepository)
        {
            Title = "Loading ...";
            _dataRepository = dataRepository;

            LoadCommand = new RelayCommand(LoadData);

            LoadData();
        }

        
        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private Bank[] _banks;
        public Bank[] Banks
        {
            get => _banks;
            set
            {
                _banks = value;
                OnPropertyChanged();
            }
        }
        private Bank _selectedBank;

        public Bank SelectedBank
        {
            get => _selectedBank;
            set
            {
                _selectedBank = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadCommand { get; }

        public ICommand SelectsBankCommand { get; }

        public async void LoadData()
        {
            Title = "Loading ...";

            var data = await _dataRepository.GetBankAsync();
            foreach (var bank in data)
            {
                Console.WriteLine($"Bank ID: {bank.Id}, Name: {bank.Name}, Description: {bank.Description},  Specialization: {bank.Specialization}");
            }

            Banks = data;
            Title = "Number of banks: " + data.Length;
        }
    }
}

