using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //SterPrefabを入れる
	public GameObject starPrefab;
    //HighSterPrefabを入れる
    public GameObject highstarPrefab;
	//ClockPrefabを入れる
	public GameObject clockPrefab;

    //時間計測用の変数
	private float delta = 0;

    //アイテムの生成間隔
	private float span = 3.0f;


    //アイテムの生成位置オフセット
    private float offsetX = 0.5f;    
    //アイテムの横方向の間隔
    private float spaceX = 0.4f;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        //span秒以上の時間が経過したかを調べる
		if(this.delta > this.span)
        {
            //2秒毎にStarかCrockをランダムで生成
			int item = Random.Range(1,11);
            if(1 <= item && item <= 4)
            {
                for(int i =0; i < 1; i++)
                {
                    //Starを生成
                    GameObject star = Instantiate(starPrefab)as GameObject;
                         
                }
                          
            }
            else if(5 <= item && item <= 8)
            {
                for(int i =0; i < 1; i++)
                {
                //Highstarを生成
                GameObject highstar= Instantiate(highstarPrefab)as GameObject;
                
                }
            }
            else if(9 <= item && item <= 11)
            {
                for(int i =0; i < 1; i++)
                {
                //Clockを生成
                GameObject Clock = Instantiate(clockPrefab)as GameObject;
                
                }
            }
            //次のアイテムまでの生成時間
            this.span = this.offsetX + this.spaceX * 2;
            this.delta = 0f;

        }


        
    }
}
