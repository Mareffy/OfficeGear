using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StarController : MonoBehaviour
{
    //Starの移動速度
    private float speed = -10;

    //消滅位置
    private float deadLine = -8;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Starを移動させる
        transform.Translate(this.speed * Time.deltaTime,0,0);

        //画面外に出たら破棄
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
        
    }
}
