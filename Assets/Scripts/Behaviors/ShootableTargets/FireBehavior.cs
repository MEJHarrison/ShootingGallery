using System.Collections;
using UnityEngine;

public class FireBehavior : MonoBehaviour, ITargetBehavior
{
    [SerializeField] private ParticleSystem fireParticlesPrefab = null;
    [SerializeField] private ParticleSystem smokeParticlesPrefab = null;
    [SerializeField] private float partcilesTime = 3.0f;
    [SerializeField] private AudioClip campfireSound = null;
    [SerializeField] private GameObject targetPrefab = null;
    [SerializeField] private float targetScale = 1.0f;
    [SerializeField] private int pointValue = 10;

    private AudioSource _audioSource;
    private ShootingGalleryService _shootingGalleryService;

    void Start()
    {
        _audioSource = FindObjectOfType<AudioSource>();
        _shootingGalleryService = FindObjectOfType<ShootingGalleryService>();

        if (targetPrefab != null)
        {
            targetPrefab.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
        }
    }

    [ContextMenu("Play Animations")]
    public void PlayAnimations()
    {
        fireParticlesPrefab?.Play();
        smokeParticlesPrefab?.Play();

        StartCoroutine(ParticleTimer());


        _audioSource?.PlayOneShot(campfireSound);

        _shootingGalleryService?.AddToScore(pointValue);
    }

    IEnumerator ParticleTimer()
    {
        yield return new WaitForSeconds(partcilesTime);

        fireParticlesPrefab?.Stop();
        smokeParticlesPrefab?.Stop();
    }
}
