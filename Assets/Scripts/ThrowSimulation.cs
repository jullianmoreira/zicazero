using UnityEngine;
using System.Collections;

public class ThrowSimulation : MonoBehaviour {
	private GameObject myTarget;
	private float shootAngle = 30.0f, time = 0.0f;
	private bool flag = true;

	void Start () {
		myTarget = GameObject.Find ("Target");
	}

	void FixedUpdate () {
		if (flag) {
			this.GetComponent<Rigidbody2D> ().velocity = teste1 (this.transform, myTarget.transform, shootAngle);
			flag = false;
		}

		if (time >= 2.0f) {
			Destroy (this.gameObject);
		}

		time += Time.deltaTime;
	}

	Vector3 teste1 (Transform source, Transform target, float angle) {
		Vector3 direction = target.position - source.position;

		float h = direction.y;

		float distance = direction.magnitude;

		float a = angle * Mathf.Deg2Rad;

		direction.y = distance * Mathf.Tan (a);

		distance += h / Mathf.Tan (a);

		float velocity = Mathf.Sqrt (distance * Physics.gravity.magnitude / Mathf.Sin (2 * a));

		return velocity * direction.normalized;
	}
}