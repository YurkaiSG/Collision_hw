using System;
using UnityEngine;

public class Caster : MonoBehaviour
{
    private Ray _ray;
    private float _rayDistance = 50f;
    private string _targetTag = "Cube";

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit _hit;
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, _rayDistance))
            {
                GameObject castedObject = _hit.transform.gameObject;

                if (castedObject.tag == _targetTag)
                {
                    castedObject.GetComponent<Cube>().OnMouseClick();
                }
            }
        }
    }
}
