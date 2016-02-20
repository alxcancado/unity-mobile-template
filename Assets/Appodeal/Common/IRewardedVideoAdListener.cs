using System;

namespace AppodealAds.Unity.Common
{
	public interface IRewardedVideoAdListener
	{
		void onRewardedVideoLoaded();
		void onRewardedVideoFailedToLoad();
		void onRewardedVideoShown();
		void onRewardedVideoFinished(int amount, String name);
		void onRewardedVideoClosed();
	}
}
