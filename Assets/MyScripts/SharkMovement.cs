using UnityEngine;
using System.Collections;

public class SharkMovement : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Update() {
		if (Time.deltaTime > 0) {
			transform.Translate (speed, 0, 0 * Time.deltaTime);
			transform.Translate (new Vector3 (1, 0, 0) * Time.deltaTime, Space.World);

		}
	}
}
