using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1.0f;
    private int _dividerValue = 2;
    private Renderer _renderer;

    public float SplitChance => _splitChance;

    public void DecreaseSplitChance(float chance)
    {
        _splitChance = chance / _dividerValue;
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        SetRandomColor();
    }

    private void SetRandomColor()
    {
        _renderer.material.color = Random.ColorHSV();
    }
}
