using System;
using Xamarin.Forms;
using System.ComponentModel;

namespace SEForms
{
	public class MakingRootPage : ContentPage
	{
		public event EventHandler DoStart;
		public event EventHandler DoDataShare;

		public Label StatusLabel { get; private set; }
		public ProgressBar StatusProgress { get; private set; }
		public Button StartButton{ get; private set; }
		public Button ShareButton{ get; private set; }

		public MakeingRootPageData Data { get; private set; }

		public MakingRootPage ()
		{
			Data = new MakeingRootPageData ();
			StatusLabel = new Label () {
				HorizontalOptions = LayoutOptions.Center,
			};
			StatusProgress = new ProgressBar () {
				Progress = 0.0,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			StartButton = new Button () {
				Text = "Push to Data Read",
				HorizontalOptions = LayoutOptions.Center,
			};
			ShareButton = new Button () {
				Text = "Push to Data share",
				HorizontalOptions = LayoutOptions.Center,
			};
			Content = new StackLayout () {
				Children = {
					StatusLabel,
					StatusProgress,
					StartButton,
					ShareButton,
				},
				Padding = new Thickness (30, 20),
			};

			StatusLabel.SetBinding (Label.TextProperty, "StatusMessage");
			StatusProgress.SetBinding (ProgressBar.ProgressProperty, "ProgressValue");
			StatusLabel.BindingContext = StatusProgress.BindingContext = Data;

			StartButton.Clicked += (sender, e) => {
				if(DoStart != null){
					DoStart(this, e);
				}
			};
			ShareButton.Clicked += (sender, e) => {
				if (DoDataShare != null) {
					DoDataShare (this, e);
				}
			};
		}

		public class MakeingRootPageData : INotifyPropertyChanged
		{
			#region INotifyPropertyChanged implementation
			public event PropertyChangedEventHandler PropertyChanged;
			private void OnPropertyChanged(string propertyName){
				if (PropertyChanged != null) {
					PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
				}
			}
			#endregion

			private string statusMessage = "";
			public string StatusMessage {
				get{ return statusMessage; }
				set {
					if (statusMessage != value) {
						statusMessage = value;
						OnPropertyChanged ("StatusMessage");
					}
				}
			}

			private double progressValue = 0;
			public double ProgressValue {
				get{ return progressValue; }
				set {
					if (progressValue != value) {
						progressValue = value;
						OnPropertyChanged ("ProgressValue");
					}
				}
			}
		}
	}
}

