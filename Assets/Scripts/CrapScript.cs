﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrapScript : MonoBehaviour
{

	public Vector3  StartForce;
	private Rigidbody2D rb;
	private float TimeStart;
	// Use this for initialization
	void Start ()
	{
		rb = this.GetComponent<Rigidbody2D>();
		rb.AddForce(StartForce);
		Destroy(gameObject, 2);
	}

	// Update is called once per frame
	void Update () {
//		
	}
}
