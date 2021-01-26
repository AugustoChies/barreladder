using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpawner : MonoBehaviour
{
    public int nextSection;
    public StageSections sections;
    public List<GameObject> activeList;
    public Vector3 newSectionPosition,initialPos;
    void Start()
    {
        nextSection = 0;
        activeList = new List<GameObject>();
        StageStart();
    }

    // Update is called once per frame
    void Update()
    {
        if(activeList[0].transform.position.y <= -11.5f)
        {            
            GameObject token = activeList[0];                
            activeList.RemoveAt(0);
            Destroy(token);            
        }
           
    }

    public void StageStart()
    {       
        activeList.Clear();
        activeList.Add(Instantiate(sections.stageSections[nextSection],initialPos, Quaternion.identity));
        nextSection++;
        for (int i = 1; i < sections.stageSections.Count; i++)
        {
            AddSection();
        }
    }

    public void AddSection()
    {
        activeList.Add(Instantiate(sections.stageSections[nextSection], activeList[nextSection-1].transform.position + newSectionPosition, Quaternion.identity));
        nextSection++;        
    }
}
