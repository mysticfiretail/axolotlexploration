using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem1Code : MonoBehaviour
{
    [SerializeField]public GameObject Button1;
    [SerializeField]public GameObject Button2;

    public GameObject totem2;

    [SerializeField]public GameObject Button3;
    [SerializeField]public GameObject Button4;

    [SerializeField]public GameObject Button5;
    [SerializeField]public GameObject Button6;

    public GameObject Platform1;

    public GameObject totem3;

    void Update()
    {
        if(Button1.GetComponent<Button1>().isActive == true && Button2.GetComponent<Button2>().isActive == true)
            {
                totem2.SetActive(true);
            }
            else{
                
            }

            if(Button3.GetComponent<Button3>().isActive == true && Button4.GetComponent<Button4>().isActive == true)
            {
                totem3.SetActive(true);
            }
            else{
                
            }

            if(Button5.GetComponent<Button5>().isActive == true && Button6.GetComponent<Button6>().isActive == true)
            {
                Platform1.GetComponent<Platform_Moving>().enabled = true;
            }
            else{
                
            }
    }
    

    
    
}
