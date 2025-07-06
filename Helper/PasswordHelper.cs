using System.Windows.Controls;
using System.Windows;
using Microsoft.Xaml.Behaviors;



// 利用附加属性来将password进行双向绑定 
namespace DevicMonitor.Helper
{
    // 用于接收passwordBox的密码输入
    public class PasswordHelper
    {
        public static readonly DependencyProperty PasswordProperty =
      DependencyProperty.RegisterAttached(
          "Password",
          typeof(string),
          typeof(PasswordHelper),
          new FrameworkPropertyMetadata(string.Empty, OnPasswordChanged)
      );

        public static string GetPassword(DependencyObject d) =>
            (string)d.GetValue(PasswordProperty);

        public static void SetPassword(DependencyObject d, string value) =>
            d.SetValue(PasswordProperty, value);

        private static void OnPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox box)
            {
                box.PasswordChanged -= Box_PasswordChanged;
                if (!_isUpdating)
                {
                    box.Password = (string)e.NewValue;
                }
                box.PasswordChanged += Box_PasswordChanged;
            }
        }

        private static bool _isUpdating = false;

        private static void Box_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox box)
            {
                _isUpdating = true;
                SetPassword(box, box.Password);
                _isUpdating = false;
            }
        }
    }


    public class PasswordBoxBehavior : Behavior<PasswordBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.PasswordChanged += OnPasswordChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.PasswordChanged -= OnPasswordChanged;
        }

        private static void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox box = sender as PasswordBox;
            string password = PasswordHelper.GetPassword(box);
            if (box != null && box.Password != password)
            {
                PasswordHelper.SetPassword(box, box.Password);
            }
        }
    }


}
