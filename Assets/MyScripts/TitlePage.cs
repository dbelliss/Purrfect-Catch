using UnityEngine;
using System.Collections;

public class TitlePage : MonoBehaviour {

	void Start(){
		GetComponent<Renderer>().material.color = Color.cyan; 
	}

	void OnMouseEnter(){
		GetComponent<Renderer>().material.color = Color.red; 
	}

	void OnMouseExit() {
		GetComponent<Renderer>().material.color = Color.cyan; 
	}
}