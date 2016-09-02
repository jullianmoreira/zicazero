using UnityEngine;
using System.Collections;

public class KeepObject : MonoBehaviour {
	void Awake() {
		DontDestroyOnLoad (this.gameObject);
	}
}
