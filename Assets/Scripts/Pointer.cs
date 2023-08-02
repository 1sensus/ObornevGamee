using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform _targetTransfom;
    public Camera _camera;
    public Transform _pointerIconTransform;
    public string _targetTagName;
    void Start()
    {
        _targetTransfom = GameObject.FindGameObjectWithTag(_targetTagName).GetComponent<Transform>();
        _camera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 fromPlayerToTarget = _targetTransfom.position - transform.position;
        _targetTransfom = GameObject.FindGameObjectWithTag(_targetTagName).GetComponent<Transform>();
        Ray ray = new Ray(transform.position, fromPlayerToTarget);
        Debug.DrawRay(transform.position, fromPlayerToTarget, Color.red);
        Debug.Log("Origin"+ray.origin);
        Debug.Log(ray.direction);
    }
}
