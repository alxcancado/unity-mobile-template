using UnityEngine;
using System.Collections;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.Android 
{
	public class AppodealRewardedVideoCallbacks 
		#if UNITY_ANDROID
		: AndroidJavaProxy
	{
		IRewardedVideoAdListener listener;
		
		internal AppodealRewardedVideoCallbacks(IRewardedVideoAdListener listener) : base("com.appodeal.ads.RewardedVideoCallbacks") {
			this.listener = listener;
		}
		
		void onRewardedVideoLoaded() {
			//Debug.Log("Appodeal onVideoLoaded");
			listener.onRewardedVideoLoaded();
		}
		
		void onRewardedVideoFailedToLoad() {
			//Debug.Log("Appodeal onVideoFailedToLoad");
			listener.onRewardedVideoFailedToLoad();
		}
		
		void onRewardedVideoShown() {
			//Debug.Log("Appodeal onVideoShown");
			listener.onRewardedVideoShown();
		}
		
		void onRewardedVideoFinished(int amount, string name) {
			//Debug.Log("Appodeal onVideoFinished");
			listener.onRewardedVideoFinished(amount, name);
		}
		
		void onRewardedVideoClosed() {
			//Debug.Log("Appodeal onRewardedVideoClosed");
			listener.onRewardedVideoClosed();
		}
	}
	#else
	{
		public AppodealRewardedVideoCallbacks(IRewardedVideoAdListener listener) { }
	}
	#endif
}


