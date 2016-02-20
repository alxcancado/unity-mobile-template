using System;
using AppodealAds.Unity;

namespace AppodealAds.Unity.Common {
	public interface IAppodealAdsClient {

		void initialize(String appKey, int type);

		void orientationChange ();
		void disableNetwork (String network);
		void disableNetwork (String network, int type);
		void disableLocationPermissionCheck();

		void setInterstitialCallbacks (IInterstitialAdListener listener);
		void setSkippableVideoCallbacks (ISkippableVideoAdListener listener);
		void setNonSkippableVideoCallbacks (INonSkippableVideoAdListener listener);
		void setRewardedVideoCallbacks (IRewardedVideoAdListener listener);
		void setBannerCallbacks (IBannerAdListener listener);
		void cache (int adTypes);
		void confirm(int adTypes);
		
		Boolean isLoaded (int adTypes);
		Boolean isLoadedWithPriceFloor (int adTypes);
		Boolean isPrecache (int adTypes);
		Boolean show(int adTypes);
		Boolean showWithPriceFloor(int adTypes);

		void hide (int adTypes);
		void setAutoCache (int adTypes, Boolean autoCache);
		void setOnLoadedTriggerBoth (int adTypes, Boolean onLoadedTriggerBoth);
		void setTesting(Boolean test);
		void setLogging(Boolean logging);
		void trackInAppPurchase(double amount, string currency);
		
		string getVersion();

		void setAge(int age);
		void setBirthday(string bDay);
		void setEmail(String email);
		void setFacebookId(String fbId);
		void setVkId(String vkId);
		void setGender(int gender);
		void setInterests(String interests);
		void setOccupation(int occupation);
		void setRelation(int relation);
		void setAlcohol(int alcohol);
		void setSmoking(int smoking);
		void getUserSettings();

	}
}
