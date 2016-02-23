using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public string companyURL;

	public AudioClip companySFX;
	public AudioClip setSFX;
	public AudioClip cancelSFX;

	public AudioMixer masterMixer;
	private bool isOn = true;

	public Button soundButton;
	public Sprite soundButtonOn;
	public Sprite soundButtonOff;


	public void OpenWebsite(){
		float audioSize = companySFX.length;
		Camera.main.GetComponent<AudioSource>().PlayOneShot(companySFX);
		StartCoroutine("WaitSeconds",audioSize);
		Application.OpenURL(companyURL);
	}

	/*
	public void ShareTwitter(){
		char[] charsToTrim = { 's', 'c', 'o', 'r', 'e', ' '};
		int points = int.Parse(score.text.TrimStart(charsToTrim));
		string urlGame = "http://goo.gl/Xmj8Q5";
		string allUrl = "https://twitter.com/intent/tweet?text=OmG%21%20NASA%20used%20this%20game%20to%20test%20my%20focus%20skills%21%20I%20got%20"+points+"%21%20%23Finding%23Pluto%20%40alxcancado%20&url="+urlGame;
		//Application.ExternalEval("window.open('"+urlGame+"','_blank')");
		Application.OpenURL ("https://twitter.com/share?url="+"http%3A%2F%2Fgoo.gl%2FXmj8Q5"+"&text=OmG%21%20NASA%20used%20this%20game%20to%20test%20my%20focus%20skills%21%20I%20got%20"+"points"+"%21%20%23Finding%23Pluto%20&via=diygdev&related=alxcancado");
		//https://twitter.com/share?url=https%3A%2F%2Fdev.twitter.com%2Fweb%2Ftweet-button&via=twitterdev&related=twitterapi%2Ctwitter&hashtags=example%2Cdemo&text=custom%20share%20text
	}
*/


	public void PlaySFX( AudioClip audio){
		float audioSize = audio.length;
		Camera.main.GetComponent<AudioSource>().PlayOneShot(audio);
		StartCoroutine("WaitSeconds",audioSize);
	}

	IEnumerator WaitSeconds(float seconds){
		yield return new WaitForSeconds(seconds);
	}

	private void SetMasterMixer(float volumeMasterMixer){
		masterMixer.SetFloat("volumeMasterMixer",volumeMasterMixer);
	}

	public void SetSoundOnOff(){
		if(isOn){
			// mute mixer
			masterMixer.SetFloat("VolumeMasterMixer",-80f);
			isOn = !isOn;
			soundButton.GetComponent<Image>().sprite = soundButtonOff;
		} else {
			// normal volume
			masterMixer.SetFloat("VolumeMasterMixer",0f);
			isOn = !isOn;
			soundButton.GetComponent<Image>().sprite = soundButtonOn;
		}
	}
	/*
	<!-- Basic Share Links -->

	<!-- Twitter (url, text, @mention) -->
	<a href="http://twitter.com/share?url=<URL>&text=<TEXT>via=<USERNAME>">
		Twitter
		</a>

		<!-- Google Plus (url) -->
		<a href="https://plus.google.com/share?url=<URL>">
		Google Plus
		</a>

		<!-- Facebook (url) -->
		<a href="http://www.facebook.com/sharer/sharer.php?u=<URL>">
		Facebook
		</a>

		<!-- StumbleUpon (url, title) -->
		<a href="http://www.stumbleupon.com/submit?url=<URL>&title=<TITLE>">
		StumbleUpon
		</a>

		<!-- Reddit (url, title) -->
		<a href="http://reddit.com/submit?url=<URL>&title=<TITLE>">
		Reddit
		</a>

		<!-- LinkedIn (url, title, summary, source url) -->
		<a href="http://www.linkedin.com/shareArticle?url=<URL>&title=<TITLE>&summary=<SUMMARY>&source=<SOURCE_URL>">
		LinkedIn
		</a>

		<!-- Email (subject, body) -->
		<a href="mailto:?subject=<SUBJECT>&body=<BODY>">
		Email
		</a>
		*/
}