using MoveYourBum.Services.Abstract;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace MoveYourBum.ViewModels.Abstract
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public abstract class AEditViewModel<T> : BaseViewModel
    {
        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();

        public Command DeleteCommand { get; }
        public Command CancelCommand { get; }
        public Command SaveCommand { get; }
        public abstract void LoadProperties(T item);
        //public abstract void LoadSelected(T item); //?

        protected AEditViewModel()
        {
            CancelCommand = new Command(OnCancel);
            DeleteCommand = new Command(OnDelete);
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        private async void OnDelete()
        {
            await DataStore.DeleteItemAsync(itemId);
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        public abstract T SetItem(T item);
        //public abstract T SetItem();
        private async void OnSave()
        {
            var item = await DataStore.GetItemAsync(itemId);
            await DataStore.UpdateItemAsync(SetItem(item));

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

        public abstract bool ValidateSave();
    }
}
