using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToggle : MonoBehaviour
{
    public bool active;
    private void Start()
    {
        active = gameObject.active;
    }
    public void Toogle()
    {
        if (active)
        {
            active = false;
           
        }
        else
        {
            active = true;
        }
        gameObject.SetActive(active);
    }
}
