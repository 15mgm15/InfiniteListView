using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using InfiniteListView.Models;
using Xamarin.Forms.Extended;

namespace InfiniteListView.ViewModels
{
    public class InfiniteListViewViewModel : INotifyPropertyChanged
    {
        public InfiniteScrollCollection<DataItem> Items { get; }
        
        bool _isLoadingMore;
        bool IsLoadingMore
        {
            get
            {
                return _isLoadingMore;
            }
            set
            {
                _isLoadingMore = value;
                OnPropertyChanged(nameof(IsLoadingMore));
            }
        }
        
        public InfiniteListViewViewModel()
        {
            Items = new InfiniteScrollCollection<DataItem>
            {
                OnLoadMore = async () =>
                {
                    IsLoadingMore = true;

                    var items = GetItems(false);
                    //Call your Web API next items page.
                    await Task.Delay(1200);

                    IsLoadingMore = false;
                    return items;
                }
            };
            Items.LoadMoreAsync();
        }

        InfiniteScrollCollection<DataItem> GetItems(bool clearList)
        {
            InfiniteScrollCollection<DataItem> items;
            if(clearList || Items == null)
            {
                items = new InfiniteScrollCollection<DataItem>();   
            }
            else
            {
                items = new InfiniteScrollCollection<DataItem>(Items);
            }

            for (int i = 0; i < 20; i++)
            {
                items.Add(new DataItem { Text = i.ToString() });
            }

            return items;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
