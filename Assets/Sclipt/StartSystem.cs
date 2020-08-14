using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSystem : MonoBehaviour
{
    //クレジット表記のボタン判定
    private bool showcredit = false;
    //クレジット画像
    public GameObject creditimage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnCredit()
    {
        if(showcredit == false)
        {
            //表示
            showcredit = true;
            creditimage.gameObject.SetActive(true);
        }
        else if(showcredit == true)
        {
            //非表示
            showcredit = false;
            creditimage.gameObject.SetActive(false);
        }
        
    }
}
