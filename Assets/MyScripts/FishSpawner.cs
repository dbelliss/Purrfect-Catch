using UnityEngine;
using System.Collections;

public class FishSpawner : MonoBehaviour {

	public GameObject fish;


	// Use this for initialization
	void Start () {
		StartCoroutine (spawner());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator spawner()
	{

		while (true) {
			Instantiate(fish, transform.position, transform.rotation);
			yield return new WaitForSeconds (3);

		
		}

	}
}
