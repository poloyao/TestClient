using DevExpress.Xpf.Docking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DXApplication1.Views
{
    /// <summary>
    /// Interaction logic for SettingManageView.xaml
    /// </summary>
    public partial class SettingManageView : UserControl
    {
        public SettingManageView()
        {
            InitializeComponent();
        }
        

        private void previewRich_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }

    public class PanelContentControl : ContentControl
    {
        #region static
        public static readonly DependencyProperty IndexNameProperty;
        public static readonly DependencyProperty CurrentChangeProperty;
        public static readonly DependencyProperty CurrentValueProperty;
        public static readonly DependencyProperty IsChangePositiveProperty;
        public static readonly DependencyProperty IsExpandedProperty;
        public static readonly DependencyProperty DataProperty;
        static PanelContentControl()
        {
            IndexNameProperty = DependencyProperty.Register("IndexName", typeof(string), typeof(PanelContentControl));
            CurrentChangeProperty = DependencyProperty.Register("CurrentChange", typeof(double), typeof(PanelContentControl),
                new PropertyMetadata(0.0, OnCurrentChangeChanged));
            CurrentValueProperty = DependencyProperty.Register("CurrentValue", typeof(double), typeof(PanelContentControl),
                new PropertyMetadata(0.0, OnCurrentValueChanged));
            IsChangePositiveProperty = DependencyProperty.Register("IsChangePositive", typeof(bool?), typeof(PanelContentControl),
                new PropertyMetadata(null, OnIsChangePositiveChanged));
            IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(PanelContentControl),
                new PropertyMetadata(false, OnIsExpandedChanged));
            DataProperty = DependencyProperty.Register("Data", typeof(ObservableCollection<Point>), typeof(PanelContentControl));
        }
        private static void OnCurrentValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PanelContentControl panelContentControl = (PanelContentControl)d;
            panelContentControl.CurrentChange = Math.Round((double)e.NewValue - (double)e.OldValue, 3);
        }
        private static void OnCurrentChangeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PanelContentControl panelContentControl = (PanelContentControl)d;
            panelContentControl.IsChangePositive = (double)e.NewValue == 0 ? null : (bool?)((double)e.NewValue > 0);
        }
        private static void OnIsChangePositiveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PanelContentControl)d).UpdateVisualState();
        }
        private static void OnIsExpandedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PanelContentControl)d).UpdateVisualState();
        }
        #endregion
        public PanelContentControl()
        {
            DefaultStyleKey = typeof(PanelContentControl);
            Background = Brushes.Transparent;
            Data = new ObservableCollection<Point>();
            Unloaded += new RoutedEventHandler(PanelContentControl_Unloaded);
            SizeChanged += new SizeChangedEventHandler(PanelContentControl_SizeChanged);
            Cursor = Cursors.Hand;
        }
        void PanelContentControl_Unloaded(object sender, RoutedEventArgs e)
        {
            if (PartBackButton != null)
            {
                PartBackButton.Click -= PartBackButton_Click;
            }
        }
        void PanelContentControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateVisualState();
        }
        public event EventHandler BackButtonClicked;
        protected void RaiseBackButtonClicked()
        {
            if (BackButtonClicked != null)
                BackButtonClicked(this, EventArgs.Empty);
        }
        Button PartBackButton { get; set; }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UpdateVisualState();
            PartBackButton = GetTemplateChild("PART_BackButton") as Button;
            if (PartBackButton != null)
            {
                PartBackButton.Click += new RoutedEventHandler(PartBackButton_Click);
            }
        }
        void PartBackButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseBackButtonClicked();
        }
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            UpdateVisualState();
        }
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            UpdateVisualState();
        }
        private void UpdateVisualState()
        {
            VisualStateManager.GoToState(this, IsMouseOver ? "MouseOver" : "Normal", true);
            if (IsChangePositive == null)
                VisualStateManager.GoToState(this, "Zero", false);
            if (IsChangePositive == true)
                VisualStateManager.GoToState(this, "Positive", false);
            if (IsChangePositive == false)
                VisualStateManager.GoToState(this, "Negative", false);
            if (IsExpanded)
            {
                Cursor = Cursors.Arrow;
                VisualStateManager.GoToState(this, "Checked", false);
            }
            else
            {
                Cursor = Cursors.Hand;
                VisualStateManager.GoToState(this, "Unchecked", false);
            }
            VisualStateManager.GoToState(this, RenderSize.Width < 165 ? "CompactView" : "AdvancedView", false);
        }
        public string IndexName
        {
            get { return (string)GetValue(IndexNameProperty); }
            set { SetValue(IndexNameProperty, value); }
        }
        public double CurrentChange
        {
            get { return (double)GetValue(CurrentChangeProperty); }
            set { SetValue(CurrentChangeProperty, value); }
        }
        public double CurrentValue
        {
            get { return (double)GetValue(CurrentValueProperty); }
            set { SetValue(CurrentValueProperty, value); }
        }
        public bool? IsChangePositive
        {
            get { return (bool?)GetValue(IsChangePositiveProperty); }
            set { SetValue(IsChangePositiveProperty, value); }
        }
        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }
        public ObservableCollection<Point> Data
        {
            get { return (ObservableCollection<Point>)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }
    }
}
