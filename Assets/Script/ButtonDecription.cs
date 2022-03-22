using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonDecription : MonoBehaviour
{
    public string nameButton ="default";
    public float scaleX = 1;
    public float scaleY = 1;
    public float scaleZ = 1;

    public TextMeshProUGUI text;
    public Transform prefab;
    
    // Start is called before the first frame update
    void Start()
    {
        text.SetText("id: "+name + "  scale:" + scaleX + " "+ scaleY +" "+scaleZ);
    }
    public void setScale(float x, float y, float z)
    {
        scaleX = x;
        scaleY = y;
        scaleZ = z;
    }
    public void Create()
    {
        bool spawn = false;
        for (int count = 0; count < 50; count++) { 
            float y = Random.Range(-100, 100);
            float x = Random.Range(-80, 195);
            float z = Random.Range(30, 600);
            Transform cube = Instantiate(prefab);
            cube.name = name;
            cube.transform.localScale = new Vector3(scaleX*10, scaleY*10, scaleZ*10);
            cube.transform.position = new Vector3(x, y, z);
            cube.GetComponentInChildren<TextMeshPro>().SetText("id: " + name + "  scale:" + scaleX + " " + scaleY + " " + scaleZ);
            Collider[] coliders = Physics.OverlapSphere(cube.transform.position,(float) System.Math.Sqrt((scaleX * 10)* (scaleX * 10) + (scaleY * 10) * (scaleY * 10) + (scaleZ * 10) * (scaleZ * 10)));
            if(coliders.Length > 0)
            {
                cube.GetComponent<ControlCollider>().End();
            }
            else
            {
                spawn = true;
            }
            if (spawn)
            {
                break;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
