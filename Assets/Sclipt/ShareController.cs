using UnityEngine;  
using System.IO;  
using System.Collections;  
using SocialConnector;  
using UnityEngine.UI;  
  
public class ShareController : MonoBehaviour  
{  
    public void Share()  
    {  
        StartCoroutine ("_share");
    }

    private IEnumerator Sample() 
    {
        ScreenCapture.CaptureScreenshot ("image.png");
        yield return null;
    
        var shareText = "OfficeGearで遊んだよ！";
        var shareUrl = "";
        var imagePath = Application.persistentDataPath + "/image.png";
    
        SocialConnector.SocialConnector.Share(shareText, shareUrl, imagePath);
    }
}