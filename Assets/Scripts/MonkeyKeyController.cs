using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyKeyController : MonoBehaviour {
	private Animator animator;
	private float Force;
	private float MaxForce = 350;
	private float TimeStart;
	private float DeltaTime = 0;
	private float DeltaTimeMax = 1;
	private bool Accumulation = false;
	public GameObject crap;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetMouseButton(0))
		{
			if (!Accumulation)
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

		if ((Accumulation && !Input.GetMouseButton(0)) || (DeltaTime == DeltaTimeMax))
		{
			Force = (DeltaTime / DeltaTimeMax) * MaxForce;
			Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			pz.z = 0;
			Vector2 forceVector = (pz - this.transform.position);
			forceVector = pz / pz.magnitude;
			forceVector = forceVector * Force;
			
			animator.SetTrigger("KeyClick");
			GameObject go = Instantiate(crap) as GameObject;
			go.transform.position = this.transform.position;
			go.GetComponent<CrapScript>().StartForce = forceVector;
			
			Accumulation = false;
			DeltaTime = 0;
		}
	}

	void Update()
	{
		
	}

	void OnMouseDown()
	{
		Debug.Log("SomeLevel");
	}
}
