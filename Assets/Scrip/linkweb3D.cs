using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linkweb3D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                //Application.OpenURL("https://www.computing.psu.ac.th/th/b-sc-computing/");
                Application.OpenURL("https://www.computing.psu.ac.th/th/b-eng-digital-engineer-international-program/");
            }
        }
    }
}
