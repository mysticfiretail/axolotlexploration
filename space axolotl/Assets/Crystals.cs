using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystals : MonoBehaviour
{
    public GameObject AirCrystalO;
    public GameObject WaterCrystalO;
    public GameObject EarthCrystalO;
    public GameObject FireCrystalO;
    public GameObject Tracker;

    public void OnInteract ()
    {
        if(gameObject.tag =="AirCrystal")
        {
            Tracker.GetComponent<CrystalTracking>().AirCrystalT = true;
            AirCrystalO.gameObject.SetActive(false);
        }
        else if(gameObject.tag =="WaterCrystal")
        {
            Tracker.GetComponent<CrystalTracking>().AirCrystalT = true;
            WaterCrystalO.SetActive(false);
        }
        else if(gameObject.tag =="EarthCrystal")
        {
            Tracker.GetComponent<CrystalTracking>().AirCrystalT = true;
            EarthCrystalO.SetActive(false);
        }
        else if(gameObject.tag =="FireCrystal")
        {
            Tracker.GetComponent<CrystalTracking>().AirCrystalT = true;
            FireCrystalO.SetActive(false);
        }
    }
}
