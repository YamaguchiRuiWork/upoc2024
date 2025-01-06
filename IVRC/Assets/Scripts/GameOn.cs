using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GameOn : MonoBehaviour
{
    public SteamVR_ActionSet playerOperationActionset;
    [SerializeField] GVSConnect gvsConnect;
    public SteamVR_Input_Sources handTypeR;
    public SteamVR_Action_Boolean ButtonA;
    public GameObject GameInputAudio;
    //public GameObject GVS;
    private bool GameOnflag = true;
    // Start is called before the first frame update
    void Start()
    {
        playerOperationActionset.Activate();
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonA.GetStateDown(handTypeR) && GameOnflag)
        {
            GameInputAudio.SetActive(true);
            //GVS.SetActive(true);
            gvsConnect.SetCurrent(128);
            GameOnflag = false;
        }
        else if (ButtonA.GetStateDown(handTypeR) && !GameOnflag)
        {
            GameInputAudio.SetActive(false);
            gvsConnect.SetCurrent(0);
            GameOnflag = true;
        }
    }
}