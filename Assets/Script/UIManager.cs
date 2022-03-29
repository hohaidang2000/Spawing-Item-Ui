using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{    
    public Canvas SubcribeCanvas;
    public Canvas ImageCanvas;
    public Canvas DefaultCanvas;
    public Button button;

    void Open()
    {
        gameObject.SetActive(true);
    }
    void Close()
    {
        gameObject.SetActive(false);
    }
    void Edit()
    {
        SubcribeCanvas.gameObject.SetActive(true);
        DefaultCanvas.gameObject.SetActive(false);
    }
    public void Create()
    {
        Button temp = Instantiate(button);
        temp.onClick.AddListener(Edit);
        temp.transform.GetChild(0).GetComponent<Image>().sprite = null; 
        SubcribeCanvas.GetComponent<SubcribeScript>().FirstCreate(temp);
    }
}
