using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLvl : MonoBehaviour
{
   
    List<GameObject> firstLevel = new List<GameObject>();
    public List<GameObject> sector = new List<GameObject>();
    public Material redMaterial;
    int index;

    private double startA;
    private double endingA;

    void Start()
    {
       
            CreateCollection();
        index = Random.Range(1, 35);
        Debug.Log(index);
        FirstLevelSectors(index);
    }

    public List<GameObject> Lister()
    {
        return sector;
    }
void FirstLevelSectors(int i)
    {
        Debug.Log(i);
        for (int j = 0; j < 9; j++) 
        {

            sector.Add(firstLevel[i]);
            Debug.Log(sector[j]+"---" + j + "       " + firstLevel[i]);
            firstLevel[i].GetComponent<Renderer>().material.color = new Color(0000, 0000, 0000); 
                if (i==35)
                {
                    i=0;
                }
                else
                {
                    i ++;
                }
        }
        AddTagsToSelectSectors();
    }

    public void AddTagsToSelectSectors()
    {
        for(int i = 0; i < sector.Count; i++)
        {
            sector[i].tag = "SelectSector";
        }
    }

    void CreateCollection()
    {
        for (int i = 0; i < 36;)
        {
            var sectors = GameObject.Find("littleSector (" + i + ")");
            //sectors.tag = "NotSelectingSector";
            firstLevel.Add(sectors);
            i++;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
