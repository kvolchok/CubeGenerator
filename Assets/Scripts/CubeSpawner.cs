using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _cubePrefab;

    [SerializeField]
    private float _minPositionX;
    [SerializeField]
    private float _maxPositionX;

    [SerializeField]
    private float _positionY;
    [SerializeField]
    private float _positionZ;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GenerateNewCube();
        }
    }

    private void GenerateNewCube()
    {
        var positionX = Random.Range(_minPositionX, _maxPositionX);
        var newPosition = new Vector3(positionX, _positionY, _positionZ);

        Instantiate(_cubePrefab, newPosition, Quaternion.identity);
    }
}
