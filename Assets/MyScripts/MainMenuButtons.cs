using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainMenuButtons : MonoBehaviour {

	public bool isStart;
	public bool isQuit;

	void OnMouseUp(){
		if(isStart)
		{
			SceneManager.LoadScene (1);
		}
		if (isQuit)
		{
			Application.Quit();
		}
	} 
}
