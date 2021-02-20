using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    int nbrOfRatToAdd = 10;
    [SerializeField] private Rat ratPrefab;
    Transform ratHolder;
    // Start is called before the first frame update
    void Start()
    {
        ratHolder = GameObject.Find("RatHolder").transform;
        Debug.Log("ratholder" + ratHolder);
        Debug.Log("ratPrefab" + ratPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // on trigger, add rats to the horde
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
            for (int i = 0; i < nbrOfRatToAdd; i++)
            {
                Instantiate(ratPrefab, ratHolder);
            }
            Debug.Log("hello world");
        }
    }
}
