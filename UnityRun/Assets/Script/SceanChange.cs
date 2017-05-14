using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  //SceanManagerを使用する際に宣言すること。

/*Title Main Gameoverシーンで使用
 * 各シーンでの画面遷移処理*/

public class SceanChange : MonoBehaviour {
    
    /*メイン画面へ遷移する*/
    public void Move_Main()
    {
        if (Input.GetMouseButtonDown(0))   //panrl(画面)タッチ判定
        {
            SceneManager.LoadScene("Main");
        }
    }

    /*Title画面遷移*/
    public void Move_Title()
    {
        //  Application.LoadLevel("Title"); //Titleシーンに遷移
        StartCoroutine("GameoverTap");//コールルーチンは←で呼ぶらしい 
    }


    /*GameOver画面に遷移*/
    private void OnCollisionEnter(Collision collision) 
    {

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy2") //Enemy1,2に衝突した場合
        {
            SceneManager.LoadScene("Gameover");

        }
    }


    IEnumerator GameoverTap() //コールルーチンを使用 指定秒数後に処理をしたいため
    {
        if (Input.GetMouseButtonDown(0))    //panrl(画面)タッチ判定
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("Title");//titleへ遷移
        }
    }
}
