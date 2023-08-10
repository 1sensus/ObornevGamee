using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    public Transform TargetTransfom;
    public Camera CharCamera;
    public Transform PointerImage;

    void FixedUpdate()
    {
              
        Vector3 fromPlayerToTarget = TargetTransfom.position - transform.position;        
        Ray ray = new Ray(transform.position, fromPlayerToTarget);
        Debug.DrawRay(transform.position, fromPlayerToTarget, Color.red);
        float mindistance = Mathf.Infinity;
        mindistance = Mathf.Clamp(mindistance, fromPlayerToTarget.magnitude - 1.2f, fromPlayerToTarget.magnitude-1.2f);
        Vector3 worldPos = ray.GetPoint(mindistance);
        PointerImage.position = CharCamera.WorldToScreenPoint(worldPos);
    }
}
