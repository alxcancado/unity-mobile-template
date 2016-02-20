using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadLevelFading : MonoBehaviour {

	public string level;


	// Use this for initialization
	void Start () {

		StartCoroutine ("WaitBeforeLoadLevel");
	
	}

	public void LoadLevel(string level){
		Application.LoadLevel(level);
	}


	IEnumerator WaitBeforeLoadLevel(){

		yield return new WaitForSeconds(2);
		Application.LoadLevel(Application.loadedLevel+1);		// or the name of your level scene

	}

	IEnumerator WaitBeforeLoadLevel(string level){

		yield return new WaitForSeconds(2);
		Application.LoadLevel(level);		// or the name of your level scene

	}


}
