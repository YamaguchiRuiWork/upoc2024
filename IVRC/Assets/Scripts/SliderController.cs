using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Valve.VR;
using UnityEngine.UI;
using UnityEditor;

public class SliderController : MonoBehaviour
{
    // Start is called before the first frame update

    public SteamVR_ActionSet playerOperationActionset;
    public SteamVR_Input_Sources handTypeL;
    public SteamVR_Action_Boolean TriggerL;
    public SteamVR_Action_Boolean ButtonY;
    public SteamVR_Action_Boolean ButtonX;
    //public SteamVR_Action_Boolean Y;
    //public SteamVR_Action_Boolean X;
    Slider slider;
    float potisionX;
    //public float speed = 3;//vas‚Ì‚Â‚Ü‚Ý‚ð“®‚©‚·‘¬“x
    public float speedY = 10;//vas‚Ì‚Â‚Ü‚Ý‚ð“®‚©‚·‘¬“x
    public float speedX = 10;//vas‚Ì‚Â‚Ü‚Ý‚ð“®‚©‚·‘¬“x
    private int SliderValue;
    void Start()
    {
        playerOperationActionset.Activate();
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonY.GetStateDown(handTypeL))
        {
            Debug.Log("ButtonY");
            SliderValue = (int)(slider.value + speedY);
            slider.value = SliderValue;
        }
        /*else if (Y.GetState(handTypeL))//’·‰Ÿ‚µ
        {
            Debug.Log("Y");
            SliderValue = (int)(slider.value + speedY);
            slider.value = SliderValue;
        }*/
        else if (ButtonX.GetStateDown(handTypeL))
        {
            Debug.Log("ButtonX");
            SliderValue = (int)(slider.value - speedX);
            slider.value = SliderValue;
        }
        /*else if (X.GetState(handTypeL))//’·‰Ÿ‚µ
        {
            Debug.Log("X");
            SliderValue = (int)(slider.value - speedX);
            slider.value = SliderValue;
        }*/

        //potisionX = AnalogstickL.GetAxis(handTypeL).x;
        /*if (potisionX != 0)
        {
            int SliderValue = (int)(slider.value + potisionX * speed);
            slider.value = SliderValue;
        }*/

    }
}