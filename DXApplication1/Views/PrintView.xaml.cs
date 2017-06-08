using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for PrintView.xaml
    /// </summary>
    public partial class PrintView : UserControl
    {
        public PrintView()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Window owner = LayoutHelper.FindParentObject<Window>(this);
            gridControl.View.ShowPrintPreviewDialog(owner);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DevExpress.XtraPrinting.XlsxExportOptionsEx option = new DevExpress.XtraPrinting.XlsxExportOptionsEx()
            {
                ExportType = DevExpress.Export.ExportType.WYSIWYG,
                TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text,
                ShowGridLines = true,

            };
            (gridControl.View as TableView).ExportToXlsx($"{System.Environment.CurrentDirectory}\\临时文件.xlsx", option);
            System.Diagnostics.Process.Start($"{System.Environment.CurrentDirectory}\\临时文件.xlsx");
        }
    }
}
