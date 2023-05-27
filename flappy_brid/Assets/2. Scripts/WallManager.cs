using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{

	public GameObject wall;
	public float createInterval;
	public GameObject spawnPos;

	public GameObject pool;
	[Range(1,5)]
	public float randY;


    void Start()
    {
		StartCoroutine(WallCor(createInterval));
    }


	private IEnumerator WallCor(float t)
	{
		while (true)
		{
			yield return new WaitForSeconds(t);
			CreateWall();
		}
	}


	void CreateWall()
	{
		for (int i = 0; i < pool.transform.childCount; i++)
		{
			if(pool.transform.GetChild(i).gameObject.activeSelf == false)
			{
				pool.transform.GetChild(i).gameObject.SetActive(true);
				pool.transform.GetChild(i).position = new Vector2(spawnPos.transform.position.x, Random.Range(-randY, randY));
				return;
			}
		}

		GameObject temp = Instantiate(wall);
		temp.transform.parent = pool.transform;
		temp.transform.localPosition = new Vector2(spawnPos.transform.position.x, Random.Range(-3, 3));
	}
}
