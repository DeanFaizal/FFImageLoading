using System;
using Microsoft.Maui.Controls;

namespace Simple.Maui.Sample
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			var vm = new BasicPageModel();
			vm.Reload();
			BindingContext = vm;
		}

		public class BasicPageModel
		{
			public void Reload()
			{
				// ImageUrl = Helpers.GetRandomImageUrl();
				ImageUrl = @"https://raw.githubusercontent.com/recurser/exif-orientation-examples/master/Landscape_3.jpg";
			}

			public string ImageUrl { get; set; }
		}
	}
}
