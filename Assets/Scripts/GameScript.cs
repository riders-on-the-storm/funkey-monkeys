using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{

	public Camera Camera;
	public GameObject Player1;
	public GameObject Player2;
	public Grid MainGrid;
	
	
	// Use this for initialization
	void Start ()
	{
		Instantiate(Camera);
		Instantiate(Player1);
		if (Player2 != null)
		{
			Instantiate(Player2);
		}
		Instantiate(MainGrid);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
