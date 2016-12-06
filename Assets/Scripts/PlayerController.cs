using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public Text ghostText;

	private Rigidbody rb;
	private int count;
	private int ghost;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		ghost = 0;
		SetCountText ();
		winText.text = "";
		ghostText.text = "";
	}
	
	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f,moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}

		else if (other.gameObject.CompareTag ("Ghost")) {
			other.gameObject.SetActive (false);
			count = count -1;
			ghost = ghost + 1;
			SetCountText ();
		}
	}

	void SetCountText()
	{
		countText.text = "Count:" + count.ToString ();
		ghostText.text = "Ghost:" + ghost.ToString ();
		if (count >= 4) {
			winText.text = "You Win!";
		} 
		else if(ghost>=1)	
		{
			winText.text = "You Lose!";
		}	
			
	}

}
