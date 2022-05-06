using UnityEngine;

public class DoorLock : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private bool _isAlarmActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out WaypointMovement _))
        {
            if (_isAlarmActive == false)
            {
                _alarm.StartAlarm();
                _isAlarmActive = true;
            }
            else
            {
                _alarm.StopAlarm();
                _isAlarmActive = false; 
            }
        }
    }
}
