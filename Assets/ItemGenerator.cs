using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //SterPrefabを入れる
	public GameObject starPrefab;
	//CrockPrefabを入れる
	public GameObject crockPrefab;

    //時間計測用の変数
	private float delta = 0;

    //アイテムの生成間隔
	private float span = 2.0f;




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
            if(1 <= item && item <= 6)
            {
                for(int i =0; i < 1; i++)
                {
                    //Starを生成
                    GameObject star = Instantiate(starPrefab)as GameObject;
                         
                }
                          
            }
            else if(7 <= item && item <= 11)
            {
                for(int i =0; i < 1; i++)
                {
                //Crockを生成
                GameObject Crock = Instantiate(crockPrefab)as GameObject;
                
                }
            }
            //次のアイテムまでの生成時間
            this.span = this.offsetX + this.spaceX * 2;

        }


        
    }
}
