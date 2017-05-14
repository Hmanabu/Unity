using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
/*Mainシーン使用
 *Unityちゃんの動き制御
 * フリック判定
 */
public class UnityRun: MonoBehaviour {

	private Animator animator;

    public GameObject Player;   //Playerに値するobject

    public AudioClip countdown;
    public AudioClip RunBGM;

    public AudioSource audiosouce;
    private Vector3 touchStartPos; //タッチ検知開始位置
    private Vector3 touchEndPos;   //タッチ検知終了位置
    private int direction;

    bool audio=false;


    void Start () {
        animator = GetComponent<Animator> ();
        audiosouce.PlayOneShot(countdown);
        audio = true;
    }
		
	void Update () {

        if (TimeCount.StartFlag == true)
        {
            animator.SetTrigger("Start");
            audioplay();
            Run();
            Flic();
        }
    }


    public void UnitychanMotion()
    {
        switch (direction)
        {
            case 0: animator.SetTrigger("Run");break;   //→フリック
            case 1: animator.SetTrigger("Run");break;   //←フリック
            case 2: animator.SetTrigger("Jump");break;  //↑フリック
            case 3: animator.SetTrigger("Slide"); break;//↓フリック
            case 4: animator.SetTrigger("Run"); break;  //Tap判定
            case 5: animator.SetTrigger("Run"); break;  //Long Tap判定
            default: animator.SetTrigger("Run"); break; //それ以外は走る
        }
    }
    void Run()
    {
        animator.SetTrigger("Run");
        transform.position += transform.forward * 0.1f;
    }

    void Flic()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //  isFlick = true;
            touchStartPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);//タッチ開始
        }

/*        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        }*/

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);//タッチ終了位置検出

            float directionx = touchEndPos.x - touchStartPos.x;
            float directiony = touchEndPos.y - touchStartPos.y;


            if (Mathf.Abs(directiony) < Mathf.Abs(directionx)) // Y(縦フリックの変化量) < X(横のフリックの変化量)
            {
                if (0 < directionx)
                {
                    direction = 0;//Flick : Right
                }
                else
                {
                    direction = 1;//Flick : Left
                }
            }
            else if (Mathf.Abs(directionx) < Mathf.Abs(directiony))// X(横のフリックの変化量) < Y(縦フリックの変化量)
            {
                if (0 < directionx)
                {
                    direction = 2;//Flick Up
                    animator.SetTrigger("Jump");//toriggerセット
                }
                else
                {
                    direction = 3;//Flick Down
                    animator.SetTrigger("Slide");//torrigerセット
                }
            }
            else
            {
                direction = 4; // Tap
            }
        }
        else
        {
            direction = 5;//Long Tap
        }
        UnitychanMotion();
    }

    void audioplay()
    {

        if (audio == true)
        {
            audiosouce.PlayOneShot(RunBGM);
            audio = false;
        }
    }

}