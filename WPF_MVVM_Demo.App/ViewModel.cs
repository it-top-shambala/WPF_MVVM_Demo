using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

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

    public ExportProductsCommand ExportProductsCommand { get; }

    public ViewModel()
    {
        ExportProductsCommand = new ExportProductsCommand();
        Products = new ObservableCollection<Product>(ProductUtility.ImportProducts("products.json"));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
