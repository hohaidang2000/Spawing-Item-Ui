using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    

    void Open()
    {
        gameObject.SetActive(true);
    }
    void Close()
    {
        gameObject.SetActive(false);
    }
}
