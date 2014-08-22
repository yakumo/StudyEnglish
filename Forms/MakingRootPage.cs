using System;
using Xamarin.Forms;

namespace SEForms
{
	public class MakingRootPage : ContentPage
	{
		public MakingRootPage ()
		{
			Content = new StackLayout () {
				Children = {
					new Label () {
						Text = "Please Select",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
					},
					new Button () {
						Text = "Remake Data",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
					},
				},
			};
		}
	}
}

