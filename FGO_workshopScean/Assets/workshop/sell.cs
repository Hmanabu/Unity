using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sell : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		//money = GameObject.Find ("money").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//変更するtext
	public Text stone;
	public Text money;
	//石の値段
	public int stone_price;
	//石の購入個数
	public int stone_num;

	//計算用変数
	private int sum_stone;
	private int moneyed;

	public void sell_stone (){
		int now_maney = int.Parse(money.text);
		int now_stone = int.Parse(stone.text);

		if (now_maney >= stone_price) {
			//現在個数+stone_num
			sum_stone = now_stone + stone_num;
			//textに表示
			stone.text = sum_stone.ToString ();

			moneyed = now_maney - stone_price;
			money.text = moneyed.ToString ();
		} else {
			Debug.Log("<color=red>お金ないよ(仮表示)</color>");
		}
	}
}
