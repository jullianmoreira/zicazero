using UnityEngine;
using System.Collections;

public class ObjectsGenerator : MonoBehaviour {
	public GameObject tire, waterTire, vase, waterVase;
	private float time = 0;

	void FixedUpdate () {
		time += Time.deltaTime;

		if (time >= 20) {
			int sorteio = Random.Range (1, 5);

			switch (sorteio) {
				case 1:
					GameObject childObject1 = Instantiate (tire, new Vector3 (-18, -3, 0), Quaternion.identity) as GameObject;
				break;
					
				case 2:
					GameObject childObject2 = Instantiate (waterTire, new Vector3 (-18, -3, 0), Quaternion.identity) as GameObject;
				break;

				case 3:
					GameObject childObject3 = Instantiate (vase, new Vector3 (-18, -3, 0), Quaternion.identity) as GameObject;
				break;

				case 4:
					GameObject childObject4 = Instantiate (waterVase, new Vector3 (-18, -3, 0), Quaternion.identity) as GameObject;
				break;
			}

			time = 0;
		}
	}
}
