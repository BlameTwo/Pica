using Microsoft.Xaml.Behaviors.Layout;
using Pica3.UI.Services;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Animation;
using System.Windows.Media;
using Pica3.UI.Tools;

namespace Pica3.UI.Controls
{
    public class DialogHost: Control,IDialogHost
    {
        //本文档来自于这里：https://github.com/BlameTwo/ZUDesignControl.git，经过一定的修改
        static DialogHost()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DialogHost), new FrameworkPropertyMetadata(typeof(DialogHost)));
        }

        private AdornerContainer _container;


        public void Show()
        {
            if(ShowingEvent != null)
            {
                ShowingEvent.Invoke();
            }
            //在此处保存一个数据上下文
            object VM = this.DataContext;
            FrameworkElement element;
            AdornerDecorator decorator;
            element = WindowHelper.GetActiveWindow();
            decorator = WindowHelper.GetChild<AdornerDecorator>(element);
            ((element as Window)!.Content as FrameworkElement)!.IsEnabled = false;
            if (decorator != null)
            {
                AdornerLayer layer = decorator.AdornerLayer;
                if (layer != null && _container == null)
                {
                    _container = new AdornerContainer(layer);
                    UserControl us = new UserControl();
                    Border mask = new Border
                    {
                        Background = new SolidColorBrush(Color.FromArgb(0, 30, 30, 30)),
                        Opacity = 1,
                    };
                    us.Content= mask;
                    if (Content is FrameworkElement contentControl)
                    {
                        if ((Content as FrameworkElement)!.Parent != null)
                        {
                            var b = (Content as FrameworkElement)!.Parent;
                            if (b != null)
                            {
                                //移除子控件和父控件之间的关联
                                (b as Border)!.Child = null;
                            }
                        }
                        else
                        {
#if DEBUG
                            Console.WriteLine("未获得父控件");
#endif
                        }
                        mask.Child = ((UIElement)Content);
                        _container.Child = us;
                        us.DataContext = VM;
                        layer.Add(_container);
                        
                        layer.Visibility = Visibility.Visible;
                        SetOpenAnimation();
                        this.RaiseEvent(new RoutedEventArgs(DialogHost.LoadedEvent));
                    }
                    else if (Content is string str)
                    {
                        //直接干掉字符串消息框
                        //mask.Child = (UIElement)new TextBlock() { Text = str, HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
                        //_container.Child = mask;
                        //layer.Add(_container);
                        //layer.Visibility = Visibility.Visible;
                        //if (ShowedEvent != null)
                        //{
                        //    ShowedEvent.Invoke();
                        //}
                    }

                }
            }
        }

        Storyboard StoryBoard = null;
        private bool disposedValue;

        public void Close()
        {
            if (CloseingEvent != null)
            {
                CloseingEvent.Invoke();
            }
            StoryBoard = Animation(1, 0, 1, 0.5);
            StoryBoard.Completed += Sbque_Completed;
            StoryBoard.Begin();
            if (CloseEvent != null)
            {
                CloseEvent.Invoke();
            }
        }

        private void Sbque_Completed(object? sender, EventArgs e)
        {
            FrameworkElement element;
            element = WindowHelper.GetActiveWindow();
            if (element == null)
                return;
            var decorator = WindowHelper.GetChild<AdornerDecorator>(element);
            ((element as Window)!.Content as FrameworkElement)!.IsEnabled = true;
            if (decorator != null && _container != null)
            {
                (this.Content as UIElement)!.Opacity = 1;
                AdornerLayer layer = decorator.AdornerLayer;
                _container.Child = null;
                layer.Remove(_container);
                _container = null;
                layer.Visibility = Visibility.Hidden;

                this.RaiseEvent(new RoutedEventArgs(DialogHost.UnloadedEvent));
            }
        }

        void SetOpenAnimation()
        {
            StoryBoard = Animation(0, 1, 0.5, 1);
            StoryBoard.Begin();
        }


        Storyboard Animation(double OpacityFrom, double OpacityTo, double ScaleFrom, double ScaleTo)
        {
            ScaleTransform scale = new ScaleTransform();   //缩放

            TransformGroup group = new TransformGroup();
            group.Children.Add(scale);

            (this.Content as UIElement)!.RenderTransform = group;

            (this.Content as UIElement)!.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);

            DoubleAnimation scaleAnimationx = new DoubleAnimation()
            {
                From = ScaleFrom,                                   //起始值
                To = ScaleTo,                                     //结束值
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 350)),
                EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut }
            };
            DoubleAnimation scaleAnimationy = new DoubleAnimation()
            {
                From = ScaleFrom,                                   //起始值
                To = ScaleTo,                                     //结束值
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 350)),
                EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut }
            };


            DoubleAnimation doubleAnimation = new DoubleAnimation()
            {
                From = OpacityFrom,
                To = OpacityTo,
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 350)),
                EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut },

                FillBehavior = FillBehavior.Stop
            };


            Storyboard sbque = new Storyboard();
            Storyboard.SetTarget(doubleAnimation, (DependencyObject)this.Content);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));


            Storyboard.SetTarget(scaleAnimationx, (DependencyObject)this.Content);
            Storyboard.SetTargetProperty(scaleAnimationx, new PropertyPath
                ("RenderTransform.(TransformGroup.Children)[0].(ScaleTransform.ScaleX)"));

            Storyboard.SetTarget(scaleAnimationy, (DependencyObject)this.Content);
            Storyboard.SetTargetProperty(scaleAnimationy, new PropertyPath
                ("RenderTransform.(TransformGroup.Children)[0].(ScaleTransform.ScaleY)"));
            sbque.Children.Add(doubleAnimation);
            sbque.Children.Add(scaleAnimationx);
            sbque.Children.Add(scaleAnimationy);
            return sbque;
        }




        /// <summary>
        /// 此内容为弹出框的全部内容，如果只需要一段文字，请使用ContentDialog.HostContent
        /// </summary>
        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }


        // Using a DependencyProperty as the backing store for Content.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(DialogHost), new PropertyMetadata(new object()));



        public event IDialogHost.Showing ShowingEvent;
        public event IDialogHost.Showed ShowedEvent;
        public event IDialogHost.Closed CloseEvent;
        public event IDialogHost.Closeing CloseingEvent;
    }
}
