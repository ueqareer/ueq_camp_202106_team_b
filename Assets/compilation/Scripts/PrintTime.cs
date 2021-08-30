using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintTime : MonoBehaviour
{
    private Text ClockText;
    // Start is called before the first frame update
    void Start()
    {
        ClockText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ClockText.text = DateTime.Now.ToLongTimeString();
    }
}
