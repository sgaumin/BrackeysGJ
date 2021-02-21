using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float timeInSeconds;
    [SerializeField]
    Text timer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        launchTimer();
    }
    public void launchTimer()
    {
        timeInSeconds -= Time.deltaTime % 60;
        float timeLeft = Mathf.RoundToInt(timeInSeconds);

        if (timeInSeconds <= 0)
        {
            // Debug.Log("prout");
            //Do finish timer
        }
        else
        {
            timer.text = timeLeft + "";
            //Debug.Log(timeInSeconds);
        }
    }
}
