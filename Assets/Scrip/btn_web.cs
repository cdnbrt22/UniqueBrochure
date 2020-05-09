using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_web : MonoBehaviour
{
    public string url;
    public void open()
    {
        Application.OpenURL(url);
    }
}
