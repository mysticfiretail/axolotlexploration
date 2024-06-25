using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{

    public GameObject Credits;
    public GameObject MenuBack;

    void Start()
    {
        MenuBack.gameObject.SetActive(false);
    }
    public void OnInteract ()
    {
        Credits.gameObject.SetActive(true);
        MenuBack.gameObject.SetActive(true);
    }
}
