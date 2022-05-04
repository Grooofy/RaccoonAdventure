using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private GameObject _lamp;

    private AudioSource _audioSource;
    private Coroutine _fadeInVolume;

    private void Start() => _audioSource = GetComponent<AudioSource>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<MovementPoints>() != null)
        {
            if (_fadeInVolume == null)
            {
                _fadeInVolume = StartCoroutine(FadeInVolume(_audioSource.minDistance));
                _lamp.SetActive(true);
            }
            else
            {
                StartCoroutine(FadeInVolume(0));
                _fadeInVolume = null;
                _lamp.SetActive(false);
            } 
        }
    }

    private IEnumerator FadeInVolume(float distance)
    {
        float speed = 0.1f;
        float step = speed * Time.deltaTime;

        while (_audioSource.volume != distance)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, distance, step);
            yield return null;
        }
        StopCoroutine(FadeInVolume(distance));
    }
}
