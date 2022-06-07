using System;
using System.ComponentModel;
using System.Windows;
using Список_дел.Models;
using Список_дел.Services;

namespace Список_дел
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json";
        private BindingList<Todomodel> _todoDataList;
        private FileOServices _fileIOService;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileOServices(PATH);
            try
            {
                _todoDataList = _fileIOService.LoadData();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                Close();
            }


            dgTodolist.ItemsSource = _todoDataList;
            _todoDataList.ListChanged += _todoDataList_ListChanged;
           

        }

        private void _todoDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            
        }
    }
 
           
    
}
