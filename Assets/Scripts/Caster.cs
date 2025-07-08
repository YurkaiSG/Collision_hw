using UnityEngine;
using UnityEngine.Events;

public class Caster : MonoBehaviour
{
    private Ray _ray;
    private float _rayDistance = 50f;

    [HideInInspector]
    public UnityEvent<Cube> OnMouseClicked;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit _hit;
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, _rayDistance))
            {
                GameObject castedObject = _hit.transform.gameObject;

                if (castedObject.TryGetComponent(out Cube cube))
                {
                    OnMouseClicked?.Invoke(cube);
                }
            }
        }
    }
}
