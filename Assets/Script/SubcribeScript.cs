using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubcribeScript : MonoBehaviour
{
    public Sprite choosenImage;
    public GameObject avatar;
    // Start is called before the first frame update
    public void Choose(GameObject button)
    {
        choosenImage = button.GetComponent<Image>().sprite;
       
    }
    public void Choosen()
    {
        avatar.GetComponent<Image>().sprite = choosenImage;
    }
}
