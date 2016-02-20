using System;

namespace AppodealAds.Unity.Common
{
	// Interface for the methods to be invoked by the native plugin.
	public interface IInterstitialAdListener
	{
		void onInterstitialLoaded();
		void onInterstitialFailedToLoad();
		void onInterstitialShown();
		void onInterstitialClosed();
		void onInterstitialClicked();
	}
}
