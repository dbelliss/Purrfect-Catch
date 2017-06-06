using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	public GameObject player;
	static private int count;
	public float Speed;
	public Text countText;  
	public Text TimerText;
	public Text depthText;
	public Text deathText;
	public int depth;
	public float TimeLeft;
	public SpriteRenderer sprite;
	public AudioClip bite;
	public AudioClip damaged;
	private AudioSource audio;

	void Start()
	{
		depth = 40;
		depthText.text = "Depth: " + depth.ToString () + "m";
		TimerText.text = "";
		TimerText.text = "Seconds left:" + TimeLeft.ToString();

		countText.text = "";
		SetCountText ();
		audio = GetComponent<AudioSource> ();



	}

	void Update()
	{
		TimeLeft -= Time.deltaTime;
		TimerText.text = "Seconds Left:" + Mathf.Round(TimeLeft);
		if(TimeLeft < 10)
		{
			deathText.text = "Oh no! " + Mathf.Round(TimeLeft) + " seconds left!";
		}
		if (TimeLeft < 0) {
			count = 0;
			SceneManager.LoadScene (0);
		}

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 vector = new Vector3 (moveHorizontal * Speed, (moveVertical * Speed), 0);
		transform.Translate (vector, Space.World);

		if (moveHorizontal < 0) {
			
			sprite.flipX = true;
		}
		else 
			sprite.flipX = false;

		depth = (int)Mathf.Round(player.transform.position.y);
		depthText.text = "Depth: " + (depth-25).ToString () + "m";

		if (depth > 25)
		{
			count += 5;
			if (SceneManager.GetActiveScene ().buildIndex == 3) 
			{
				if (count < 200) {
					count = 0;
					SceneManager.LoadScene (4);
				}
				else if (count < 500) {
					count = 0;
					SceneManager.LoadScene (5);
				} else {
					count = 0;
					SceneManager.LoadScene (6);
				}
			}
			else
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		}

	}

	void FixedUpdate()
	{
		

	}










	void OnTriggerEnter2D(Collider2D other) 
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag("Fish"))
		{
			audio.PlayOneShot(bite, 0.2F);
			count+=10;
			other.gameObject.SetActive(false);
			SetCountText ();
		}

		if (other.gameObject.CompareTag("Shark"))
		{
		audio.PlayOneShot(damaged, 0.1F);
			TimeLeft -= 5;
			TimerText.text = "Seconds Left:" + Mathf.Round(TimeLeft);
		}
	}

	void SetCountText()
	{
		//Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.
		countText.text = "Score: " + count.ToString ();
	}

}
