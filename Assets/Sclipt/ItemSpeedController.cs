using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpeedController : MonoBehaviour
{
    //アイテムのオブジェクトを拾う
    public GameObject StarPrefab;
    public GameObject HighStarPrefab;
    public GameObject RainbowStarPrefab;
    public GameObject UpClockPrefab;
    public GameObject DownClockPrefab;
    StarController script; //StarControllerのスクリプトアイテムを動かしているスクリプト

    //スピードアップ用裏タイマー
    private float speedtimer = 0;

    //スピードアップの段階
    private int speedup = 0;

    // Start is called before the first frame update
    void Start()
    {
        StarPrefab = GameObject.Find ("StarPrefab");//StartManagerのオブジェクトを発見
        //StartManagerについてるGamestartManagerのスクリプトを使用。
        script = StarPrefab.GetComponent<StarController>();
    }

    // Update is called once per frame
    void Update()
    {
        speedtimer += Time.deltaTime;

        if(speedup ==0 && speedtimer >= 7)
        {
            Debug.Log("test");
            script.speed = -30; 
            speedup += 1;
        }
        
    }
}
