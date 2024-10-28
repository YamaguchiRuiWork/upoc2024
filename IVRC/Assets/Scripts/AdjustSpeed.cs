using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class AdjustSpeed : MonoBehaviour
{
    [SerializeField] GVSConnect gvsConnect;
    public SteamVR_ActionSet playerOperationActionset;
    public SteamVR_Input_Sources handTypeL;
    public SteamVR_Input_Sources handTypeR;
    public SteamVR_Action_Boolean TriggerL;
    public SteamVR_Action_Boolean TriggerR;
    // Start is called before the first frame update
    void Start()
    {
        playerOperationActionset.Activate();
    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerR.GetStateDown(handTypeR))
        {
            Debug.Log("Stronger");

        }
        else if (TriggerL.GetStateDown(handTypeL))
        {
            Debug.Log("Weaker");
        }
    }
}
