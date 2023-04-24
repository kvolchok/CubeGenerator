using UnityEngine;

public class RecoloringBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _hueMin;
    [SerializeField]
    private float _hueMax;

    [SerializeField]
    private float _recoloringDuration;
    [SerializeField]
    private float _recoloringDelay;
    
    
    private float _recoloringTime;

    private Color _startColor;
    private Color _nextColor;
    
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        GenerateNextColor();
    }

    private void Update()
    {
        _recoloringTime += Time.deltaTime;

        SetIntermediateColor();

        if (_recoloringTime >= _recoloringDuration + _recoloringDelay)
        {
            _recoloringTime = 0;
            GenerateNextColor();
        }
    }

    private void GenerateNextColor()
    {
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(_hueMin, _hueMax);
    }
    
    private void SetIntermediateColor()
    {
        var progress = _recoloringTime / _recoloringDuration;
        var currentColor = Color.Lerp(_startColor, _nextColor, progress);
        _renderer.material.color = currentColor;
    }
}
