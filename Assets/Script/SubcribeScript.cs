using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubcribeScript : MonoBehaviour
{
    public Sprite choosenImage;
    public GameObject avatar;
    public TMP_InputField nameInput;
    public TMP_InputField decritionInput;
    public TMP_InputField ruleInput;


    // Start is called before the first frame update
    public void Choose(GameObject button)
    {
        choosenImage = button.GetComponent<Image>().sprite;
       
    }
    public void Choosen()
    {
        avatar.GetComponent<Image>().sprite = choosenImage;
    }
    public void Accept()
    {
        Debug.Log(nameInput.text);
    }
}
