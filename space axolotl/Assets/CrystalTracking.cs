using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalTracking : MonoBehaviour
{
    public bool AirCrystalT = false;
    public bool WaterCrystalT = false;
    public bool EarthCrystalT = false;
    public bool FireCrystalT = false;

     public bool AirCrystalPlaced = false;
    public bool WaterCrystalPlaced = false;
    public bool EarthCrystalPlaced = false;
    public bool FireCrystalPlaced = false;

    public GameObject EarthMenu;
    public GameObject WaterMenu;
    public GameObject FireMenu;
    public GameObject AirMenu;

    private void Update()
    {
        if (AirCrystalT == true)
        {
            AirMenu.SetActive(true);
        }

        else
        {
            AirMenu.SetActive(false);
        }

        if (WaterCrystalT == true)
        {
            WaterMenu.SetActive(true);
        }

        else
        {
            WaterMenu.SetActive(false);
        }

        if (EarthCrystalT == true)
        {
            EarthMenu.SetActive(true);
        }

        else
        {
            EarthMenu.SetActive(false);
        }

        if (FireCrystalT == true)
        {
            FireMenu.SetActive(true);
        }

        else
        {
            FireMenu.SetActive(false);
        }
    }
}
