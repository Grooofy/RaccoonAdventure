using UnityEngine;

public class Caretaker : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update() => transform.LookAt(_target);
}
