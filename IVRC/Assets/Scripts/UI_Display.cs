using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Valve.VR;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.UIElements;

public class UI_Display : MonoBehaviour
{
    // Start is called before the first frame update
    public SteamVR_ActionSet playerOperationActionset;
    public SteamVR_Input_Sources handTypeL;
    public SteamVR_Input_Sources handTypeR;
    public SteamVR_Action_Boolean TriggerR;
    public SteamVR_Action_Boolean TriggerL;
    public GameObject UI_MoveAdjust;
    private bool CountFlag = false;
    [SerializeField] private float Count = 0;
    [SerializeField] private float Countlimit = 3;
    void Start()
    {
        playerOperationActionset.Activate();
        UI_MoveAdjust.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerL.GetStateDown(handTypeL) || TriggerR.GetStateDown(handTypeR))
        {
            Debug.Log("ButtonYorX");
            UI_MoveAdjust.SetActive(true);
            CountFlag = true;
            Count = 0;
        }

        if (CountFlag)
        {
            Count += Time.deltaTime;
            if (Count >= Countlimit)
            {
                CountFlag = false;
                Count = 0;
                UI_MoveAdjust.SetActive(false);
            }
        }
    }
}
