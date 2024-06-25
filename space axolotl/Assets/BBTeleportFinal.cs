using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBTeleportFinal : MonoBehaviour
{
    public GameObject BBplayer;
    public GameObject Location;
    void OnTriggerEnter()
    {
        BBplayer.gameObject.transform.position = Location.gameObject.transform.position;
        BBplayer.gameObject.transform.rotation = Location.gameObject.transform.rotation;
    }
}
