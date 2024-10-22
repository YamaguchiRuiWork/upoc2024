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
    public SteamVR_Action_Boolean ButtonY;
    public SteamVR_Action_Boolean ButtonX;
    public GameObject UI_MoveAdjust;
    private bool CountFlag = false;
    private float Count = 0;
    [SerializeField] private float Countlimit = 3;
    void Start()
    {
        playerOperationActionset.Activate();
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonX.GetStateDown(handTypeL) || ButtonY.GetStateDown(handTypeL))
        {
            Debug.Log("ButtonYorX");
            UI_MoveAdjust.SetActive(true);
            CountFlag = true;
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
