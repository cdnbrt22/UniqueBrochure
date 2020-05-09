using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour {

    protected virtual void LateUpdate()
    {
       

        Lean.LeanTouch.ScaleObject(transform, Lean.LeanTouch.PinchScale);
    }
}
