using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour {

	public void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(other.gameObject);
	}
}
