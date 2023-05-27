using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCont : MonoBehaviour
{

	public float speed;
	private Vector2 moveDir;

    void Start()
    {
		moveDir = new Vector2(-speed, 0);
    }

    
    void Update()
    {
		transform.Translate(moveDir * Time.deltaTime);

		if(transform.position.x < -5)
		{
			transform.position = Vector2.zero;
			gameObject.SetActive(false);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("DESPAWNER"))
			gameObject.SetActive(false);
	}
}
