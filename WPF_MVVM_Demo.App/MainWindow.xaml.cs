using System;
using System.Windows;

namespace WPF_MVVM_Demo.App;

public partial class MainWindow : Window
{
    private ViewModel _viewModel;

    public MainWindow()
    {
        InitializeComponent();
        _viewModel = (ViewModel)DataContext;
    }

    private void ExportOnClick(object sender, EventArgs e)
    {
        ProductUtility.ExportProducts(_viewModel.Products, "products.json");
        MessageBox.Show("Saved");
    }

    private void ImportOnClick(object sender, EventArgs e)
    {
        MessageBox.Show("Import");
    }
}
