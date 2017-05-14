using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//

/*Mainシーン使用
 * 画面上部に経過秒数を表示する処理(ゲームは進んだ距離を競うものにする(迫真))*/
public class TimeCount : MonoBehaviour {

    public  static float Score;//ScoreText.cs,Ranking.cs で使用
    public Text scoretext; //画面上部の走行距離表示Text
    public Text counttext; //画面上部の走行距離表示Text

    public float count;
    public static bool StartFlag = false;

    void Awake()
    {
        Score = 0;
        count = 4;
        counttext.gameObject.SetActive(true);
        TimeCount.StartFlag = false; //flagをfaiseにする
        // GetComponent<Text>().text = ((int)Score).ToString();
    }

    public void Update()
    {
       // audiosouce.clip = CountAudio;
        if (StartFlag == true)
        {
            timecount();
        }
        else
        {
            countdown();
        }
    }

    void timecount()
    {
      Score += Time.deltaTime;        //1秒に1ずつ減らしていく
      if (Score < 0) Score = 0;        //マイナスは表示しない
      scoretext.text = ((int)Score).ToString() + "m";
    }

    void countdown()
    {
        if (count < 1.0f)
        {
            StartFlag = true;
            counttext.gameObject.SetActive(false);
        }
        counttext.text = count.ToString();
        count -= Time.deltaTime;
    }
}
