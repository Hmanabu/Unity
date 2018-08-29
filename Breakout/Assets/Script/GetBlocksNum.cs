using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GetBlocksNum : MonoBehaviour {

	void Start () {
		SetupBlockCount ();
	}

	public GameObject Boll;
	void Update (){
		GetBlockCount ();

		//クリア条件

		//	if(NowBlockCount == AllBlockCount){
		//↓Debug用
		if (NowBlockCount == 5) {
			clear();
		}
	}

	private int AllBlockCount;
	public Text AllBlockNum;

	GameObject Block01obj;
	void SetupBlockCount() {
		//Blockの数をカウントしておく
		//Blocktagの参照の数を取得している。length = 参照の数
		AllBlockCount = GameObject.FindGameObjectsWithTag ("Block").Length;
		AllBlockNum.text = AllBlockCount.ToString();

		Block01obj = GameObject.Find ("Block_1");
	}

	//updateの度にtagを集計するのでは処理が重いと思う
/*	private int NowBlockCount;
	public Text NowBlockNum;
	void GetBlockCount(){
		//現在のBlock数を計算
		NowBlockCount = GameObject.FindGameObjectsWithTag ("Block").Length;
		NowBlockNum.text = (AllBlockCount - NowBlockCount).ToString ();
	}
*/
	public Text NowBlockNum; 
	private int NowBlockCount;
	void GetBlockCount(){
		NowBlockCount = BlockController.DestroyBlockNum;
		NowBlockNum.text = NowBlockCount.ToString();
	}

	void clear (){
		Destroy (Boll);
		//クリア文字 or クリアPanel 表示
	}
}
