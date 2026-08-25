using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice_Panel : MonoBehaviour
{
    public GameObject Choseoption;

    public Bank_Manager bank_manager;

    public void choice()
    {
        Choseoption.SetActive(true);
        bank_manager.Submoney(2000);
    }
}
