using UnityEngine;
using System.Collections;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.Android 
{
	public class AppodealSkippableVideoCallbacks 
#if UNITY_ANDROID
		: AndroidJavaProxy
	{
		ISkippableVideoAdListener listener;

		internal AppodealSkippableVideoCallbacks(ISkippableVideoAdListener listener) : base("com.appodeal.ads.SkippableVideoCallbacks") {
			this.listener = listener;
		}
		
		void onSkippableVideoLoaded() {
			//Debug.Log("Appodeal onVideoLoaded");
			listener.onSkippableVideoLoaded();
		}
		
		void onSkippableVideoFailedToLoad() {
			//Debug.Log("Appodeal onVideoFailedToLoad");
			listener.onSkippableVideoFailedToLoad();
		}
		
		void onSkippableVideoShown() {
			//Debug.Log("Appodeal onVideoShown");
			listener.onSkippableVideoShown();
		}
		
		void onSkippableVideoFinished() {
			//Debug.Log("Appodeal onVideoFinished");
			listener.onSkippableVideoFinished();
		}
		
		void onSkippableVideoClosed() {
			//Debug.Log("Appodeal onVideoClosed");
			listener.onSkippableVideoClosed();
		}
	}
#else
	{
		public AppodealSkippableVideoCallbacks(ISkippableVideoAdListener listener) { }
	}
#endif
}
