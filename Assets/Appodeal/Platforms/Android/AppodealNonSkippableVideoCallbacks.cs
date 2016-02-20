using UnityEngine;
using System.Collections;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.Android 
{
	public class AppodealNonSkippableVideoCallbacks 
		#if UNITY_ANDROID
		: AndroidJavaProxy
	{
		INonSkippableVideoAdListener listener;
		
		internal AppodealNonSkippableVideoCallbacks(INonSkippableVideoAdListener listener) : base("com.appodeal.ads.NonSkippableVideoCallbacks") {
			this.listener = listener;
		}
		
		void onNonSkippableVideoLoaded() {
			//Debug.Log("Appodeal onVideoLoaded");
			listener.onNonSkippableVideoLoaded();
		}
		
		void onNonSkippableVideoFailedToLoad() {
			//Debug.Log("Appodeal onVideoFailedToLoad");
			listener.onNonSkippableVideoFailedToLoad();
		}
		
		void onNonSkippableVideoShown() {
			//Debug.Log("Appodeal onVideoShown");
			listener.onNonSkippableVideoShown();
		}
		
		void onNonSkippableVideoFinished() {
			//Debug.Log("Appodeal onVideoFinished");
			listener.onNonSkippableVideoFinished();
		}
		
		void onNonSkippableVideoClosed() {
			//Debug.Log("Appodeal onRewardedVideoClosed");
			listener.onNonSkippableVideoClosed();
		}
	}
	#else
	{
		public AppodealNonSkippableVideoCallbacks(INonSkippableVideoAdListener listener) { }
	}
	#endif
}


