using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private int hour;
    [SerializeField]
    private int minute;
    [SerializeField]
    private float seconds;
    private float totalTime;
    private float oldSeconds;
    private Text timerText;

    public GameObject addmin;
    public GameObject addhou;

    // Start is called before the first frame update
    void Start()
    {
        totalTime = hour * 60 * 60 + minute * 60 + seconds;
        oldSeconds = 0f;
        timerText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        totalTime = hour * 60 * 60 + minute * 60 + seconds;
        if(totalTime > 0f)totalTime -= Time.deltaTime;
        hour = (int)totalTime / (60 * 60);
        minute = (int)totalTime / 60 - hour*60;
        seconds = totalTime - minute * 60 - hour * 60 * 60;

        if(totalTime >= -1f && (int)seconds != (int)oldSeconds)
        {
            timerText.text = hour.ToString("00") + ":" + minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;
        if(totalTime <= 0f)
        {
            totalTime = 0;
            Debug.Log("§ŒÀŽžŠÔI—¹");
        }
    }

    public void onoff()
    {
        if (addmin.activeSelf)
        {
            addmin.SetActive(false);
            addhou.SetActive(false);
        }
        else
        {
            addmin.SetActive(true);
            addhou.SetActive(true);
        }
    }

    public void addminute()
    {
        minute += 1;
    }

    public void addhour()
    {
        hour += 1;
    }
}
