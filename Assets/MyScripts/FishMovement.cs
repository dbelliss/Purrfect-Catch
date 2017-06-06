using UnityEngine;
using System.Collections;

public class FishMovement : MonoBehaviour {

	public Sprite[] sprites;
	void Start()
	{
	SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
		renderer.sprite = sprites[Random.Range(0,4)];
	//	renderer.color = new Color (Random.Range (1.0f, 1.0f), Random.Range (1.0f, 1.0f), Random.Range (1.0f, 1.0f));
	}

	public float speed;
	// Use this for initialization
	void Update() {
		if (Time.deltaTime > 0) {
			transform.Translate (speed, 0, 0 * Time.deltaTime);
			transform.Translate (new Vector3 (1, 0, 0) * Time.deltaTime, Space.World);
	
		}
	}
}

