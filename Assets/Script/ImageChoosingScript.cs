using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChoosingScript : MonoBehaviour
{
    public GameObject choosingButton;
    // Start is called before the first frame update
    public void HasClickedButton(GameObject button)
    {
        if (choosingButton)
        {
            choosingButton.transform.GetChild(0).GetComponent<UIToggle>().Toogle();
        }
        choosingButton = button;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
