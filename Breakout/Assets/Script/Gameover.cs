using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour {

	public AudioClip sound;
	public Animator animator;

	//OnCollisionEnter : アタッチしたObjectに衝突したら
	private void OnCollisionEnter( Collision collision )
	{
		
		AudioSource.PlayClipAtPoint( sound, transform.position );
		animator.SetTrigger ("BeemTriger");
	}
}
