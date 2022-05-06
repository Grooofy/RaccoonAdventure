using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AlarmLight _lamp;

    private float _minVolumeValue = 0;
    private float _maxVolumeValue = 1;
    
    private AudioSource _audioSource;
    private Coroutine _coroutineVolume;

    private void Start() => _audioSource = GetComponent<AudioSource>();

    public void StartAlarm()
    {
        if (_coroutineVolume != null)
            StopCoroutine(_coroutineVolume);

        _coroutineVolume = StartCoroutine(FadeInVolume(_maxVolumeValue));
        _lamp.gameObject.SetActive(true);
    }

    public void StopAlarm()
    {
        if (_coroutineVolume != null)
            StopCoroutine(_coroutineVolume);

        _coroutineVolume = StartCoroutine(FadeInVolume(_minVolumeValue));
        _lamp.gameObject.SetActive(false);
    }

    private IEnumerator FadeInVolume(float value)
    {
        float speed = 0.1f;
        float step = speed * Time.deltaTime;

        while (_audioSource.volume != value)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, value, step);
            yield return null;
        }
    }
}
