using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;

public class RatsSoundNightmare : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string PlayerStateEvent = "";
    FMOD.Studio.EventInstance playerState;
    // Start is called before the first frame update
    void Start()
    {
        playerState = FMODUnity.RuntimeManager.CreateInstance(PlayerStateEvent);
        
        playerState.start();
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(playerState, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
