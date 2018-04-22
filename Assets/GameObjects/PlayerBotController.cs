using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerBotController : MonoBehaviour {

		private Animator animator;
	private float Force;
	private float MaxForce = 400;
	private float TimeStart;
	private float TimeStop;
	private float TimePause = 1;
	private float DeltaTime = 0;
	private float DeltaTimeMax = 1;
	private bool Accumulation = false;
	private GameScript Game;
	public GameObject crap;
	public int Health = 6;
	public int PlayerId;
	private Vector2 moveTo;

	private Rigidbody2D mybody;
	public float speed;
	public float jumpPower;
	public bool isJumping = false;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		Game  = GameObject.Find("Game").GetComponent<GameScript>();
		mybody = GetComponent<Rigidbody2D>();
		moveTo = this.transform.position;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Health > 0)
		{
			bool isFire = Random.value > 0.1 || Force < MaxForce * 0.8f;
			Force = (DeltaTime / DeltaTimeMax) * MaxForce;
			if (isFire)
			{
				if (!Accumulation && (Time.time - TimeStop > TimePause))
				{
					TimeStart = Time.time;
					Accumulation = true;
				}

				if (Accumulation)
				{
					DeltaTime = Time.time - TimeStart;
					if (DeltaTime > DeltaTimeMax)
					{
						DeltaTime = DeltaTimeMax;
					}
				}
			}
			Force = (DeltaTime / DeltaTimeMax) * MaxForce;
			float NormalizedForce = Force * 1f / MaxForce;
			Game.ChangeForce(PlayerId, NormalizedForce);

			if ((Accumulation && !isFire) || (DeltaTime == DeltaTimeMax))
			{
//			Vector3 pz = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(0);
//			pz.z = 0;
				float value = Random.value;
				Vector2 forceVector = new Vector2(-transform.position.x * (1/value), 10);
				forceVector = forceVector.normalized;
				forceVector = forceVector * Force;
				Debug.Log(forceVector);

				animator.SetTrigger("KeyClick");
				Vector3 crapPos = this.transform.position;
				crapPos.y += 0.1F;
				if (forceVector.x < 0)
				{
					crapPos.x -= 0.2F;
				}
				else
				{
					crapPos.x += 0.2F;
				}
				GameObject go = Instantiate(crap) as GameObject;
				go.transform.position = crapPos;
				go.GetComponent<CrapScript>().StartForce = forceVector;

				Accumulation = false;
				DeltaTime = 0;
				TimeStop = Time.time;
			}
		}
		Debug.Log(moveTo);
		if (Math.Abs(transform.position.x - moveTo.x) > 0.5)
		{
			Vector2 move = new Vector2(moveTo.x - transform.position.x, 0);
			move = move.normalized;
			move.y = -0.5f;
			mybody.velocity = move* speed;
		}
		
		GameObject[] craps = GameObject.FindGameObjectsWithTag("Crap");
		float distance = 10000;
		GameObject nearesCrap = null;
		foreach (GameObject crap in craps)
		{
			if ((crap.transform.position - this.transform.position).magnitude < distance && crap.GetComponent<Rigidbody2D>().velocity.x >= 0)
			{
				distance = (crap.transform.position - this.transform.position).magnitude;
				nearesCrap = crap;
			}
		}
		if (nearesCrap != null && distance < 3)
		{
			Vector2 move = nearesCrap.transform.position - this.transform.position;
			move = move.normalized;
			moveTo =  new Vector2((-move.x) * speed, 0);
		}
		else
		{
			moveTo =  new Vector2(1, 0);
		}
	}
	
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Crap(Clone)")
		{
			Destroy(other.gameObject);
			animator.SetTrigger("TouchCrap");
			this.Health--;
			if (this.Health < 1)
			{
				Game.GameOver(true);
				Destroy(GetComponent< Rigidbody2D > ());
			}
		}

		if (other.gameObject.tag == "Ground")
		{
			isJumping = false;
		}
	}
}
