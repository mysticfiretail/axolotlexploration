using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWITCHERENABLE : MonoBehaviour
{
    public bool SwitchEnable = false;
    void OnTriggerEnter()
    {
        SwitchEnable = true;
    }
}
