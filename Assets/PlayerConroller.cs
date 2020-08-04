using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConroller : MonoBehaviour
{
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
    
    //制限時間のテキスト
    public Text timetext;
    //制限時間
    public float timer = 30.0f;

    //スコアのテキスト
    private GameObject scoretext;
    //スコアの点数
    private int scorept = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //アニメーターを取得
        this.animator = GetComponent<Animator>();
        //Rigidbodyを取得
        this.rigid2D = GetComponent<Rigidbody2D>();

        //スコアテキストの取得
        this.scoretext = GameObject.Find("Score");
        //スコアテキストの表示
        this.scoretext.GetComponent<Text>().text = "Score : " + scorept + " pt";

       
        
    }

    // Update is called once per frame
    void Update()
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
        if (Input.GetMouseButton (0) == false) 
            {
                if (this.rigid2D.velocity.y > 0) 
                {
                    this.rigid2D.velocity *= this.dump;
                }
            } 
        
        timer -= Time.deltaTime;
        timetext.text = "Time : " + timer.ToString("F2");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "StarTag")
        {
            scorept += 10;
            Destroy(other.gameObject);        
            this.scoretext.GetComponent<Text>().text = "Score : " + scorept + " pt";
        }
        if(other.gameObject.tag == "CrockTag")
        {
            timer += 5.0f;
            Destroy(other.gameObject);  
            timetext.text = "Time : " + timer.ToString("F2");      
           
        }
    }

}
