using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubcribeScript : MonoBehaviour
{
    public GameObject content;
    public GameObject avatar;
    public GameObject warning;
    Sprite choosenImage;
    Button guildButton;
    Button destroyButton;
    public TextMeshProUGUI acceptButtenText;
    public TMP_InputField nameInput;
    public TMP_InputField decritionInput;
    public TMP_InputField ruleInput;
    bool avatarChoose = false;
    public GameObject  DefaultCanvas;

    // Start is called before the first frame update
    public void Choose(GameObject button)
    {
        choosenImage = button.GetComponent<Image>().sprite;
       
    }
    public void Choosen()
    {
        avatar.GetComponent<Image>().sprite = choosenImage;
        avatarChoose = true;
    }
    public void Accept()
    {
        string nameString = nameInput.text;
        string dicriptionString = decritionInput.text;
        string ruleString = ruleInput.text;
        if (nameString != "" && ruleString != "" && avatarChoose)
        {
            Button temp = guildButton;
            temp.transform.SetParent(content.transform);
            Transform image= temp.gameObject.transform.GetChild(0);
            image.GetComponent<Image>().sprite = avatar.GetComponent<Image>().sprite;
            Transform panel = temp.gameObject.transform.GetChild(1);
            Transform name = panel.transform.GetChild(0);
            Transform dicription = panel.transform.GetChild(1);
            Transform rule = panel.transform.GetChild(2);
            name.GetComponent<TextMeshProUGUI>().SetText(nameString);
            dicription.GetComponent<TextMeshProUGUI>().SetText(dicriptionString);
            rule.GetComponent<TextMeshProUGUI>().SetText(ruleString);
            nameInput.interactable = true;
            avatarChoose = false;
            nameInput.SetTextWithoutNotify(null);
            decritionInput.SetTextWithoutNotify(null);
            ruleInput.SetTextWithoutNotify(null);
            avatar.GetComponent<Image>().sprite = null;
            gameObject.SetActive(false);
            DefaultCanvas.SetActive(true);

        }
        else
        {
            warning.SetActive(true);
            gameObject.transform.GetChild(1).GetComponent<CanvasGroup>().interactable = false;
        }
    }
    public void Edit(Button button)
    {
        destroyButton = null;
        guildButton = button;
        guildButton.onClick.AddListener(() => Edit(button));
        Transform image = guildButton.gameObject.transform.GetChild(0);
        avatar.GetComponent<Image>().sprite = null;
        avatar.GetComponent<Image>().sprite  = image.GetComponent<Image>().sprite;
        avatarChoose = true;
        Transform panel = guildButton.gameObject.transform.GetChild(1);
        Transform name = panel.transform.GetChild(0);
        Transform dicription = panel.transform.GetChild(1);
        Transform rule = panel.transform.GetChild(2);
        nameInput.SetTextWithoutNotify( name.GetComponent<TextMeshProUGUI>().text);
        nameInput.interactable = false;
        decritionInput.SetTextWithoutNotify(dicription.GetComponent<TextMeshProUGUI>().text);
        ruleInput.SetTextWithoutNotify(rule.GetComponent<TextMeshProUGUI>().text);
        acceptButtenText.SetText("Confirm");
    }
    public void FirstCreate(Button button)
    {
        guildButton = button;
        guildButton.onClick.AddListener(() => Edit(button));
        destroyButton = guildButton;
        acceptButtenText.SetText("Create New");
    }
    public void Exit()
    {
        gameObject.SetActive(false);
        if (destroyButton)
        {
            destroyButton.gameObject.SetActive(false);
        }
        avatarChoose = false;
        nameInput.SetTextWithoutNotify(null);
        decritionInput.SetTextWithoutNotify(null);
        ruleInput.SetTextWithoutNotify(null);
        avatar.GetComponent<Image>().sprite = null;
        gameObject.SetActive(false);
        DefaultCanvas.SetActive(true);
    }
}
