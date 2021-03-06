// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Globalization;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using BingWall.Core.Helpers;
using BingWall.Core.Implementations;
using BingWall.Core.Interfaces;
using BingWall.Core.Models;

namespace BingWall.iOS
{
	public partial class TodaysBingViewController : UIViewController
	{
		IBingRepository bingRepo;
		BingImageURL bingURL;

		public TodaysBingViewController (IntPtr handle) : base (handle)
		{
			bingRepo = new BingRepository (BingServer.bingAddress, String.Empty);
			bingURL = new BingImageURL ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			syncBtn.TouchUpInside += LoadBingBackgroud;
		}

		public async void LoadBingBackgroud (object sender, EventArgs e)
		{
			var response = await bingRepo.GetBingHomepageBackground ();
			var image = bingURL.GetTodaysBingImageURL (response);
			string url = String.Format (CultureInfo.InvariantCulture, "{0}"+image.url, BingServer.bingAddress);
			ShowTodaysWallapaper (url);
		}

		public async void ShowTodaysWallapaper(string imageURL)
		{
			byte[] todaysImage = await bingRepo.GetImage(imageURL);
			UIImage bingImage = new UIImage (NSData.FromArray(todaysImage));
			todaysBingWallpaper.Image = bingImage;
		}
	}
}
