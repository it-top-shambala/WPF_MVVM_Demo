using System;
using System.Collections.Generic;
using System.Windows.Input;
using WPF_MVVM_Demo.App.Models;

namespace WPF_MVVM_Demo.App.Commands;

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
