using System;
using Xamarin.Forms;
using MonoTouch.UIKit;

namespace StudyEnglishDataMaker_iOS
{
	public static class FormExtention
	{
		public static Thickness PageTopPadding(this Page addedPage)
		{
			if (Device.OS == TargetPlatform.iOS) {
				if (UIDevice.CurrentDevice.CheckSystemVersion (7, 0)) {
					return new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);
				}
			}
			return new Thickness (0, 0, 0, 0);
		}
	}
}

