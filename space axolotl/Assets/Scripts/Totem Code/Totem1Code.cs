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

    public GameObject waterTotem1;
    public GameObject waterTotem2;
    public GameObject waterTotem3;
    public GameObject waterTotem4;
    public GameObject waterTotem5;
    public GameObject waterTotem6;
    public GameObject waterTotem7;
    public GameObject waterTotem8;
    public GameObject waterTotem9;
    public GameObject waterTotem10;
    public GameObject waterTotem11;
    public GameObject waterTotem12;
    public GameObject WaterPodium;

    /////

   [SerializeField] public GameObject waterTerrain;


    /////

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

        if (waterTotem1.GetComponent<WaterTotem>().isCorrect == true && waterTotem2.GetComponent<WaterTotem>().isCorrect == true && waterTotem3.GetComponent<WaterTotem>().isCorrect == true && waterTotem4.GetComponent<WaterTotem>().isCorrect == true && waterTotem5.GetComponent<WaterTotem>().isCorrect == true && waterTotem6.GetComponent<WaterTotem>().isCorrect == true && waterTotem7.GetComponent<WaterTotem>().isCorrect == true && waterTotem8.GetComponent<WaterTotem>().isCorrect == true && waterTotem9.GetComponent<WaterTotem>().isCorrect == true && waterTotem10.GetComponent<WaterTotem>().isCorrect == true && waterTotem11.GetComponent<WaterTotem>().isCorrect == true && waterTotem12.GetComponent<WaterTotem>().isCorrect == true)
        {
            WaterPodium.SetActive(true);
            waterTerrain.GetComponent<waterUp>().enabled = true;

        }
        
    
    }
    

    
    
}
