using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.OrdenarFinanzas.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.OrdenarFinanzas.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReportesPage : ContentPage
	{
        
        private readonly ChartEntry[] entries = new[]
        {
            new ChartEntry(112)
            {
                Label = "UWP",
                ValueLabel = "112",
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry(648)
            {
                Label = "Android",
                ValueLabel = "648",
                Color = SKColor.Parse("#77d065")
            },
            new ChartEntry(428)
            {
                Label = "iOS",
                ValueLabel = "428",
                Color = SKColor.Parse("#b455b6")
            },
        };
        public ReportesPage ()
		{
			InitializeComponent ();
            charViewBar.Chart = new BarChart { Entries = entries, ValueLabelOrientation = Orientation.Horizontal, LabelTextSize = 30, AnimationProgress = 10, LabelOrientation = Orientation.Horizontal };
            charViewPie.Chart = new PieChart { Entries = entries, LabelTextSize = 30, AnimationProgress = 10, HoleRadius = 0.3f };
            charViewLine.Chart = new LineChart { Entries = entries, ValueLabelOrientation = Orientation.Horizontal, LabelTextSize = 30, AnimationProgress = 10, LabelOrientation = Orientation.Horizontal, LineMode = LineMode.Straight };
        }

	}
}