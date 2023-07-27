using MoveYourBum.Services.Abstract;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace MoveYourBum.ViewModels.Abstract
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public abstract class AItemDetailsViewModel<T> : BaseViewModel
    {
        protected AItemDetailsViewModel()
        {
            CancelCommand = new Command(OnCancel);
            DeleteCommand = new Command(OnDelete);
            ItemTapped = new Command<T>(OnItemSelected);
        }

        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();

        public Command DeleteCommand { get; }
        public Command CancelCommand { get; }
        private T _selectedItem;
        public Command<T> ItemTapped { get; }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = default(T);
        }
        public T SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
        public async virtual void OnItemSelected(T item)
        {
            if (item == null)
                return;
}
        public abstract void LoadProperties(T item);
        private async void OnDelete()
        {
            await DataStore.DeleteItemAsync(itemId);
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }


        private int itemId;
        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                LoadProperties(item);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
