using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbarEnemy : MonoBehaviour
{

	public Vector3 localScale;
	public GameObject enemy;

	// Use this for initialization
	void Start()
	{
		localScale = transform.localScale;
	}

	// Update is called once per frame
	void Update()
	{
		localScale.x = enemy.GetComponent<Enemy>().health;
		transform.localScale = localScale;
	}
}
