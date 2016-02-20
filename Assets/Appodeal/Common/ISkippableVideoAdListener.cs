using System;

namespace AppodealAds.Unity.Common
{
	// Interface for the methods to be invoked by the native plugin.
	public interface ISkippableVideoAdListener
	{
		void onSkippableVideoLoaded();
		void onSkippableVideoFailedToLoad();
		void onSkippableVideoShown();
		void onSkippableVideoFinished();
		void onSkippableVideoClosed();
	}
}
