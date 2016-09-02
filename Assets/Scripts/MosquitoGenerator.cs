using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MosquitoGenerator : MonoBehaviour {
	public GameObject tiny, big, parentObject, window, live1, live2, live3, qtd, score, scoreValue, recordValue;
	public Sprite blood;
	private float time1 = 0, time2 = 0, control1 = 10, control2 = 25, cont = 0;
	private int limite = 10;
	public int lives = 2;
	private GameObject[] clones;

	void FixedUpdate () {
		time1 += Time.deltaTime;
		time2 += Time.deltaTime;

		if(control1 > 0.5){
			cont += Time.deltaTime;
		}

		if (time1 >= control1 || time2 >= control2) {
			if (time1 >= control1) {
				GameObject childObject = Instantiate (tiny, new Vector3 (transform.position.x + Random.Range (1, 23) - 12, transform.position.y + Random.Range (1, 5) - 3, 0), Quaternion.identity) as GameObject;
				childObject.transform.parent = parentObject.transform;

				time1 = 0;
			} else {
				GameObject childObject = Instantiate (big, new Vector3 (transform.position.x + Random.Range (1, 23) - 12, transform.position.y + Random.Range (1, 5) - 3, 0), Quaternion.identity) as GameObject;
				childObject.transform.parent = parentObject.transform;

				time2 = 0;
			}

			int temp;
			int.TryParse (qtd.GetComponent<Text> ().text, out temp);

			qtd.GetComponent<Text> ().text = (temp + 1).ToString ();

			if (temp + 1 >= limite) {
				if (lives > 1) {
					if (lives == 3) {
						life1 (false);
					} else {
						life2 (false);
					}

					control1 = 5;
					control2 = 10;

					lives--;

					clones = GameObject.FindGameObjectsWithTag ("Mosquito");

					for (int i=0;i<clones.Length;i++) {
						Destroy (clones[i].GetComponent<Animator> ());
						clones[i].GetComponent<SpriteRenderer> ().sprite = blood;
						clones[i].GetComponent<SpriteRenderer> ().sortingOrder = 0;
						Destroy (clones[i].GetComponent<BoxCollider2D> ());
						Destroy (clones[i].GetComponent<AleatoryMovement> ());
						Destroy(clones[i].GetComponent<AudioSource> ());
						clones[i].GetComponent<DestroyMosquito> ().flag = true;
					}

					qtd.GetComponent<Text> ().text = "0";
				} else {
					EndGame ();
				}
			}
		}

		if (cont >= 8) {
			control1 -= 0.5f;
			control2 -= 1f;
			cont = 0;
		}
	}

	public void EndGame () {
		int temp2;
		int.TryParse (score.GetComponent<Text> ().text, out temp2);

		life3 (false);
		window.SetActive (true);

		scoreValue.GetComponent<Text> ().text = temp2.ToString ();

		int highScore;
		int.TryParse (GameObject.Find ("HighScore").GetComponent<Text> ().text, out highScore);

		if (temp2 > highScore) {
			GameObject.Find ("HighScore").GetComponent<Text> ().text = temp2.ToString ();
			recordValue.GetComponent<Text> ().text = temp2.ToString ();
		} else {
			recordValue.GetComponent<Text> ().text = highScore.ToString ();
		}

		clones = GameObject.FindGameObjectsWithTag ("Mosquito");

		for (int i=0;i<clones.Length;i++) {
			Destroy (clones[i]);
		}

		qtd.GetComponent<Text> ().text = "0";

		Destroy (this.gameObject.GetComponent<ObjectsGenerator> ());
		Destroy (this);
	}

	public void life1 (bool flag) {
		live1.SetActive (flag);
	}

	public void life2 (bool flag) {
		live2.SetActive (flag);
	}

	public void life3 (bool flag) {
		live3.SetActive (flag);
	}
}
