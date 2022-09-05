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

    private void ButtonExport_OnClick(object sender, RoutedEventArgs e)
    {
        ProductUtility.ExportProducts(_viewModel.Products, "products.json");
    }
}
