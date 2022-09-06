using System;
using System.Collections.Generic;
using System.Windows.Input;
using WPF_MVVM_Demo.App.Models;

namespace WPF_MVVM_Demo.App.Commands;

public class ProductsCommand : ICommand
{
    private Action<object?> _execute;
    private Predicate<object?> _canExecute;

    public ProductsCommand(Action<object?> execute, Predicate<object?> canExecute)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute.Invoke(parameter);
    }

    public void Execute(object? parameter)
    {
        _execute.Invoke(parameter);
    }

    public event EventHandler? CanExecuteChanged;
}
