using UnityEngine;
using System.Collections;

public class AleatoryMovement : MonoBehaviour {
	private float xMax  = 10.2f, yMax = 2.2f, xMin = -10.2f, yMin = -2.7f, x, y, tempo, angulo, cont, velocidadeMax = 0.03f;

	void Start () {
		 x = Random.Range(-velocidadeMax, velocidadeMax);
         y = Random.Range(-velocidadeMax, velocidadeMax);
	}
	
	void FixedUpdate () {
		tempo += Time.deltaTime;
		cont += Time.deltaTime;
 		
        if (transform.localPosition.x > xMax) {
            x = Random.Range(-velocidadeMax, 0.0f);
            tempo = 0.0f; 
        }
        if (transform.localPosition.x < xMin) {
            x = Random.Range(0.0f, velocidadeMax);
            tempo = 0.0f; 
        }
        if (transform.localPosition.y > yMax) {
            y = Random.Range(-velocidadeMax, 0.0f);
            tempo = 0.0f; 
        }
        if (transform.localPosition.y < yMin) {
            y = Random.Range(0.0f, velocidadeMax);
            tempo = 0.0f; 
        }
 
        if (tempo > 1.0f) {
             x = Random.Range(-velocidadeMax, velocidadeMax);
             y = Random.Range(-velocidadeMax, velocidadeMax);
             tempo = 0.0f;
        }

		if (cont > 4f && velocidadeMax < 0.5f) {
			velocidadeMax += 0.02f;
			cont = 0;
		}
 
        transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y + y, 0.0f);
	}
}
