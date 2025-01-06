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
    [SerializeField] private float nowCurrent = 128;
    [SerializeField] private float ChangeCurrent = 30;
    // Start is called before the first frame update
    void Start()
    {
        playerOperationActionset.Activate();
        //gvsConnect.SetCurrent(nowCurrent);
    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerR.GetStateDown(handTypeR))
        {
            Debug.Log("Stronger");
            //nowCurrent = Mathf.Clamp(nowCurrent,0,255);
            nowCurrent += ChangeCurrent;
            nowCurrent = Mathf.Clamp(nowCurrent, 0, 255);
            gvsConnect.SetCurrent(nowCurrent);

        }
        else if (TriggerL.GetStateDown(handTypeL))
        {
            Debug.Log("Weaker");
            nowCurrent -= ChangeCurrent;
            nowCurrent = Mathf.Clamp(nowCurrent, 0, 255);
            gvsConnect.SetCurrent(nowCurrent);
        }
    }

    private void OnApplicationQuit()
    {
        gvsConnect.SetCurrent(0);
    }
}
