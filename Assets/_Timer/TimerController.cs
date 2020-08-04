using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text m_timerText;
    public float m_timer = 30.0f;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            m_timer += 5f;
        }

        m_timer -= Time.deltaTime;
        m_timerText.text = "Timer: " + m_timer.ToString("F2");
    }
}
