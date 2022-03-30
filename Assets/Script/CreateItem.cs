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

    public int index = 0;
    public int current = 0;
    public int numItems = 1000;
    private int count = 0;
    private int mouseScroll = 0;
    private int headDestroy = 0;
    private int bottomDestoy = 0;
    private int maxCreate = 3;
    private int maxCreateBegin = 10;
    public float timeRemaining = 1;
    public int buttonDestroyed = 100;
    public Button searchOne;
    private float lastScroll;
    private float currentScroll;
    GameObject[] contentarray;

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
       

        
        for (int i = 0; i < maxCreate ; i++)
        {
            if (count < numItems)
            {
                count += 1;
                float y = contentPanel.sizeDelta.y + button.GetComponent<RectTransform>().sizeDelta.y;
                contentPanel.sizeDelta = new Vector2(contentPanel.sizeDelta.x, y);
                Button temp = Instantiate(button);
                //temp.transform.SetParent(content.transform);
                temp.GetComponent<ButtonDecription>().nameButton = count.ToString();
                temp.GetComponent<ButtonDecription>().setScale(Random.Range(1, 10), Random.Range(1, 10), Random.Range(1, 10));
                temp.name = count.ToString();
                buttonList.Add(temp);
                temp.gameObject.SetActive(false);
            }
            //Debug.Log(temp.name);
        }
        
    }
    /*
    void RepeatListRe()
    {
        if (searchOne)
        {
            searchOne.gameObject.SetActive(false);
            searchOne.gameObject.transform.SetParent(null);
            searchOne = null;
        }

        for (int i = 0; i < maxCreate; i++)
        {
            GameObject tempLast = content.transform.GetChild(content.transform.childCount -i -1).gameObject;
            tempLast.SetActive(false);
            tempLast.transform.parent = null;

        }
        for (int i = 0; i < maxCreate; i++)
        {
            if (current < 0)
            {
                current = buttonList.Count<Button>() - 1;
            }
            Button tempFront = buttonList[current];
            current -= 1;

            tempFront.transform.SetParent(content.transform);
            tempFront.gameObject.SetActive(true);
            tempFront.transform.SetAsFirstSibling();
            tempFront.transform.localPosition = new Vector3(0, 0, 0);
            Vector3 getPo = tempFront.transform.position;
            getPo.y += 90;
            contentPanel.anchoredPosition =
               (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position)
               - (Vector2)scrollRect.transform.InverseTransformPoint(getPo);
        }
    }

    void RepeatList() {
        if (searchOne)
        {
            searchOne.gameObject.SetActive(false);
            searchOne.gameObject.transform.SetParent(null);
            searchOne = null;
        }
        for (int i = 0; i < maxCreate; i++)
        {
            if (index >= count)
            {
                index = 0;
            }
            Button tempFront = buttonList[index];
            index += 1;

            tempFront.transform.SetParent(content.transform);
            tempFront.gameObject.SetActive(true);
            tempFront.transform.SetAsLastSibling();
            tempFront.transform.localPosition = new Vector3(0, 0, 0);
            Vector3 getPo = tempFront.transform.position;
            getPo.y += 90;
            contentPanel.anchoredPosition =
               (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position)
               - (Vector2)scrollRect.transform.InverseTransformPoint(getPo);
        }
        for (int i = 0; i < maxCreate; i++)
        {
            GameObject tempLast = content.transform.GetChild(0).gameObject;
            tempLast.SetActive(false);
            tempLast.transform.parent = null;

        }

    }
    
    public void Create()
    {
        if (searchOne)
        {
            searchOne.gameObject.SetActive(false);
            searchOne.gameObject.transform.SetParent(null);
            searchOne = null;
        }
        if (count < numItems) { 
            
            Debug.Log(headDestroy);
            for (int i = 0; i < maxCreate; i++)
            {
                current += 1;
                if (bottomDestoy < numItems)
                {
                    buttonList[bottomDestoy].gameObject.SetActive(true);
                    buttonList[headDestroy].gameObject.transform.SetParent(contentPanel);
                    buttonList[headDestroy].gameObject.transform.SetAsLastSibling();
                    bottomDestoy += 1;
                }
            }
        
            for (int i = 0; i < maxCreate; i++)
            {

                    buttonList[headDestroy].gameObject.SetActive(false);
                    buttonList[headDestroy].gameObject.transform.SetParent(null);
                    headDestroy += 1;
           
            }
        }
        else
        {
            RepeatList();
        }

        Debug.Log(bottomDestoy);
        
        Vector2 po = contentPanel.anchoredPosition;
        int sum = content.transform.childCount;
        po.y = po.y - 90 ;
        contentPanel.anchoredPosition = po;

    
    }
    
    public void DeCreate()
    {
        if (searchOne)
        {
            searchOne.gameObject.SetActive(false);
            searchOne.gameObject.transform.SetParent(null);
            searchOne = null;
        }
        if (count < numItems)
        {
            for (int i = 0; i < maxCreate; i++)
        {
            if (bottomDestoy > maxCreateBegin)
            {
                bottomDestoy -= 1; ;
                buttonList[bottomDestoy].gameObject.SetActive(false);
                buttonList[bottomDestoy].gameObject.transform.SetParent(null);
            }
            
            

        }
        for (int i = 0; i < maxCreate; i++)
        {
            if (headDestroy > 0)
            {
                headDestroy -= 1;
                buttonList[headDestroy].gameObject.SetActive(true);
                buttonList[headDestroy].gameObject.transform.SetParent(content.transform);
                    buttonList[headDestroy].gameObject.transform.SetAsFirstSibling();
            }
            
         

        }
       
        //buttonList[bottomDestoy].gameObject.SetActive(false);
        //buttonList[headDestroy].gameObject.SetActive(true);
        Vector2 po = contentPanel.anchoredPosition;
        po.y = po.y - 90;
        contentPanel.anchoredPosition = po;
        }
        else
        {
            RepeatListRe();
        }
    }

    public void GetBack()
    {
        count = -1;
    }


    */

    public void Search(string target)
    {

        if (searchOne)
        {
            searchOne.gameObject.SetActive(false);
            searchOne = null;
        }

        if (buttonList.Find(x => x.name == target))
        {
            searchOne = buttonList.Find(x => x.name == target);
            searchOne.gameObject.SetActive(true);
            int mono = System.Int32.Parse(target) % 3;
            searchOne.gameObject.transform.SetParent(content.transform);
            searchOne.transform.SetAsFirstSibling();
            searchOne.transform.localPosition = new Vector3(0, 0, 0);
            Vector3 getPo = searchOne.transform.position;
            //getPo.y += 30;
            Debug.Log(System.Int32.Parse(target));
            contentPanel.anchoredPosition =
            (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position)
            - (Vector2)scrollRect.transform.InverseTransformPoint(getPo);
        }


    }
    void MovingOnListAhead()
    {
       
        for (int i = 0; i < maxCreate; i++)
        {

            headDestroy -= 1;
            if (headDestroy <= 0) {
                headDestroy = 0;
                Button temp = buttonList[headDestroy];
                temp.transform.SetParent(content.transform);
                temp.gameObject.SetActive(true);
                temp.transform.SetAsFirstSibling();
                if(content.transform.childCount > 13)
                {
                    GameObject tempLast = content.transform.GetChild(content.transform.childCount - 1).gameObject;
                    tempLast.SetActive(false);
                    tempLast.transform.parent = null;
                    bottomDestoy -= 1;
                    if (bottomDestoy < 0)
                    {
                        bottomDestoy = count;
                    }
                }

            }
            else
            {
                bottomDestoy -= 1;
                if (bottomDestoy < 0)
                {
                    bottomDestoy = count;
                }
                if (headDestroy < 0)
                {
                    headDestroy = count;
                }
                Button temp = buttonList[headDestroy];
                temp.transform.SetParent(content.transform);
                temp.gameObject.SetActive(true);
                temp.transform.SetAsFirstSibling();
                GameObject tempLast = content.transform.GetChild(content.transform.childCount - 1).gameObject;
                tempLast.SetActive(false);
                tempLast.transform.parent = null;
            }

        }
        Vector2 getPo = content.transform.position;
        getPo.y += 30;
        contentPanel.anchoredPosition =
       (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position)
        - (Vector2)scrollRect.transform.InverseTransformPoint(getPo);
    }
    void MovingOnListBelow()
    {
        for (int i = 0; i < maxCreate; i++)
        {
            GameObject tempLast = content.transform.GetChild(0).gameObject;
            tempLast.SetActive(false);
            tempLast.transform.parent = null;
            headDestroy += 1;
            bottomDestoy += 1;
            if(bottomDestoy == count)
            {
                bottomDestoy = 0;
            }
            if(headDestroy == count)
            {
                headDestroy = 0;
            }
            Button temp = buttonList[bottomDestoy];
            temp.transform.SetParent(content.transform);
            temp.gameObject.SetActive(true);
           

        }
        Vector2 getPo = content.transform.position;
        getPo.y -= 30;
        contentPanel.anchoredPosition =
       (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position)
        - (Vector2)scrollRect.transform.InverseTransformPoint(getPo);

    }
    void Update()
    {

        if(count < numItems)
        {
            BackgroundCreate();
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
            if (mouseScroll > 0)
            {
                MovingOnListAhead();
                lastScroll = currentScroll;
                
                mouseScroll -= 1;
            }
        }
        else if (mouse < 0)
        {
            MovingOnListBelow();
            lastScroll = currentScroll;
            mouseScroll += 1;
        }






    }
}
