using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
public class CreateItem : MonoBehaviour
{
    public bool checkScrool = false;
    public List<Button> buttonList;

    //public Canvas contentCanvas;
    public RectTransform contentPanel;
    public GameObject content;
    public Button button;
    public ScrollRect scrollRect;
    public bool scrollingDown = false;

    public int numItems = 1000;
    private int count = 0;
    public int headDestroy = 0;
    public int bottomDestoy = 0;
    private int maxCreate = 3;
    private int maxCreateBegin = 10;
    public float timeRemaining = 1;
    public int buttonDestroyed = 100;

    private float lastScroll;
    private float currentScroll;

    // Start is called before the first frame update
    void Start()
    {
        
        lastScroll = scrollRect.verticalNormalizedPosition;
        currentScroll = scrollRect.verticalNormalizedPosition;
        List<Button> buttonList = new List<Button>();
        FirstCreate();

    }
    public void UpdateCurrentScroll()
    {
        currentScroll = scrollRect.verticalNormalizedPosition;
    }
    public void PutInButton()
    {

    }

    // Update is called once per frame
    public void FirstCreate()
    {

        for (int i = 0; i < maxCreateBegin; i++)
        {
            bottomDestoy += 1;
            count += 1;
            float y = contentPanel.sizeDelta.y + button.GetComponent<RectTransform>().sizeDelta.y;
            contentPanel.sizeDelta = new Vector2(contentPanel.sizeDelta.x, y);
            Button temp = Instantiate(button);
            temp.transform.SetParent(content.transform);
            temp.GetComponent<ButtonDecription>().nameButton = count.ToString();
            temp.GetComponent<ButtonDecription>().setScale(Random.Range(1, 10), Random.Range(1, 10), Random.Range(1, 10));
            temp.name = count.ToString();
            buttonList.Add(temp);
            //temp.gameObject.SetActive(false);
            //Debug.Log(temp.name);
        }
    }
    public void BackgroundCreate()
    {
        if (count < numItems)
        {

        
        for (int i = 0; i < maxCreate; i++)
        {
            
            count += 1;
            float y = contentPanel.sizeDelta.y + button.GetComponent<RectTransform>().sizeDelta.y;
            contentPanel.sizeDelta = new Vector2(contentPanel.sizeDelta.x, y);
            Button temp = Instantiate(button);
            temp.transform.SetParent(content.transform);
            temp.GetComponent<ButtonDecription>().nameButton = count.ToString();
            temp.GetComponent<ButtonDecription>().setScale(Random.Range(1, 10), Random.Range(1, 10), Random.Range(1, 10));
            temp.name = count.ToString();
            buttonList.Add(temp);
            temp.gameObject.SetActive(false);
            //Debug.Log(temp.name);
        }
        }
    }
    public void Create()
    {
        
        for (int i = 0; i < maxCreate; i++)
        {
            buttonList[bottomDestoy].gameObject.SetActive(true);
            bottomDestoy += 1;
        }
        
        for (int i = 0; i < maxCreate; i++)
        {
            buttonList[headDestroy].gameObject.SetActive(false);
            headDestroy += 1;
        }
        Vector2 po = contentPanel.anchoredPosition;
        int sum = content.transform.childCount;
       
        po.y = po.y-90;
        contentPanel.anchoredPosition = po;


    }
    public void DeCreate()
    {
        
        for (int i = 0; i < maxCreate; i++)
        {
            if (bottomDestoy > maxCreateBegin)
            {
                bottomDestoy -= 1; ;
                buttonList[bottomDestoy].gameObject.SetActive(false);
            }
            
            

        }
        for (int i = 0; i < maxCreate; i++)
        {
            if (headDestroy > 0)
            {
                headDestroy -= 1;
                buttonList[headDestroy].gameObject.SetActive(true);
            }
            
         

        }
       
        //buttonList[bottomDestoy].gameObject.SetActive(false);
        //buttonList[headDestroy].gameObject.SetActive(true);
        Vector2 po = contentPanel.anchoredPosition;
        po.y = po.y - 30;
        contentPanel.anchoredPosition = po;
    }

    public void Search(string target)
    {


        Transform needButton = content.transform.Find(target);
        if (needButton != null)
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
        count = -1;
    }



    void Update()
    {

        if(count < numItems)
        {
            
        }

        /*
         if ( timeRemaining > 0)
         {
             timeRemaining -= Time.deltaTime;
         }
                if(scrollRect.verticalNormalizedPosition <= 0.6)
         {
             Create();
             DestroyButtons();
             timeRemaining = 1;


         }
         if (content.GetComponentsInChildren<Transform>().GetLength(0) >200)
         {
             if (scrollRect.verticalNormalizedPosition >= 0.8 && timeRemaining <= 0)
             {
                 ReactiveAheadButton();
                 timeRemaining = 1;

             }
        }
        */
        float mouse = Input.mouseScrollDelta.y;
        if (mouse > 0)
        {
            DeCreate();
            lastScroll = currentScroll;
            scrollingDown = false;
        }
        else if (mouse < 0)
        {
            BackgroundCreate();
            Create();
            lastScroll = currentScroll;
            scrollingDown = true;
        }






    }
}
