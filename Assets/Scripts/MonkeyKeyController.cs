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

	private Rigidbody2D mybody;
	public float speed;
	public float jumpPower;
	public bool isJumping = false;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		Game  = GameObject.Find("Game").GetComponent<GameScript>();
		mybody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetButton("Fire1"))
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

		if ((Accumulation && !Input.GetButton("Fire1")) || (DeltaTime == DeltaTimeMax))
		{
			Vector3 pz = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(0);
			pz.z = 0;
			Vector2 forceVector = (pz - this.transform.position);
			forceVector = forceVector.normalized;
			forceVector = forceVector * Force;
			
			animator.SetTrigger("KeyClick");
			Vector3 crapPos = this.transform.position;
			crapPos.y += 0.1F;
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
		}

		if (other.gameObject.tag == "Ground")
		{
			isJumping = false;
		}
	}

	void Update()
	{
		float move = Input.GetAxis("Horizontal");
		mybody.velocity = new Vector2(move * speed, mybody.velocity.y);

		if (Input.GetKey("w") && !isJumping)
		{
			mybody.velocity = new Vector2(mybody.velocity.x, jumpPower);
			isJumping = true;
		}
	}
}
