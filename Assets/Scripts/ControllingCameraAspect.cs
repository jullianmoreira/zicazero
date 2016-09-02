using UnityEngine;
using System.Collections;

public class ControllingCameraAspect : MonoBehaviour {
	void Start () {
		Camera.main.projectionMatrix = Matrix4x4.Ortho (-11.0f, 11.0f, -3.0f, 3.0f, 0.3f, 1000f);
	}
}
