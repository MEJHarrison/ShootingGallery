using UnityEngine;

public class AirplaneBehavior : MonoBehaviour, ITargetBehavior
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip planeSound = null;
    [SerializeField] private GameObject targetPrefab = null;
    [SerializeField] private float targetScale = 1.0f;
    [SerializeField] private int pointValue = 30;

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
        animator?.SetTrigger("TriggerAirplaneFly");

        _audioSource?.PlayOneShot(planeSound);

        _shootingGalleryService?.AddToScore(pointValue);
    }
}
