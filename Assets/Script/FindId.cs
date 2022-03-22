using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FindId : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField text;
    public GameObject content;
    public void FindIdButton()
    {
        content.GetComponent<CreateItem>().Search(text.text);
    }
}
