using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
	public int Score;
	public int PlayerId;
	private GameScript Game;
	public void Start()
	{
		Game  = GameObject.Find("Game").GetComponent<GameScript>();
	}
	
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Crap(Clone)")
		{
			Game.AddScore(PlayerId, this.Score);
			Destroy(other.gameObject);
		}		
	}
}
