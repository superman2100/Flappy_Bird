using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{

	public int score;
	[Range(1f, 10f)]
	public float jumpPow;
	public bool isDead = false;
	private Rigidbody2D rb2d;
	public float initialRot;		
	private float zRot;		        
	public float rotSpeed;

	public GameObject origin;
	public GameObject moveto;

	void Start()
    {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
		if (!isDead)
		{
			PlayerMove();
		}
    }

	private void PlayerMove()
	{
		transform.eulerAngles = new Vector3(0f, 0f, zRot);
		zRot -= rotSpeed * Time.deltaTime;
		if (GameManager.instance.isStart && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)))
		{
			zRot = initialRot;
			rb2d.velocity = Vector2.zero;
			rb2d.AddForce(Vector2.up * jumpPow, ForceMode2D.Impulse);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.CompareTag("SCORE") && !isDead)
			score++;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("WALL"))
			isDead = true;
	}

	public void OnGameStart()
	{
		StartCoroutine(MovePlayerCor(1.5f));
	}

	private IEnumerator MovePlayerCor(float time)
	{
		float dt = 0;
		while(true)
		{
			dt += Time.deltaTime;
			transform.position = Vector2.Lerp(origin.transform.position, moveto.transform.position, dt / time);
			rb2d.velocity = Vector2.zero;
			zRot = 0;
			if (dt > time)
				break;
			yield return null;
		}
	}
}
