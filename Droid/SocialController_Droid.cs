using System;
using Xamarin.Forms;
using XamarinSampleApp.Droid;
using XamarinSampleApp.Common;

using Xamarin.Social;
using Xamarin.Social.Services;
using Android.Content;
using Android.App;
using Android.Content.PM;
using System.Collections.Generic;

[assembly: Dependency (typeof (SocialController_Droid))]
namespace XamarinSampleApp.Droid
{
	public class SocialController_Droid : ISocialController
	{
		public SocialController_Droid()
		{

		}

		public void TweetWithItem(string text, string image)
		{
			Intent tweetIntent = new Intent(Intent.ActionSend);
			tweetIntent.PutExtra(Intent.ExtraText, text);
			tweetIntent.SetType("text/plain");

			PackageManager pm = Forms.Context.PackageManager;
			IList<ResolveInfo> resolvedInfoList = pm.QueryIntentActivities(tweetIntent, PackageInfoFlags.MatchDefaultOnly);

			foreach(ResolveInfo resolveInfo in resolvedInfoList) {
				if(resolveInfo.ActivityInfo.PackageName.StartsWith("com.twitter.android")) {
					tweetIntent.SetClassName(resolveInfo.ActivityInfo.PackageName, resolveInfo.ActivityInfo.Name);
					Forms.Context.StartActivity(tweetIntent);
				}
			}
		}
	}
}