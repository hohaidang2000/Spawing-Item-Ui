using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{    
    public Canvas SubcribeCanvas;
    public Canvas ImageCanvas;
    public Canvas DefaultCanvas;

    void Open()
    {
        gameObject.SetActive(true);
    }
    void Close()
    {
        gameObject.SetActive(false);
    }
    
}
