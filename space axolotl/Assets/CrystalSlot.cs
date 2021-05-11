using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSlot : MonoBehaviour
{
    // Start is called before the first frame update
    
    public string crystalType;
    public GameObject crystalTracker;
    public GameObject EarthCrystal;
    public GameObject WaterCrystal;
    public GameObject AirCrystal;
    public GameObject FireCrystal;
        public void OnInteract()
    {
        if (crystalType =="Earth" && crystalTracker.GetComponent<CrystalTracking>().EarthCrystalT == true)
        {
            crystalTracker.GetComponent<CrystalTracking>().EarthCrystalPlaced = true;
            crystalTracker.GetComponent<CrystalTracking>().EarthCrystalT = false;
            EarthCrystal.SetActive(true);
        }
        if (crystalType =="Water" && crystalTracker.GetComponent<CrystalTracking>().WaterCrystalT == true)
        {
            crystalTracker.GetComponent<CrystalTracking>().WaterCrystalPlaced = true;
            crystalTracker.GetComponent<CrystalTracking>().WaterCrystalT = false;
            WaterCrystal.SetActive(true);
        }
        if (crystalType =="Air" && crystalTracker.GetComponent<CrystalTracking>().AirCrystalT == true)
        {
            crystalTracker.GetComponent<CrystalTracking>().AirCrystalPlaced = true;
            crystalTracker.GetComponent<CrystalTracking>().AirCrystalT = false;
            AirCrystal.SetActive(true);
        }
        if (crystalType =="Fire" && crystalTracker.GetComponent<CrystalTracking>().FireCrystalT == true)
        {
            crystalTracker.GetComponent<CrystalTracking>().FireCrystalPlaced = true;
            crystalTracker.GetComponent<CrystalTracking>().FireCrystalT = false;
            FireCrystal.SetActive(true);
        }
    }
}
