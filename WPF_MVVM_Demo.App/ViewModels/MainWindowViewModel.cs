using System.Collections.ObjectModel;
using System.ComponentModel;
using WPF_MVVM_Demo.App.Commands;
using WPF_MVVM_Demo.App.Models;

namespace WPF_MVVM_Demo.App.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
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
    public ProductsCommand DeleteProductCommand { get; }

    public MainWindowViewModel()
    {
        Products = new ObservableCollection<Product>(ProductUtility.ImportProducts("products.json"));

        DeleteProductCommand = new ProductsCommand(_ =>
        {
            Products.Remove(Product);
        },
            o => (o as ObservableCollection<Product>)?.Count != 0);

        ExportProductsCommand = new ExportProductsCommand();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
