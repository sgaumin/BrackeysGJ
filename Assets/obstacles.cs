using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    [SerializeField]
    int RatsToKill = 10;
    GameObject[] prout;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DestroyRats()
    {
        prout = GameObject.FindGameObjectsWithTag("Rat");
        for (int i = 0; i < RatsToKill; i++)
        {
            Destroy(prout[i]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(prout.Length);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            Destroy(gameObject);
            DestroyRats();
        }

    }
}
