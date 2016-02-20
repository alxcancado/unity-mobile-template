using System;
using UnityEngine;
using UnityEngine.UI;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

// Example script showing how to invoke the Appodeal Ads Unity plugin.
public class AppodealDemo1 : MonoBehaviour, IInterstitialAdListener, IBannerAdListener, ISkippableVideoAdListener, INonSkippableVideoAdListener, IRewardedVideoAdListener
{

	#if UNITY_EDITOR && !UNITY_ANDROID && !UNITY_IPHONE
		string appKey = "";
	#elif UNITY_ANDROID
		string appKey = "fee50c333ff3825fd6ad6d38cff78154de3025546d47a84f";
	#elif UNITY_IPHONE
		string appKey = "5ea7210f8cc1cf69790ba2ba90502621e99a72f4e73c350a";
	#else
		string appKey = "";
	#endif

	public Toggle LoggingToggle, TestingToggle, ConfirmToggle;

	public void Init() {
		//Example for UserSettings usage
		UserSettings settings = new UserSettings ();
		settings.setAge(25).setBirthday ("01/01/1990").setAlcohol(UserSettings.Alcohol.NEUTRAL)
			.setSmoking(UserSettings.Smoking.NEUTRAL).setEmail("hi@appodeal.com").setFacebookId("0987654321")
				.setVkId("87654321").setGender(UserSettings.Gender.OTHER).setRelation(UserSettings.Relation.DATING)
				.setInterests("gym, cars, cinema, science").setOccupation(UserSettings.Occupation.WORK);
		
		if (LoggingToggle.isOn) Appodeal.setLogging(true);
		if (TestingToggle.isOn) Appodeal.setTesting(true);
		if (ConfirmToggle.isOn) Appodeal.confirm(Appodeal.SKIPPABLE_VIDEO);
		Appodeal.setBannerCallbacks (this);
		Appodeal.setInterstitialCallbacks (this);
		Appodeal.setSkippableVideoCallbacks (this);
		Appodeal.setRewardedVideoCallbacks(this);
		Appodeal.initialize (appKey, Appodeal.INTERSTITIAL | Appodeal.BANNER | Appodeal.SKIPPABLE_VIDEO | Appodeal.REWARDED_VIDEO);
	}

	public void showInterstitial() {
		Appodeal.show (Appodeal.INTERSTITIAL);
	}

	public void showSkippableVideo() {
		Appodeal.show (Appodeal.SKIPPABLE_VIDEO);
	}

	public void showRewardedVideo() {
		Appodeal.show (Appodeal.REWARDED_VIDEO);
	}

	public void showBanner() {
		Appodeal.show (Appodeal.BANNER_BOTTOM);
	}

	public void showInterstitialOrVideo() {
		Appodeal.show (Appodeal.INTERSTITIAL | Appodeal.SKIPPABLE_VIDEO);
	}

	public void hideBanner() {
		Appodeal.hide (Appodeal.BANNER);
	}

	#region Banner callback handlers

	public void onBannerLoaded() { print("Banner loaded"); }
	public void onBannerFailedToLoad() { print("Banner failed"); }
	public void onBannerShown() { print("Banner opened"); }
	public void onBannerClicked() { print("banner clicked"); }

	#endregion

	#region Interstitial callback handlers
	
	public void onInterstitialLoaded() { print("Interstitial loaded"); }
	public void onInterstitialFailedToLoad() { print("Interstitial failed"); }
	public void onInterstitialShown() { print("Interstitial opened"); }
	public void onInterstitialClicked() { print("Interstitial clicked"); }
	public void onInterstitialClosed() { print("Interstitial closed"); }
	
	#endregion

	#region Video callback handlers

	public void onSkippableVideoLoaded() { print("Video loaded"); }
	public void onSkippableVideoFailedToLoad() { print("Skippable Video failed"); }
	public void onSkippableVideoShown() { print("Skippable Video opened"); }
	public void onSkippableVideoClosed() { print("Skippable Video closed"); }
	public void onSkippableVideoFinished() { print("Skippable Video finished"); }

	#endregion

	#region Non Skippable Video callback handlers
	
	public void onNonSkippableVideoLoaded() { print("NonSkippable Video loaded"); }
	public void onNonSkippableVideoFailedToLoad() { print("NonSkippable Video failed"); }
	public void onNonSkippableVideoShown() { print("NonSkippable Video opened"); }
	public void onNonSkippableVideoClosed() { print("NonSkippable Video closed"); }
	public void onNonSkippableVideoFinished() { print("NonSkippable Video finished"); }
	
	#endregion

	#region Rewarded Video callback handlers
	
	public void onRewardedVideoLoaded() { print("Rewarded Video loaded"); }
	public void onRewardedVideoFailedToLoad() { print("Rewarded Video failed"); }
	public void onRewardedVideoShown() { print("Rewarded Video opened"); }
	public void onRewardedVideoClosed() { print("Rewarded Video closed"); }
	public void onRewardedVideoFinished(int amount, String name) { print("Rewarded Video Reward: " + amount + " " + name); }
	
	#endregion
}
