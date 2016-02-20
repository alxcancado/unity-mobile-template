using System;

namespace AppodealAds.Unity.Common
{
	// Interface for the methods to be invoked by the native plugin.
	public interface IBannerAdListener
	{
		void onBannerLoaded();
		void onBannerFailedToLoad();
		void onBannerShown();
		void onBannerClicked();
	}
}