using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;       //Public variable to store a reference to the player game object
	float xpos;

	private Vector3 offset;         //Private variable to store the offset distance between the player and camera

	// Use this for initialization
	void Start () 
	{
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		offset = transform.position - player.transform.position;
	}

	// LateUpdate is called after Update each frame
	void LateUpdate () 
	{
		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.

		Vector3 pos = player.transform.position + offset;

		if (player.transform.position.x > 11.5) {
			transform.position = new Vector3 (0, player.transform.position.y, 0) + new Vector3 (xpos, offset.y, offset.z);
		} else if (player.transform.position.x < -11.5) {
			transform.position = new Vector3 (0, player.transform.position.y, 0) + new Vector3 (xpos, offset.y, offset.z);

			
		} else {
			transform.position = pos;
			xpos =  player.transform.position.x + offset.x;

		}
	}
}