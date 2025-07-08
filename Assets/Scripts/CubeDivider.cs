using UnityEngine;
using UnityEngine.Events;

public class CubeDivider : MonoBehaviour
{
    [SerializeField] private Caster _caster;

    [HideInInspector]
    public UnityEvent<Cube> OnSpawn;
    [HideInInspector]
    public UnityEvent<Cube> OnExplode;

    private void OnEnable()
    {
        _caster.OnMouseClicked.AddListener(Divide);
    }

    private void OnDisable()
    {
        _caster.OnMouseClicked.RemoveListener(Divide);
    }

    private void Divide(Cube cube)
    {
        if (cube.SplitChance >= Random.value)
        {
            OnSpawn.Invoke(cube);
            OnExplode.Invoke(cube);
        }    

        Destroy(cube.gameObject);
    }
}
