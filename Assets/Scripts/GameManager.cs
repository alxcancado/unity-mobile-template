using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public string companyURL;

	public AudioClip companySFX;
	public AudioClip setSFX;

	public void OpenWebsite(){
		float audioSize = companySFX.length;
		Camera.main.GetComponent<AudioSource>().PlayOneShot(companySFX);
		StartCoroutine("WaitSeconds",audioSize);
		Application.OpenURL(companyURL);
	}

	public void PlaySFX( AudioClip audio){
		float audioSize = audio.length;
		Camera.main.GetComponent<AudioSource>().PlayOneShot(audio);
		StartCoroutine("WaitSeconds",audioSize);
	}

	IEnumerator WaitSeconds(float seconds){
		yield return new WaitForSeconds(seconds);
	}
}
