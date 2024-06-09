using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Master : MonoBehaviour
{
    [SerializeField] Text _timerText;
    [SerializeField] Text _fps;
    float _timer;
    void Start()
    {
        _timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        UpdateText();
    }

    void UpdateText()
    {
        _timerText.text = "Timer: " + Mathf.Round(_timer);
        _fps.text = "FPS: " + (int)(1.0f / Time.deltaTime);
    }

    public float GetTimer()
    {
        return _timer;
    }

}
