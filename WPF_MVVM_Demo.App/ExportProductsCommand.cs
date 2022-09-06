using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace WPF_MVVM_Demo.App;

public class ExportProductsCommand : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        var products = parameter as IEnumerable<Product>;
        ProductUtility.ExportProducts(products, "products.json");
    }

    public event EventHandler? CanExecuteChanged;
}
