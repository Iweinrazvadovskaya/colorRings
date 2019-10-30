using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

    public GameObject cameraContainer;
    public FirstLvl firts = new FirstLvl();
    List<GameObject> collisionSectors = new List<GameObject>();
    void Start()
    {
       gameObject.SetActive(true);
    }
    bool collision = true;

    private void OnTriggerEnter(Collider element)
    {

        if (element.tag == "SelectSector") { element.gameObject.GetComponent<Renderer>().material.color = new Color(1111, 1111, 1111); }
            collisionSectors.Add(element.gameObject);
    }

    void ChangeSectorColor(bool change, GameObject element)
    {
        if (change == false&& element.tag=="SelectSector")
        {
            element.GetComponent<Renderer>().material.color = new Color(0000, 0000, 0000);
        }
    }
    void BeginPainting()
    {
        gameObject.transform.rotation = Quaternion.Euler(1, transform.eulerAngles.y, transform.eulerAngles.z);
    }
    
    void Update()
    {
        transform.Rotate(.8f, 0, 0);
        if (Input.touchCount > 0 )
        {
            BeginPainting();
                  
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
            gameObject.transform.position = new Vector3(0, .95f, 0);
            if (/*collision == true && */collisionSectors.Count!=0)
            {

                for (int i = 0; i < collisionSectors.Count; i++)
                {
                    if (collisionSectors[i].tag !="SelectSector")
                    {
                        collision = false;
                        collisionSectors.Clear();
                    }
                    else {
                        collision = true;
                    }
                }
                if (collision == true)
                {
                    for (int i = 0; i < collisionSectors.Count; i++)
                    {
                            collisionSectors[i].transform.localScale = new Vector3(0.5555555f, 0.5555555f, 1);
                      
                    }
                    cameraContainer.transform.position = new Vector3(-0.03f, 13, -10.5f);
                }
                else
                {
                    for (int i = 0; i < collisionSectors.Count; i++)
                    {
                       ChangeSectorColor(false,collisionSectors[i]);
                    }
                }
                //collisionSectors[].transform.localScale = new Vector3(transform.localScale.x, 35, transform.localScale.z);
            }
        }

    }

}
