using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
	public GameObject[] background = new GameObject[2];
	public float speed;
	private int idx;
	private Vector3 interval;

    void Start()
    {
		idx = 0;
		interval.x = background[0].GetComponent<Renderer>().bounds.size.x - 0.0025f;
		background[0].transform.position = new Vector3(0, 0);
		background[1].transform.position = interval;
	}

    
    void Update()
    {
		foreach (var bg in background)
		{
			bg.transform.Translate(new Vector2(-speed, 0) * Time.deltaTime);
		}
		if(background[idx].transform.position.x <= 0)
		{
			//if (idx == 0) idx = 1;
			//else idx = 0;

			idx = idx == 0 ? 1 : 0;

			background[idx].transform.position = interval;
		}
    }
}
