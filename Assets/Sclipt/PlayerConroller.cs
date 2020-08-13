using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConroller : MonoBehaviour
{
    //ItemGenerator
    public GameObject itemGenerator;
    //BGM
    public GameObject bgm;
    
    

    //効果音を入れる
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    //Audiosource
    AudioSource audiosource;
    //アニメーション
    Animator animator;
    
    //Playerを移動させるコンポーネント
    Rigidbody2D rigid2D;

    //地面の位置
	private float groundLevel = -3.5f;
    
    //ジャンプの速度の減衰
    private float dump = 0.5f;

    //ジャンプの速度
    float jumpVelocity = 20;

    //テキストの座布団UI
    public GameObject scorebackground;
    
    //制限時間のテキスト
    public Text timetext;
    //制限時間
    public float timer = 30.0f;
    
    //スコアのテキスト
    private GameObject scoretext;
    //スコアの点数
    private int scorept = 0;

    //終了時スコアのテキスト
    public Text finishscoretext;


    //ゲーム終了時のテキスト
    public Text finishtext;
    //ゲーム終了判定
    private bool isFinish = false;
    //ゲーム終了後演出用タイマー
    private float finishtimer = 5.0f;

    //finishBGM
    public GameObject finishbgm;
    //終了演出バック
    public GameObject finishbackground;
    //金メダル
    public GameObject gold;
    //銀メダル
    public GameObject silver;
    //銅メダル
    public GameObject bronze;
    //背景の画像（project上でキャラごとに変更する）
    public GameObject backimage;
    //タイトルに戻るボタン
    public GameObject titlebutton;
    //Retryボタン
    public GameObject retrybutton;


    
    // Start is called before the first frame update
    void Start()
    {
        //アニメーターを取得
        this.animator = GetComponent<Animator>();
        //Rigidbodyを取得
        this.rigid2D = GetComponent<Rigidbody2D>();
        //AudioSourceのコンポーネントを取得する
		this.audiosource = GetComponent<AudioSource>();

        //スコアテキストの取得
        this.scoretext = GameObject.Find("Score");
        //スコアテキストの表示
        this.scoretext.GetComponent<Text>().text = "Score : " + scorept + " pt";
        //スコアのバックUIを表示
        scorebackground.gameObject.SetActive(true);    
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFinish == false)
        {
            // 走るアニメーションを再生するために、Animatorのパラメータを調節する
            this.animator.SetFloat("Horizontal", 1);

            // 着地しているかどうかを調べる
            bool isGround = (transform.position.y > this.groundLevel) ? false : true;
            this.animator.SetBool ("isGround", isGround);

            // 着地状態でクリックされた場合（追加）
            if (Input.GetMouseButtonDown (0) && isGround) 
            {
                // 上方向の力をかける（追加）
                this.rigid2D.velocity = new Vector2 (0, this.jumpVelocity);
            }

            // クリックをやめたら上方向への速度を減速する（追加）
            if(Input.GetMouseButton (0) == false) 
            {
                if (this.rigid2D.velocity.y > 0) 
                {
                    this.rigid2D.velocity *= this.dump;
                }
            } 
        
            timer -= Time.deltaTime;
            timetext.text = "Time : " + timer.ToString("F2");
        
            if(timer <= 0)
            {
                isFinish = true;
                audiosource.PlayOneShot(sound2);
            }
        
        }
        else if(isFinish == true)
        {
            this.scoretext.GetComponent<Text>().text = "";
            timetext.text = "";
            finishtext.text = "Finish!";
            itemGenerator.gameObject.SetActive(false);
            bgm.gameObject.SetActive(false);
            scorebackground.gameObject.SetActive(false);    
            
            finishtimer -= Time.deltaTime;

            if(finishtimer <= 0)
            {
                finishtext.text = "";
                backimage.gameObject.SetActive(true);
                finishbgm.gameObject.SetActive(true);
                finishbackground.gameObject.SetActive(true);
                titlebutton.gameObject.SetActive(true);
                retrybutton.gameObject.SetActive(true);
                if(scorept >= 300)
                {
                    
                    finishscoretext.text = scorept + "pt";
                    gold.gameObject.SetActive(true);
                }
                else if(scorept >= 200)
                {
                    finishscoretext.text = scorept + "pt";
                    silver.gameObject.SetActive(true);
                }
                else if(scorept <= 100)
                {
                    finishscoretext.text = scorept + "pt";
                    bronze.gameObject.SetActive(true);
                }
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //星に当たった時
        if(other.gameObject.tag == "StarTag")
        {
        audiosource.PlayOneShot(sound1);
        scorept += 10;
        GetComponent<ParticleSystem>().Play();
        Destroy(other.gameObject);        
        this.scoretext.GetComponent<Text>().text = "Score : " + scorept + " pt";
        
        }
        if(other.gameObject.tag == "ClockTag")
        {
        audiosource.PlayOneShot(sound3);
        //時計を取ったら5秒プラス
        timer += 5.0f;
        timetext.text = "Time : " + timer.ToString("F2");       
        }
        if(other.gameObject.tag == "HighStarTag")
        {
        audiosource.PlayOneShot(sound2);
        //高い場所の星は20点
        scorept += 20;
        GetComponent<ParticleSystem>().Play();
        Destroy(other.gameObject);        
        this.scoretext.GetComponent<Text>().text = "Score : " + scorept + " pt";
        
        }
         if(other.gameObject.tag == "RainbowStarTag")
        {
        audiosource.PlayOneShot(sound2);
        //虹色の星は50点
        scorept += 50;
        GetComponent<ParticleSystem>().Play();
        Destroy(other.gameObject);        
        this.scoretext.GetComponent<Text>().text = "Score : " + scorept + " pt";
        
        }

    }
        

}
