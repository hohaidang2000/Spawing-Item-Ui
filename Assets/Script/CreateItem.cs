using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
public class CreateItem : MonoBehaviour
{
    public bool checkScrool=false;
    public List<Button> buttonList;
    public int numItems = 1000;
    //public Canvas contentCanvas;
    public RectTransform contentPanel;
    public GameObject content;
    public Button button;
    public ScrollRect scrollRect;
   
    // Start is called before the first frame update
    void Start()
    {
        List<Button> buttonList = new List<Button>();
        Create();
    }

    // Update is called once per frame
    public void Create()
    {
       
        for (int i = 1; i <= numItems; i++)
        {
            float y = contentPanel.sizeDelta.y + button.GetComponent<RectTransform>().sizeDelta.y;
            contentPanel.sizeDelta = new Vector2(contentPanel.sizeDelta.x,y);
            Button temp = Instantiate(button);
            temp.transform.SetParent(content.transform);
            temp.GetComponent<ButtonDecription>().nameButton = i.ToString();
            temp.GetComponent<ButtonDecription>().setScale(Random.Range(1,10), Random.Range(1, 10), Random.Range(1, 10));
            temp.name = i.ToString();
            buttonList.Add(temp);
            //Debug.Log(temp.name);
        }
    }
    public void Search(string target)
    {
        
       
        Transform needButton = content.transform.Find(target);
        if(needButton != null)
        {
            Vector3 getPo = needButton.transform.position;
            getPo.y += 10;
 
          
            Debug.Log("ok");
            contentPanel.anchoredPosition =
            (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position)
            - (Vector2)scrollRect.transform.InverseTransformPoint(getPo);
        }

    }
    public void GetBack()
    {
        Vector3 getPo = buttonList.First<Button>().transform.position;
        getPo.y += 10;
        contentPanel.anchoredPosition = (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position) -
            (Vector2)scrollRect.transform.InverseTransformPoint(getPo);
    }
    void Update()
    {
        if (scrollRect.verticalNormalizedPosition <=0.001f)
        {
            GetBack();
        }


    }
}
