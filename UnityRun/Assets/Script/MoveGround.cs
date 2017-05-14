using UnityEngine;
using System.Collections;


/*Mainシーン使用
 * 地面を一定間隔ごとにズラす。
*/


public class MoveGround : MonoBehaviour {

    public GameObject Ground;   //地面に値するobject
    public GameObject Player;   //Playerに値するobject
    public GameObject Enemy1;    //enemy(障害物)に値するobject
    public GameObject Enemy2;    //enemy(障害物)に値するobject
    public float Destroy_Time = 5.0f;
    public int border = -40;           //地面をズラす起点となる値。
    public int enemyborder = 10;       //障害物を出現させる起点となる値。

    void Update()
    {
        if (TimeCount.StartFlag == true)
        {
            if (Player.transform.position.x > border)     //playerのx座標(Inspecterより確認できる)が border(上で宣言)より大きい場合
            {
                CreateGround(); //地面をズラす関数
            }

            if (Player.transform.position.x > enemyborder) //playerのx座標(Inspecterより確認できる)が enemyborder(上で宣言)より大きい場合
            {
                DestoroyEnemy();
                CreateEnemy(); //障害物を出す関数
            }
        }
    }

    /*Gameobject Ground に設定したobject をずらす処理*/
    void CreateGround()
    {
        border += 5; //上で宣言した起点
        Vector3 temp = new Vector3(border,0,0);  //(起点+5,0,0)の座標に出現
        Ground.transform.position = temp;        
    }

    /*Gameobject Enemy に設定したobject を出す処理*/
    void CreateEnemy()
    { 
         if (UnityEngine.Random.Range(0, 5) == 0)//ランダムに'0'～4までの'5' つを選出し、その値が0ならば障害物が出現する。1/5の確立
         {
            Instantiate(Enemy1, new Vector3(enemyborder + 20, 0.3f, -0.9f), Enemy1.transform.rotation); //(起点+20,1,1)の座標に出現
        
        }
        else if (UnityEngine.Random.Range(0, 6) == 1 )
        {
            Instantiate(Enemy2, new Vector3(enemyborder + 20,1.35f,-1.5f), Enemy2.transform.rotation); //(起点+20,1,1)の座標に出現
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
