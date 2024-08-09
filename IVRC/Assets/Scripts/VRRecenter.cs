using UnityEngine;

using UnityEngine.XR;

using UnityEngine.XR.Management;



public class VRRecenter : MonoBehaviour

{

    XRInputSubsystem xrInput;

    public void Start()

    {

        var xrSettings = XRGeneralSettings.Instance;

        xrInput = xrSettings.Manager.activeLoader.GetLoadedSubsystem<XRInputSubsystem>();

    }



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {

            xrInput.TryRecenter();

            Debug.Log("Recenter");

        }

    }

}
