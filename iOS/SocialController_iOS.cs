using System;
using AVFoundation;
using Xamarin.Forms;
using XamarinSampleApp.iOS;
using XamarinSampleApp.Common;

using Xamarin.Social;
using Xamarin.Social.Services;

using UIKit;

[assembly: Dependency (typeof (SocialController_iOS))]
namespace XamarinSampleApp.iOS
{
	public class SocialController_iOS : ISocialController
	{
		public SocialController_iOS()
		{
			
		}

		public void TweetWithItem(string text, string image)
		{
			var rootViewController = UIApplication.SharedApplication.KeyWindow.RootViewController;

			var twitter = new Twitter5Service ();

			var item = new Item { Text = text };
			if (image != null)
			{
				item.Images.Add(image);
			}
			var shareUI = twitter.GetShareUI(item, result => {
				rootViewController.DismissViewController (true, null);
			});

			rootViewController.PresentViewController(shareUI, true, null);
		}
	}
}