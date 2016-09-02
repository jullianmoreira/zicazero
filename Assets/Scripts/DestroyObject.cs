using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroyObject : MonoBehaviour {
	public GameObject tiny, big;
	public Sprite blood;
	private GameObject qtd, score, parentObject;
	private GameObject[] clones;

	void Start () {
		score = GameObject.Find ("Score");
		qtd = GameObject.Find ("Qtd");
		parentObject = GameObject.Find ("Mosquitoes");
	}

	void OnMouseDown () {
		Destroy (this.gameObject);

		if (this.gameObject.name.Equals ("WaterTire(Clone)")) {
			int temp;
			int.TryParse (score.GetComponent<Text> ().text, out temp);

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

			temp += clones.Length;

			qtd.GetComponent<Text> ().text = "0";
			score.GetComponent<Text> ().text = temp.ToString ();
		} else if (this.gameObject.name.Equals ("Tire(Clone)")) {
			int temp;
			int.TryParse (qtd.GetComponent<Text> ().text, out temp);

			for (int i=0;i<2;i++) {
				GameObject childObject = Instantiate (tiny, new Vector3 (transform.position.x + Random.Range (1, 23) - 12, transform.position.y + Random.Range (1, 5) - 3, 0), Quaternion.identity) as GameObject;
				childObject.transform.parent = parentObject.transform;

				GameObject childObject2 = Instantiate (big, new Vector3 (transform.position.x + Random.Range (1, 23) - 12, transform.position.y + Random.Range (1, 5) - 3, 0), Quaternion.identity) as GameObject;
				childObject2.transform.parent = parentObject.transform;
			}

			qtd.GetComponent<Text> ().text = (temp + 4).ToString ();
		} else if (this.gameObject.name.Equals ("WaterVase(Clone)")) {
			int lives = Camera.main.GetComponent<MosquitoGenerator> ().lives;

			if (lives == 1) {
				Camera.main.GetComponent<MosquitoGenerator> ().life2 (true);
				Camera.main.GetComponent<MosquitoGenerator> ().lives++;
			} else if (lives == 2) {
				Camera.main.GetComponent<MosquitoGenerator> ().life1 (true);
				Camera.main.GetComponent<MosquitoGenerator> ().lives++;
			}
		} else {
			int lives = Camera.main.GetComponent<MosquitoGenerator> ().lives;

			if (lives == 1) {
				Camera.main.GetComponent<MosquitoGenerator> ().EndGame ();
			} else if (lives == 2) {
				Camera.main.GetComponent<MosquitoGenerator> ().life2 (false);
				Camera.main.GetComponent<MosquitoGenerator> ().lives--;
			} else {
				Camera.main.GetComponent<MosquitoGenerator> ().life1 (false);
				Camera.main.GetComponent<MosquitoGenerator> ().lives--;
			}
		}
	}
}
