
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ranking : MonoBehaviour {

   // TimeCount Score;//今回のスコア(time)
    public Text scoreGUI;
    public Text highscoreGUI;
    private int score;
    public static int highScore; //GameOverunitychanでUnityちゃんの動きを決める処理に必要(将来的には動きが似ているため一つのソースにまとめたい)


    // Use this for initialization
    void Start () {
        score = 0;
        score = (int)TimeCount.Score; //scoreに今回のスコア(time)を入れる
        // キーを使って値を取得
        // キーがない場合は第二引数の値を取得
      //  highScore = PlayerPrefs.GetInt("highScoreKey", 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (highScore < score)
        {
            highScore = score;
        }

        scoreGUI.text = "記録" + score+"m";
        highscoreGUI.text = "最高記録" + highScore+"m";

        Save();
    }

    public void Save()
    {
        // メソッドが呼ばれたときのキーと値をセットする
        PlayerPrefs.SetInt("highScoreKey", highScore);
        // キーと値を保存
        PlayerPrefs.Save();
    }

    public void Reset() 
    {
        // キーを全て消す
        PlayerPrefs.DeleteAll();
    }
}
