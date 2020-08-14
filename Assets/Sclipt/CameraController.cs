using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Officemanplayer;
    public GameObject Sushiplayer;

    //椅子の人カメラ
    public GameObject Camerachain_o;
    //寿司カメラ
    public GameObject Camerachain_s;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            transform.position = new Vector3(0,Camerachain_o.transform.position.y,-10);
            transform.position = new Vector3(0,Camerachain_s.transform.position.y,-10);

    }
}
