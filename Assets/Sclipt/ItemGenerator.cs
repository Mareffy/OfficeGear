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
    private float speedup = 10.0f;

    //スピードアップの段階
    private int speedlevel = 0;


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
        //speedtimer１０秒経過毎に少しずつアイテムのスピードレベルをアップ@
        if(this.speedtimer > this.speedup)
        {
            //Speedのレベルを１あげる
            speedlevel += 1;
            //speedtimerをリセット@
            this.speedtimer = 0f;
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
                    //スピードレベルが上がる毎に
                    if(speedlevel == 1)
                    {
                        //生成したオブジェクトを拾って-5スピードアップ
                        star.GetComponent<StarController>().speed = -15;
                    }
                    else if(speedlevel == 2)
                    {
                        star.GetComponent<StarController>().speed = -20;
                    }
                    else if(speedlevel == 3)
                    {
                        
                        star.GetComponent<StarController>().speed = -25;
                    }
                    else if(speedlevel == 4)
                    {
                        
                        star.GetComponent<StarController>().speed = -30;
                    }
                }
                          
            }
            else if(5 <= item && item <= 7)
            {
                for(int i =0; i < 1; i++)
                {
                    //Highstarを生成
                    GameObject highstar= Instantiate(highstarPrefab)as GameObject; 
                    //スピードレベルが上がる毎に
                    if(speedlevel == 1)
                    {
                        //生成したオブジェクトを拾って-5スピードアップ
                        highstar.GetComponent<StarController>().speed = -15;
                    }
                    else if(speedlevel == 2)
                    {
                        highstar.GetComponent<StarController>().speed = -20;
                    }
                    else if(speedlevel == 3)
                    {
                        
                        highstar.GetComponent<StarController>().speed = -25;
                    }
                    else if(speedlevel == 4)
                    {
                        
                        highstar.GetComponent<StarController>().speed = -30;
                    }
                }
            }
            else if(8 <= item && item <= 9)
            {
                for(int i =0; i < 1; i++)
                {
                    //Clockを生成
                    GameObject Clock = Instantiate(clockPrefab)as GameObject;
                    //スピードレベルが上がる毎に
                    if(speedlevel == 1)
                    {
                        //生成したオブジェクトを拾って-5スピードアップ
                        Clock.GetComponent<StarController>().speed = -15;
                    }
                    else if(speedlevel == 2)
                    {
                        
                        Clock.GetComponent<StarController>().speed = -20;
                    }
                    else if(speedlevel == 3)
                    {
                        Clock.GetComponent<StarController>().speed = -25;
                    }
                    else if(speedlevel == 4)
                    {
                        Clock.GetComponent<StarController>().speed = -30;
                    }
                }
            }
            else if(10 <= item && item <= 11)
            {
                for(int i =0; i < 1; i++)
                {
                    //Rainbowstarを生成
                    GameObject rainbowstar= Instantiate(rainbowstarPrefab)as GameObject;
                    if(speedlevel == 1)
                    {
                        //生成したオブジェクトを拾って-5スピードアップ
                        rainbowstar.GetComponent<StarController>().speed = -15;
                    }
                    else if(speedlevel == 2)
                    {
                        rainbowstar.GetComponent<StarController>().speed = -20;
                    }
                    else if(speedlevel == 3)
                    {
                        rainbowstar.GetComponent<StarController>().speed = -25;
                    }
                    else if(speedlevel == 4)
                    {
                        rainbowstar.GetComponent<StarController>().speed = -30;
                    }
                }
            }
            else if(12 <= item && item <= 14)
            {
                for(int i =0; i < 1; i++)
                {
                    //DownClockを生成
                    GameObject DownClock = Instantiate(downclockPrefab)as GameObject;
                    if(speedlevel == 1)
                    {
                        //生成したオブジェクトを拾って-5スピードアップ
                        DownClock.GetComponent<StarController>().speed = -15;
                    }
                    else if(speedlevel == 2)
                    {
                        DownClock.GetComponent<StarController>().speed = -20;
                    }
                    else if(speedlevel == 3)
                    {
                        DownClock.GetComponent<StarController>().speed = -25;
                    }
                    else if(speedlevel == 4)
                    {
                        DownClock.GetComponent<StarController>().speed = -30;
                    }
                }
            }
            
            //次のアイテムまでの生成時間
            this.span = this.offsetX + this.spaceX * 2;
            this.delta = 0f;

            

        }
        


        
    }
}
