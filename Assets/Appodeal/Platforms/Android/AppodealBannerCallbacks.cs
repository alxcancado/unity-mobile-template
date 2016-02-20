using UnityEngine;
using System;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.Android 
{
	public class AppodealBannerCallbacks
#if UNITY_ANDROID
		: AndroidJavaProxy
	{
		IBannerAdListener listener;	

		internal AppodealBannerCallbacks(IBannerAdListener listener) : base("com.appodeal.ads.BannerCallbacks") {
			this.listener = listener;
		}

		void onBannerLoaded() {
			//Debug.Log("Appodeal onBannerLoaded");
			listener.onBannerLoaded();
		}
			
		void onBannerFailedToLoad() {
			//Debug.Log("Appodeal onBannerFailedToLoad");
			listener.onBannerFailedToLoad();
		}
			
		void onBannerShown() {
			//Debug.Log("Appodeal onBannerShown");
			listener.onBannerShown();
		}
			
		void onBannerClicked() {
			//Debug.Log("Appodeal onBannerClicked");
			listener.onBannerClicked();
		}
	}
#else
	{
		public AppodealBannerCallbacks(IBannerAdListener listener) { }
	}
#endif
}

