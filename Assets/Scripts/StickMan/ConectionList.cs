using System.Collections.Generic;
using UnityEngine;

public class ConectionList : MonoBehaviour
{
    [SerializeField] private List<GameObject> graphways;
    public void OpenAllGraph()
    {
        foreach (var item in graphways)
        {
            item.GetComponent<GraphwayConnection>().disabled = true;
        }
    }
    public void CloseAllGraph()
    {
        foreach (var item in graphways)
        {
            //item.disabled = true;
        }
    }

}
