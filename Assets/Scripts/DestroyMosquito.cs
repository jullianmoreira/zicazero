using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroyMosquito : MonoBehaviour {
	private float time = 0;
	public bool flag = false;
	private int clicks = 0;
	private GameObject score, qtd;
	public Sprite blood;
	public AudioClip slap;

	void Start () {
		score = GameObject.Find ("Score");
		qtd = GameObject.Find ("Qtd");
	}

	void FixedUpdate(){
		if(flag){
			time += Time.deltaTime;

			if(time >= 3){
				Destroy (this.gameObject);
			}
		}
	}

	void OnMouseDown(){
		this.gameObject.GetComponent<AudioSource> ().Stop();
		this.gameObject.GetComponent<AudioSource> ().PlayOneShot (slap);

		if(!flag){
			if (this.gameObject.name.Contains ("Big")) {
				clicks++;

				if(clicks == 3) {
					flag = true;
				}
			} else {
				flag = true;
			}
		}

		if(flag){
			int temp, temp2;
			int.TryParse (score.GetComponent<Text> ().text, out temp);
			int.TryParse (qtd.GetComponent<Text> ().text, out temp2);

			Destroy (this.gameObject.GetComponent<Animator> ());
			Destroy (this.gameObject.GetComponent<BoxCollider2D> ());
			Destroy (this.gameObject.GetComponent<AleatoryMovement> ());

			this.gameObject.GetComponent<SpriteRenderer> ().sprite = blood;
			this.gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 0;

			if (this.gameObject.name.Contains ("Big")) {
				score.GetComponent<Text> ().text = (temp + 2).ToString();
			} else {
				score.GetComponent<Text> ().text = (temp + 1).ToString();
			}

			qtd.GetComponent<Text> ().text = (temp2 - 1).ToString();
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		clicks = 2;
		OnMouseDown ();
	}
}
