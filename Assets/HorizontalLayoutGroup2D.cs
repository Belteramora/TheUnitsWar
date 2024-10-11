using R3.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalLayoutGroup2D : MonoBehaviour
{
    public float distance;

    private void OnTransformChildrenChanged()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);

            child.position = transform.position;
            child.localPosition = new Vector3(child.localPosition.x + (distance * i), child.localPosition.y, child.localPosition.z); 
        }
    }

    

}
