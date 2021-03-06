﻿using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using SEForms;
using System.Threading;

namespace StudyEnglishDataMaker_iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		
		public override UIWindow Window {
			get;
			set;
		}

		/*
		// This method is invoked when the application is about to move from active to inactive state.
		// OpenGL applications should use this method to pause.
		public override void OnResignActivation (UIApplication application)
		{
		}
		
		// This method should be used to release shared resources and it should store the application state.
		// If your application supports background exection this method is called instead of WillTerminate
		// when the user quits.
		public override void DidEnterBackground (UIApplication application)
		{
		}
		
		// This method is called as part of the transiton from background to active state.
		public override void WillEnterForeground (UIApplication application)
		{
		}
		
		// This method is called when the application is about to terminate. Save data, if needed.
		public override void WillTerminate (UIApplication application)
		{
		}
		*/

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			// NOTE: Don't call the base implementation on a Model class
			// see http://docs.xamarin.com/guides/ios/application_fundamentals/delegates,_protocols,_and_events

			Forms.Init ();

			Window = new UIWindow (UIScreen.MainScreen.Bounds);
			MakingRootPage p = new MakingRootPage ();
			p.Padding = p.PageTopPadding ();
			Window.RootViewController = p.CreateViewController ();
			Window.MakeKeyAndVisible ();

			p.Data.StatusMessage = "Please select";

			p.DoStart += (sender, e) => {
				ThreadPool.QueueUserWorkItem (new WaitCallback ((st) => {
					MakingRootPage.MakeingRootPageData data = (MakingRootPage.MakeingRootPageData)st;
				}), p.Data);
			};

			return true;
		}
	}
}

