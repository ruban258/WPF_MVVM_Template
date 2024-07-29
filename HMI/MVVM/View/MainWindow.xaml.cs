using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CustomControls;
using HMI.MVVM.Model;


namespace HMI.MVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<DataValue> DataValues { get; set; } = new List<DataValue>();

        public MainWindow()
        {
            DataValues.Add(new DataValue() { Name = "ruban" });
            DataValues.Add(new DataValue() { Name = "ruban1" });
            DataValues.Add(new DataValue() { Name = "ruban2" });
            DataValues.Add(new DataValue() { Name = "ruban3" });
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in DataValues)
            {
                foreach (var citem in FindVisualChildren<TextBox>(this))
                {
                    if (citem is IOField ioField)
                    {
                        item.ValueChanged += (s, args) => ioField.OnExternalEvent(s, args);
                    }
                    Debug.WriteLine(item);
                }
                item.ValueChanged += Item_ValueChanged;
            }
        }

        private void Item_ValueChanged(object? sender, EventArgs e)
        {
            Debug.WriteLine("Value Changed");
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield return (T)Enumerable.Empty<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
                if (ithChild == null) continue;
                if (ithChild is T t) yield return t;
                foreach (T childOfChild in FindVisualChildren<T>(ithChild)) yield return childOfChild;
            }
        }
    }
}