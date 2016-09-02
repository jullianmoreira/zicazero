using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DelaySplashScreen : MonoBehaviour {
	private float delayTime = 5;

	IEnumerator Start () { 
		yield return new WaitForSeconds( delayTime );
		SceneManager.LoadScene("MenuHome");
	}
}
