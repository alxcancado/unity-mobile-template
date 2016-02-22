using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

	public Texture2D 	fadeOutTexture; 	// texture that will overlay the screen. Can be a black img or loading graphic

	public float 		fadeSpeed = 0.2f;	// fading speed

	private int			drawDepth = -1000;	// order in draw hierarchy. low number renders at top

	private float		alpha = 1.0f;		// texture's alpha value between 0 and 1

	public int			fadeDir = -1;		// direction to fade: in = -1, out = 1



	void OnGUI(){

		// fading in/out using direction, speed, time.deltatime and convert the operation to seconds
		alpha += fadeDir * fadeSpeed * Time.deltaTime;

		// force Clamp the number between 0 and 1 because it is the values that we can use in alpha
		alpha = Mathf.Clamp01 (alpha);

		// set color of our GUI (this case, a texture). All color values remain the same but the Alpha is set by alpha variable
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);		// set the alpha value
		GUI.depth = drawDepth;														// make this texture renders on top of everything - draw last
		GUI.DrawTexture( new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture );	// draw the texture to fit all the screen

	}

	// set the direction parameter, if is -1 fade in, if 1 then fade out
	public float BeginFade( int direction ){

		fadeDir = direction;

		return fadeSpeed;	//return the speed of fade so we can apply to Application.LoadLevel()

	}

	public void OnLevelWasLoaded () {

		alpha = 1;		// use this if a	lpha its not set to 1 by default
		BeginFade (-1);		// call the fade in function

	}

	/* Note:
	 * 
	 * dont forget to add an texture image to your project. it can be a 2x2 black image will do the job. Inspector config: texture, clamp, point, size 32, 16bits.
	 * 
	 * when its time to load a level, use something like this:
	 * 
	 * 		
	 * 	IENumerator ChangeLevel(){
	 * 		// fade out and in a new level
	 * 		float fadeTime = GameObject.Find("thegameobjectwherethefadescriptis").GetComponent<Fading>().BeginFade(1);
	 * 		yield return new WaitForSeconds(fadeTime);
	 * 		Application.LoadLevel(Application.loadedLevel + 1);		// or the name of your level scene
	 * }
	 */
}
