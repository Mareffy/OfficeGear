using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public GameObject Officemanplayer;
    public GameObject Sushiplayer;
    public GameObject Shachoplayer;

    public GameObject Startmanager;//StartManagerのオブジェクト
    GameStartManager script; //StartManagerのスクリプト

    PlayerController p_script;//PlayerControllerのスクリプト

    //officemanカメラ
    public GameObject Camerachain_o;
    //寿司カメラ
    public GameObject Camerachain_s;
    //社長カメラ
    public GameObject Camerachain_sh;

    //ゲーム終了判定
    private bool gamefinish = false;

    // Start is called before the first frame update
    void Start()
    {
        Startmanager = GameObject.Find ("StartManager");//StartManagerのオブジェクトを発見
        //StartManagerについてるGamestartManagerのスクリプトを使用。
        script = Startmanager.GetComponent<GameStartManager>(); 

        Officemanplayer = GameObject.Find ("PlayerOfficeman");
        Sushiplayer = GameObject.Find ("PlayerSushi");
        Shachoplayer = GameObject.Find ("PlayerShachou");
        p_script = Startmanager.GetComponent<PlayerController>(); 
        
    }

    // Update is called once per frame
    void Update()
    {    
        if(gamefinish == false)
        {
            if(script.selected == 1)
            {
                transform.position = new Vector3(0,Camerachain_o.transform.position.y,-10);
            }
            else if(script.selected == 2)
            {
                transform.position = new Vector3(0,Camerachain_s.transform.position.y,-10); 
            } 
            else if(script.selected == 3)
            {
                transform.position = new Vector3(0,Camerachain_sh.transform.position.y,-10); 
            } 
        }
        else if(gamefinish == true)
        {
            transform.position = new Vector3(0,0,-10);
        }
        
    }
}
