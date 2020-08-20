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
    //DownClockPrefabを入れる
	public GameObject downclockPrefab;
    //RainbowStarPrefabを入れる
    public GameObject rainbowstarPrefab;

    StarController script; //アイテムを動かしているスクリプトを拾う

    //スピードアップ用裏タイマー
    private float speedtimer = 0;

    //スピードアップの間隔@
    private float speedup = 5.0f;


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
        script = starPrefab.GetComponent<StarController>();
        script = highstarPrefab.GetComponent<StarController>();
        script = clockPrefab.GetComponent<StarController>();
        script = rainbowstarPrefab.GetComponent<StarController>();
        script = downclockPrefab.GetComponent<StarController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        this.speedtimer += Time.deltaTime;
        //speedtimer１０秒経過毎に少しずつアイテムのスピードアップ@
        if(this.speedtimer > this.speedup)
        {
            //speedtimerをリセット@
            this.speedtimer = 0f;
            Debug.Log("test");
            script.speed -= 10.0f;
        }
        
        //span秒以上の時間が経過したかを調べる
		if(this.delta > this.span)
        {
            //2秒毎にStarかClockをランダムで生成
			int item = Random.Range(1,14);
            if(1 <= item && item <= 4)
            {
                for(int i =0; i < 1; i++)
                {
                    //Starを生成
                    GameObject star = Instantiate(starPrefab)as GameObject;
                         
                }
                          
            }
            else if(5 <= item && item <= 7)
            {
                for(int i =0; i < 1; i++)
                {
                //Highstarを生成
                GameObject highstar= Instantiate(highstarPrefab)as GameObject;
                
                }
            }
            else if(8 <= item && item <= 9)
            {
                for(int i =0; i < 1; i++)
                {
                //Clockを生成
                GameObject Clock = Instantiate(clockPrefab)as GameObject;
                
                }
            }
            else if(10 <= item && item <= 11)
            {
                for(int i =0; i < 1; i++)
                {
                //Rainbowstarを生成
                GameObject rainbowstar= Instantiate(rainbowstarPrefab)as GameObject;
                
                }
            }
            else if(12 <= item && item <= 14)
            {
                for(int i =0; i < 1; i++)
                {
                //DownClockを生成
                GameObject DownClock = Instantiate(downclockPrefab)as GameObject;
                
                }
            }
            
            //次のアイテムまでの生成時間
            this.span = this.offsetX + this.spaceX * 2;
            this.delta = 0f;

            

        }


        
    }
}
