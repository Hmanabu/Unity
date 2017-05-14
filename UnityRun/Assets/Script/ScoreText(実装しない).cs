using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreText : MonoBehaviour {

    public Text text;
   // TimeCount time;//TimeCount time変数(走行距離)

    public void Start () {
        text = this.GetComponent<Text>();
        int time = (int)TimeCount.Score;
        text.text =time.ToString();
       // Score();
    }

	// Update is called once per frame
/*	public void Score () {
            text.text = TimeCount.time.ToString();

    }*/
}
