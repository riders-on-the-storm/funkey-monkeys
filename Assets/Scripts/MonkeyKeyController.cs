using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyKeyController : MonoBehaviour {
	private Animator animator;
	private float Force;
	private float MaxForce = 200;
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
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		Game  = GameObject.Find("Game").GetComponent<GameScript>();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetMouseButton(0))
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
		if ((Accumulation && !Input.GetMouseButton(0)) || (DeltaTime == DeltaTimeMax))
		{
			Vector3 pz = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(0);
			pz.z = 0;
			Vector2 forceVector = (pz - this.transform.position);
			forceVector = forceVector * Force;
			
			animator.SetTrigger("KeyClick");
			Vector3 crapPos = this.transform.position;
			if (this.transform.position.x > pz.x)
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

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Crap(Clone)")
		{
			animator.SetTrigger("TouchCrap");
			this.Health--;
			if (this.Health < 1)
			{
				animator.SetTrigger("Death");
				Destroy(GetComponent< Rigidbody2D > ());
			}
			Debug.Log(this.Health);
		}
	}

	void Update()
	{
		if (Input.GetKey("a"))
		{
			GetComponent< Rigidbody2D > ().velocity = new Vector3(-1, 0, 0);
		}

		if (Input.GetKey("d"))
		{
			GetComponent< Rigidbody2D > ().velocity = new Vector3(1, 0, 0);
		}
	}
}
