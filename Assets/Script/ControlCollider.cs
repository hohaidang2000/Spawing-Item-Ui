using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCollider : MonoBehaviour
{
    public bool spawnable =false;
    // Start is called before the first frame update
 
    private void LateUpdate()
    {
       
    }
    public void End()
    {
        Destroy(gameObject);
    }
    public void setMask()
    {
        gameObject.layer = 1;
    }
}
