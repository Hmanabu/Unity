using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BollController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		//以下を追加
		rb = this.GetComponent<Rigidbody>();
		rb.AddForce ((transform.forward + transform.right) * speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

/*	private void OnCollisionEnter( Collision collision )
	{
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.AddForce ((transform.forward + transform.right) * speed);
	}*/
}
