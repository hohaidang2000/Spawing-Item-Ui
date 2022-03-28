using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToggle : MonoBehaviour
{
    public bool isactive;
    private void Start()
    {
        isactive = gameObject.active;
    }
    public void Toogle()
    {
        if (isactive)
        {
            isactive = false;
           
        }
        else
        {
            isactive = true;
        }
        gameObject.SetActive(isactive);
    }
}
