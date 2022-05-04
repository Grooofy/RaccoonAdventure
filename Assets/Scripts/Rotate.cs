using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _speed = 30;
    
    private void Update() =>  gameObject.transform.Rotate(0, _speed * Time.deltaTime, 0);
    
}
