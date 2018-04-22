using System.Collections;
using System.Collections.Generic;
using System.IO;
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
	public Texture2D cursor;
	private CursorMode _CursorMode = CursorMode.Auto;
	public Vector2 HotSpot = Vector2.zero;

	private Slider Slider1, Slider2;
	// Use this for initialization
	void Start ()
	{
		Cursor.SetCursor(cursor, HotSpot, _CursorMode);
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
		Score1 = GameObject.Find ("Main Camera(Clone)/Canvas/Score1").GetComponent<Text>();
		Score2 = GameObject.Find ("Main Camera(Clone)/Canvas/Score2").GetComponent<Text>();
		Slider1 = GameObject.Find ("Main Camera(Clone)/Canvas/Slider1").GetComponent<Slider>();
		Slider2 = GameObject.Find ("Main Camera(Clone)/Canvas/Slider2").GetComponent<Slider>();
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

	public void ChangeForce(int PlayerId, float Force)
	{
		Debug.Log(Force);
		if (PlayerId == 1)
		{
			Slider1.value = Force;
		}
		else
		{
			Slider2.value = Force;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
