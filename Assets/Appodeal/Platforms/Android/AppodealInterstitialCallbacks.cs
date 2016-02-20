using UnityEngine;
using System;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.Android 
{
	public class AppodealInterstitialCallbacks
#if UNITY_ANDROID
		: AndroidJavaProxy
	{
		IInterstitialAdListener listener;	

		internal AppodealInterstitialCallbacks(IInterstitialAdListener listener) : base("com.appodeal.ads.InterstitialCallbacks") {
			this.listener = listener;
		}
		
		void onInterstitialLoaded(Boolean isPrecache) {
			//Debug.Log("Appodeal onInterstitialLoaded");
			listener.onInterstitialLoaded();
		}
		
		void onInterstitialFailedToLoad() {
			//Debug.Log("Appodeal onInterstitialFailedToLoad");
			listener.onInterstitialFailedToLoad();
		}
		
		void onInterstitialShown() {
			//Debug.Log("Appodeal onInterstitialShown");
			listener.onInterstitialShown();
		}
		
		void onInterstitialClicked() {
			//Debug.Log("Appodeal onInterstitialClicked");
			listener.onInterstitialClicked();
		}
		
		void onInterstitialClosed() {
			//Debug.Log("Appodeal onInterstitialClosed");
			listener.onInterstitialClosed();
		}
	}
#else
	{
		public AppodealInterstitialCallbacks(IInterstitialAdListener listener) { }
	}
#endif
}
