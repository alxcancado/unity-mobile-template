using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadLevelFading : MonoBehaviour {

	public string level;


	// Use this for initialization
	void Start () {

		// if is the Splash scene, auto load to menu

		if (Application.loadedLevelName == "splash"){
			level = "title";
			StartCoroutine ("WaitBeforeLoadLevel",level);
		}
	}

	public void LoadLevel(string level){
		StartCoroutine ("WaitBeforeLoadLevel",level);
	}



	IEnumerator WaitBeforeLoadLevel(string level){
		if (Application.loadedLevelName == "splash"){
			yield return new WaitForSeconds(2);
		}
		float fadeTime = Camera.main.GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime+2);
		//yield return new WaitForSeconds(2);
		Application.LoadLevel(level);		// or the name of your level scene

	}


}
