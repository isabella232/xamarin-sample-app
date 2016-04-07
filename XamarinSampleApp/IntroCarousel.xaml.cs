using System;
using System.Collections.Generic;

using Xamarin.Forms;

using Xamarin.Social;
using Xamarin.Social.Services;

using System.Threading.Tasks;
using Xamarin.Media;

using XamarinSampleApp.Common;

namespace XamarinSampleApp
{
	public partial class IntroCarousel : CarouselPage
	{
		private ICameraProvider cameraProvider;
		public String PicturePath { get; set; }

		public IntroCarousel ()
		{
			InitializeComponent ();

			this.cameraProvider = DependencyService.Get<ICameraProvider>();

			TourButton.Clicked += (object sender, EventArgs e) =>
			{
				this.CurrentPage = this.Children [1];
			};

			TweetButton.Clicked += async (object sender, EventArgs e) =>
			{
				if (Device.OS == TargetPlatform.iOS) {
					await TakePictureAsync();
				}

				var tweetText = "Just completed the @bitrise Mini Hack at #XamarinEvolve!";
				DependencyService.Get<ISocialController> ().TweetWithItem (tweetText, this.PicturePath);
			};

			this.CurrentPageChanged += (object sender, EventArgs e) =>
			{
				if (this.CurrentPage == this.Children[0])
				{
					DependencyService.Get<IAppearance> ().UpdateBackground (0.231, 0.764, 0.639);
				}
				else
				{
					DependencyService.Get<IAppearance> ().UpdateBackground (0.505, 0.317, 0.658);
				}
			};
		}

		private async Task TakePictureAsync()
		{
			var photoResult = await cameraProvider.TakePictureAsync();

			if (photoResult != null)
			{
				PicturePath = photoResult.FilePath;
			}
		}
	}
}

