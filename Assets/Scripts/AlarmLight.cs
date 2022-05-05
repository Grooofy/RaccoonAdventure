using UnityEngine;

public class AlarmLight : MonoBehaviour
{
    [SerializeField] private float _speed = 30;
    
    private void Update() =>  transform.Rotate(0, _speed * Time.deltaTime, 0);
}
