using System.Windows;
using System.Windows.Controls;
using ThreadDataGenerator.Interfaces;
using ThreadDataGenerator.ViewModel;

namespace ThreadDataGenerator;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        IDispatcherWrapper dispatcherWrapper = new DispatcherWrapper(Application.Current.Dispatcher);
        MainWindowViewModel viewModel = new MainWindowViewModel(dispatcherWrapper);
        DataContext = viewModel;
    }

    private async void button_Click(object sender, RoutedEventArgs e)
    {
        if (Validation.GetHasError(threadTextBox))
        {
            return;
        }

        if (DataContext is MainWindowViewModel viewModel)
        {
            await viewModel.Start();
        }
    }

    private void ProductsListView_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        ListView? listView = sender as ListView;
        GridView? gView = listView.View as GridView;

        var workingWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth;
        var col1 = 0.50;
        var col2 = 0.50;

        gView.Columns[0].Width = workingWidth * col1;
        gView.Columns[1].Width = workingWidth * col2;
    }
}