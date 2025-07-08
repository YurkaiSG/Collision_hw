using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1.0f;
    private int _dividerValue = 2;
    private Renderer _renderer;
    private Rigidbody _rigidBody;
    private int _generation = 0;

    public float SplitChance => _splitChance;
    public int CurrentGeneration => _generation;
    public Rigidbody RigidBody => _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        _generation++;
        ChangeColorToRandom();
    }

    public void DecreaseSplitChance(float chance)
    {
        _splitChance = chance / _dividerValue;
    }

    private void ChangeColorToRandom()
    {
        _renderer.material.color = Random.ColorHSV();
    }
}
