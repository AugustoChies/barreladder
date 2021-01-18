using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpawner : MonoBehaviour
{
    public int nextSection;
    public StageSections sections;
    public List<GameObject> activeList;
    public Vector3 newSectionPosition;
    void Start()
    {
        nextSection = 0;
        activeList = new List<GameObject>();
        StageStart();
    }

    // Update is called once per frame
    void Update()
    {
        if(activeList[1].transform.position.y <= this.transform.position.y)
        {
            if(nextSection < sections.stageSections.Count)
            {
                AddSection();
                GameObject token = activeList[0];                
                activeList.RemoveAt(0);
                Destroy(token);
            }
        }
           
    }

    public void StageStart()//Also used when restarting
    {
        for (int i = 0; i < activeList.Count; i++)
        {
            Destroy(activeList[i]);
        }
        activeList.Clear();
        activeList.Add(Instantiate(sections.stageSections[nextSection], Vector3.zero, Quaternion.identity));
        nextSection++;
        AddSection();
    }

    public void AddSection()
    {
        activeList.Add(Instantiate(sections.stageSections[nextSection], newSectionPosition, Quaternion.identity));
        nextSection++;        
    }
}
