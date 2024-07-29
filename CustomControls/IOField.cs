using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace CustomControls
{

    public class IOField : TextBox, INotifyPropertyChanged
    {
        static IOField()
        {

            DefaultStyleKeyProperty.OverrideMetadata(typeof(IOField), new FrameworkPropertyMetadata(typeof(IOField)));
        }
        public void OnExternalEvent(object? sender, EventArgs e)
        {
            Dispatcher.Invoke(() => MaxValue = MaxValue + 1);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        public double MaxValue
        {
            get 
            { 
                return (Double)GetValue(MaxValueProperty); 
            }
            set
            {
                SetValue(MaxValueProperty, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MaxValue)));
            }
        }

        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register(nameof(MaxValue), typeof(Double), typeof(IOField), new PropertyMetadata(50.0d));

        public double MinValue
        {
            get { return (double)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(double), typeof(IOField), new PropertyMetadata(0.0d));

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
