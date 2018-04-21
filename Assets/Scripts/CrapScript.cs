using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrapScript : MonoBehaviour
{

	public Vector3  StartForce = new Vector3(5, 2);
	private Rigidbody2D rb;
	// Use this for initialization
	void Start ()
	{
		rb = this.GetComponent<Rigidbody2D>();
		rb.AddForce(StartForce);
	}

	private void FixedUpdate()
	{
		
	}

	// Update is called once per frame
	void Update () {
//		
	}
}
