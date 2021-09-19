using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowOrder : MonoBehaviour
{
    private Storage storage;
   
    private void Start()
    {
        storage = GameObject.FindGameObjectWithTag("Items").GetComponent<Storage>();
    }

    public void showO()
    {
        storage.CheckIndex(); 
    }
}
