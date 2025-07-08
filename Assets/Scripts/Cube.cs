using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1.0f;
    private int _dividerValue = 2;
    private Renderer _renderer;
    private Rigidbody _rigidBody;

    public float SplitChance => _splitChance;
    public Rigidbody RigidBody => _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        SetRandomColor();
    }

    public void DecreaseSplitChance(float chance)
    {
        _splitChance = chance / _dividerValue;
    }

    private void SetRandomColor()
    {
        _renderer.material.color = Random.ColorHSV();
    }
}
