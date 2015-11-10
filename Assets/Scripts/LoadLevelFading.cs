using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadLevelFading : MonoBehaviour {

	public string level;


	// Use this for initialization
	void Start () {

		StartCoroutine ("WaitBeforeLoadLevel");
	
	}


	IEnumerator WaitBeforeLoadLevel(){

		yield return new WaitForSeconds(2);
		Application.LoadLevel(Application.loadedLevel+1);		// or the name of your level scene

	}


}
