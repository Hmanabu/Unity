using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlaySound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public AudioClip sound;

	private void OnCollisionEnter( Collision collision )
	{
		
		AudioSource.PlayClipAtPoint( sound, transform.position );
	}
}
