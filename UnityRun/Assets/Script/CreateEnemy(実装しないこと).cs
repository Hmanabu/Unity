using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour {

    public GameObject Player;   //Playerに値するobject
    public GameObject Enemy1;    //enemy(障害物)に値するobject
    public GameObject Enemy2;    //enemy(障害物)に値するobject

    public float Destroy_Time = 5.0f;
    public int enemyborder = 10;       //障害物を出現させる起点となる値。
    public float WaitTime=5;

    void Update()
    {

      if (Player.transform.position.x > enemyborder) //playerのx座標(Inspecterより確認できる)が enemyborder(上で宣言)より大きい場合
       {
            Invoke("Enemy", WaitTime); //障害物を出す関数
            DestoroyEnemy();
       }
    }

 /*Gameobject Enemy に設定したobject を出す処理*/
 void Enemy()
 { 
      if (UnityEngine.Random.Range(0, 5) == 0)//ランダムに'0'～4までの'5' つを選出し、その値が0ならば障害物が出現する。1/5の確立
      {
              Instantiate(Enemy1, new Vector3(enemyborder + 20, 0.3f, -0.9f), Enemy1.transform.rotation); //(起点+10,1,1)の座標に出現

     }
     else if (UnityEngine.Random.Range(0, 6) == 1 )
     {
             Instantiate(Enemy2, new Vector3(enemyborder + 20,1.35f,-1.5f), Enemy2.transform.rotation); //(起点+10,1,1)の座標に出現


     }
     enemyborder += 20; 
 }

 void DestoroyEnemy()//instanceと作成するタイミングを考えること。(毎回作成するのは非効率。Enemyが作成されたら、instanceを作成するように)
 {
     GameObject Enemy1_Ins = Instantiate(Enemy1);   //Enemy のInstansを作成しなければいけない。削除するため
     GameObject Enemy2_Ins = Instantiate(Enemy2);

     Destroy(Enemy1_Ins, Destroy_Time); //元となるobjectは削除してはダメ。instansを生成して、それを削除すること。
     Destroy(Enemy2_Ins, Destroy_Time);
 }

}
