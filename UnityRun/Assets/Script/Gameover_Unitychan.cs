using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*GameOverシーンの処理をまとめたものです。
音声(AudioClip)
文字表示(Text)
Unityちゃんの動き(Animation)
ランキングの表示(ranking_animation)
*/
public class Gameover_Unitychan : MonoBehaviour {

    public AudioClip Lose; //負け音声変数
    public AudioClip NewLecode;//勝利音声変数
    public Text Result_text; //Gameover or Newrecode を表示するText
    public string Gameover = "Gameover"; //今回の記録<最高記録の場合 表示させる文字
    public string Newrecode = "Newrecode";//最高記録 < 今回の記録の場合 表示させる文字
    public Animator ranking_animator; //ランキングのアニメーション

    private AudioSource audiosouse; //アタッチされているAudiosouce取得用変数                                
    private Animator Unity_animator; //PlayerにセットされているAnimater

    void Start() {

        Unity_animator = this.GetComponent<Animator>();  //Animator取得
        audiosouse = this.gameObject.GetComponent<AudioSource>();//Audio取得
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Gameover")
        {
            if ((int)TimeCount.Score < Ranking.highScore)//今回の記録(timeCount.time) < 最高記録(Ranking.highscore)
            {
                Unity_animator.SetTrigger("Lose_Trigger");//Torrigerセット
                audiosouse.clip = Lose;                   //AudioClipセット
                Result_text.text = Gameover.ToString();   //Textセット
            }
            else                                       //最高記録(Ranking.highscore) < 今回の記録(timeCount.time)
            {
                Unity_animator.SetTrigger("NewLecode_Trigger"); //Torrigerセット
                audiosouse.clip = NewLecode;                    //AudioClipセット
                Result_text.text = Newrecode.ToString();        //Textセット
            }
            ranking_animator.SetTrigger("Ranking_start");       //Rankingtriggerセット

        }
    }
}
