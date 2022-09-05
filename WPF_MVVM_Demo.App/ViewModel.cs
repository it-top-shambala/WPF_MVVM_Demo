using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WPF_MVVM_Demo.App;

public class ViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Product> Products { get; set; }

    private Product _product;

    public Product Product
    {
        get => _product;
        set
        {
            if (value == _product)
            {
                return;
            }

            _product = value;
            OnPropertyChanged(nameof(Product));
        }
    }

    public ViewModel()
    {
        Products = new ObservableCollection<Product>(ProductUtility.ImportProducts("products.json"));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
