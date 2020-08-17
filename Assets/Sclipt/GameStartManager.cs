using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartManager : MonoBehaviour
{
    //itemGeneratorオブジェクト
    public GameObject itemgenerator;
    //BGMオブジェクト
    public GameObject bgm;
    //START演出用のテキスト
    public Text starttext;
    //スタート演出用タイマー
    public float starttimer = 5.0f;

    //キャラ選択の背景
    public GameObject background;
    //キャラ選択の画像テキスト
    public GameObject charaselectimage;

    //椅子のキャラのボタン
    public GameObject officemanbutton;
    //寿司のボタン
    public GameObject sushibutton;

    //キャラ判定0：誰も選んでない//１：officeman//2:寿司
    public int selected = 0;
    

    //椅子のキャラ
    public GameObject Officeman;
    //寿司
    public GameObject Sushi;

    // Start is called before the first frame update
    void Start()
    {       
        
    }

    // Update is called once per frame
    void Update()
    {
        if(selected == 1)
        {
            starttimer -= Time.deltaTime;
            if(starttimer <= 4)
            {
                starttext.text = starttimer.ToString();
                if(starttimer <= 1)
                {
                starttext.text = "";
                itemgenerator.gameObject.SetActive(true);
                //officemanplayerをON
                Officeman.gameObject.SetActive(true);
                bgm.gameObject.SetActive(true);
                }
            } 
        }
        else if(selected == 2)
        {
            starttimer -= Time.deltaTime;
            if(starttimer <= 4)
            {
                starttext.text = starttimer.ToString();
                if(starttimer <= 1)
                {
                starttext.text = "";
                itemgenerator.gameObject.SetActive(true);
                //sushiplayerをON
                Sushi.gameObject.SetActive(true);
                bgm.gameObject.SetActive(true);


                }
            } 
        }
        
        
    }
    public void OnOffice()
    {
        //椅子の人が選ばれた時
        selected = 1;
        //背景を消す
        background.gameObject.SetActive(false);
        //ボタンを消す
        sushibutton.gameObject.SetActive(false);
        officemanbutton.gameObject.SetActive(false);
        charaselectimage.gameObject.SetActive(false);

    }
    public void OnSushi()
    {
        //寿司が選ばれた時
        selected = 2;
        //背景を消す
        background.gameObject.SetActive(false);
        //ボタンを消す
        officemanbutton.gameObject.SetActive(false);
        sushibutton.gameObject.SetActive(false);
        charaselectimage.gameObject.SetActive(false);
    }
}
