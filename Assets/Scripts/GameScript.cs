using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{

	public Camera Camera;
	public GameObject Player1;
	public GameObject Player2;
	public Grid MainGrid;
	public List<GameObject> holes;
	public int Player1Score = 0;
	public int Player2Score = 0;
	
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
		foreach (GameObject hole in holes)
		{
			Instantiate(hole);	
		}
	}

	public void AddScore(int PlayerId, int score)
	{
		if (PlayerId == 1)
		{
			Player1Score += score;
		}
		else
		{
			Player2Score += score;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
