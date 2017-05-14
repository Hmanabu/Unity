using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
/*Mainシーン使用
 *Unityちゃんの動き制御
 * フリック判定
 */
public class UnityRun: MonoBehaviour {

	private Animator animator;
   // private bool isFlick; //フリックFlag
    public GameObject Player;   //Playerに値するobject

    public AudioClip countdown;
    public AudioClip RunBGM;

    public AudioSource audiosouce;
    private Vector3 touchStartPos; //タッチ検知開始位置
    private Vector3 touchEndPos;   //タッチ検知終了位置
    private int direction;

    bool audio=false;


   IEnumerator Start() {
        enabled = false;
        audio = false;
        animator = GetComponent<Animator> ();
        audiosouce.PlayOneShot(countdown);
        yield return new WaitForSeconds(1);
        enabled = true;
        //    audiosouce = this.gameObject.GetComponent<AudioSource>();//Audio取得

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
  /*  public void Flickoff()
    {

        direction = 5;
        isFlick = false;
    }
     
   /* public bool IsFlick()  isflickの状態を確認する関数は不要と判断
    {
        return isFlick;
    }*/

   /* public void Clickon()
    {
        isClick = true;
        Invoke("Clickoff", 0.2f);
    }


    public void Clickoff()
    {

        isClick = false;
    }
    */

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
            default: animator.SetTrigger("Run"); break; //それ以外は走れ!!!!
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

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            /*if (touchStartPos != touchEndPos) クリック判定(今回は使用しない)
            {
                Clickoff();
            }*/
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);//タッチ終了位置検出
                                                                                                           //Debug.Log(touchEndPos);

            // if (isFlick)
            // {
            // Debug.Log("Flick");
            float directionx = touchEndPos.x - touchStartPos.x;
            float directiony = touchEndPos.y - touchStartPos.y;

            //Debug.Log("Directionx :" + directionx);
            //Debug.Log("Directiony :" + directiony);

            //Mathf.Abs(マイナスの符号を取って正の値を返す)　-1 → 1
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
                //Flickoff();//Tap判定
                direction = 4; // Tap
            }
        }
        else
        {
            direction = 5;//Long Tap
        }
        UnitychanMotion();
        //}
    }

    void audioplay()
    {

        if (audio == true)
        {
            audiosouce.PlayOneShot(RunBGM);
            audio = false;
        }
    }




















    /*	void OnTriggerEnter (Collider other)
        {
            if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.Jump")) {
                return;
            }

            if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.Slide") && other.name == "ObjectToll") {
                return;
            }

            if (other.name  == "Object" ||other.name  == "ObjectToll") {
                animator.SetTrigger ("Dead");
                Application.LoadLevel ("Gameover");
            }
        }*/
}