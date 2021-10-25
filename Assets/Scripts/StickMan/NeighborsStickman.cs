using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborsStickman : MonoBehaviour
{
    [SerializeField] private List<GameObject> neighbors;

    public bool CheckNeihbors(GameObject finish)
    {
        foreach (var item in neighbors)
        {
            if(item == finish)
            {
                return true;
            }
        }
        return false;
    }
}
