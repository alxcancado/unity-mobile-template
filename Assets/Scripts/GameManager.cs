using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

	// General texts config
	public string companyURL;
	public string gameName;
	private string shareText;

	// for twitter sharing
	public string twitterParamVia;
	public string twitterParamRelated;
	public string twitterParamHashtags;

	// General audio/sfx files
	public AudioMixer masterMixer;
	public AudioClip companySFX;
	public AudioClip setSFX;
	public AudioClip cancelSFX;

	// Button Sound config
	private bool soundButtonIsPlaying = true;
	public Button soundButton;
	public Sprite soundButtonOn;
	public Sprite soundButtonOff;

	// Labels config
	public Text score;

	// Banner Animation
	public Animator footBarMenu;
	public Animator footBarBanner;

	void Start(){
		
	}

	public void OpenWebsite(){
		float audioSize = companySFX.length;
		Camera.main.GetComponent<AudioSource>().PlayOneShot(companySFX);
		StartCoroutine("WaitSeconds",audioSize);
		Application.OpenURL(companyURL);
	}


	public void ShareTwitter(){
		// game score handling. read the playerprefs, trim the text (if you saved text together)
		char[] charsToTrim = { 'B', 'e', 's', 't', ':',' '};
		int points = int.Parse(score.text.TrimStart(charsToTrim));

		// twitter share URL
		shareText = "I'm playing "+gameName+" and got a new Hi-score: "+points;
		string completeUrl = "https://twitter.com/share?url="+Uri.EscapeDataString(companyURL)
			+"&text="+Uri.EscapeDataString(shareText)
			+"&hashtags="+Uri.EscapeDataString(twitterParamHashtags)
			//+"&via="+via // "&via=" parameter ads 3 chars; better use <space> (%20) + @ (%40), 1 char only hahah
			+"%20%40"+Uri.EscapeDataString(twitterParamVia)
			+"&related="+Uri.EscapeDataString(twitterParamRelated)
			+"";

		//Application.ExternalEval("window.open('"+urlGame+"','_blank')");
		Application.OpenURL (completeUrl);
		//Debug.Log(completeUrl);
		//TEST URL: https://twitter.com/share?url=http%3A%2F%2Fgoo.gl%2FZ0XhGK&text=I%27m%20Playing%20GAME%20NAME%20and%20got%20a%20new%20Hi-score%3A%200000.&hashtags=diygamedev%2Cunity%2Cunity3d%20%40"diygamedev&related=alxcancado
	}



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
		if(soundButtonIsPlaying){
			// mute mixer
			masterMixer.SetFloat("VolumeMasterMixer",-80f);
			soundButtonIsPlaying = !soundButtonIsPlaying;
			soundButton.GetComponent<Image>().sprite = soundButtonOff;
		} else {
			// normal volume
			masterMixer.SetFloat("VolumeMasterMixer",0f);
			soundButtonIsPlaying = !soundButtonIsPlaying;
			soundButton.GetComponent<Image>().sprite = soundButtonOn;
		}
	}

	public void RotateFootBanner(){
		// set conditions of these two animations. invert values every action
		footBarMenu.SetBool("isHidden", !footBarMenu.GetBool("isHidden"));
		footBarBanner.SetBool("isHidden", !footBarMenu.GetBool("isHidden"));
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