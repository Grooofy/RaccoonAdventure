using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update() => gameObject.transform.LookAt(_target);
}
