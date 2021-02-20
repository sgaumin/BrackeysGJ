using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsLoader : MonoBehaviour
{
    [SerializeField]
    GameObject credits;
    bool creditsState = false;
    private void Start()
    {
        credits.SetActive(false);
    }
    // Start is called before the first frame update
    public void CreditsHide()
    {
        if(creditsState == false)
        {
            credits.SetActive(true);
            creditsState = true;
        }
        else
        {
            credits.SetActive(false);
            creditsState = false;
        }
    }
}
