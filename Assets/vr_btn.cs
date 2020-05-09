using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class vr_btn : MonoBehaviour,IVirtualButtonEventHandler
{
    public string url;
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        //specify which button you want to function by using the if statement
        if (vb.name == "ButtonName")
        {
            Application.OpenURL("url");
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        throw new System.NotImplementedException();
    }
}
