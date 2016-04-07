using System;

using Xamarin.Social;
using Xamarin.Social.Services;

namespace XamarinSampleApp.Common
{
	public interface ISocialController
	{
		void TweetWithItem(string text, string image);
	}
}