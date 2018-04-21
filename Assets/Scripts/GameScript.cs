using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{

	public Camera Camera;
	public GameObject Player1;
	public GameObject Player2;
	public Grid MainGrid;
	public List<GameObject> holes;
	public int Player1Score = 0;
	public int Player2Score = 0;
	private Text Score1, Score2;
	
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
		 Score1 = GameObject.Find ("Canvas/Score1").GetComponent<UnityEngine.UI.Text>();
		 Score2 = GameObject.Find ("Canvas/Score2").GetComponent<UnityEngine.UI.Text>();
	}

	public void AddScore(int PlayerId, int score)
	{
		if (PlayerId == 1)
		{
			Player1Score += score;
			Score1.text = Player1Score.ToString();
		}
		else
		{
			Player2Score += score;
			Score2.text = Player2Score.ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
