using System;
using UnityEngine;

public class Caster : MonoBehaviour
{
    private Ray _ray;
    private float _rayDistance = 50f;
    private int _mouseKeyCode = 0;

    public event Action<Cube> Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseKeyCode))
        {
            RaycastHit _hit;
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, _rayDistance))
            {
                GameObject castedObject = _hit.transform.gameObject;

                if (castedObject.TryGetComponent(out Cube cube))
                {
                    Clicked?.Invoke(cube);
                }
            }
        }
    }
}
