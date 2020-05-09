using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class Vbsc_model : MonoBehaviour, IVirtualButtonEventHandler
{// Start is called before the first frame update
    public GameObject VbButtonObj;
    public GameObject digital;
    void Start()
    {
        VbButtonObj = GameObject.Find("actionBTN");
        digital = GameObject.Find("digital");
        VbButtonObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("button down");
        digital.GetComponent<Animation>().Play();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        digital.GetComponent<Animation>().Stop();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
