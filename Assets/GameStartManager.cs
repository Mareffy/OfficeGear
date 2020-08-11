using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartManager : MonoBehaviour
{
    //itemGeneratorオブジェクト
    public GameObject itemgenerator;
    //playerオブジェクト
    public GameObject player;
    //BGMオブジェクト
    public GameObject bgm;
    //START演出用のテキスト
    public Text starttext;
    //スタート演出用タイマー
    public float starttimer = 5.0f;

    // Start is called before the first frame update
    void Start()
    {       
        
    }

    // Update is called once per frame
    void Update()
    {
        starttimer -= Time.deltaTime;
        if(starttimer <= 4)
        {
            starttext.text = starttimer.ToString();
            if(starttimer <= 1)
            {
            starttext.text = "";
            itemgenerator.gameObject.SetActive(true);
            player.gameObject.SetActive(true);
            bgm.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
            }
        } 
        
    }
}
