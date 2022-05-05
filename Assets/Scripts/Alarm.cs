using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AlarmLight _lamp;

    private float _minVolumeValue = 0;
    private float _maxVolumeValue = 1;
    private bool _isActive = true;

    private AudioSource _audioSource;
    private Coroutine _coroutineVolumeUp;
    private Coroutine _coroutineVolumeDown;

    private void Start() => _audioSource = GetComponent<AudioSource>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<WaypointMovement>() != null)
        {
            if (_isActive)
            {
                if (_coroutineVolumeDown != null)
                    StopCoroutine(_coroutineVolumeDown);

                _coroutineVolumeUp = StartCoroutine(FadeInVolume(_maxVolumeValue));
                _lamp.gameObject.SetActive(true);
            }
            else
            {
                if (_coroutineVolumeUp != null)
                    StopCoroutine(_coroutineVolumeUp);

                _coroutineVolumeDown = StartCoroutine(FadeInVolume(_minVolumeValue));
                _lamp.gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator FadeInVolume(float value)
    {
        _isActive = value != 1 ? true : false;

        float speed = 0.1f;
        float step = speed * Time.deltaTime;

        while (_audioSource.volume != value)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, value, step);
            yield return null;
        }
    }
}
