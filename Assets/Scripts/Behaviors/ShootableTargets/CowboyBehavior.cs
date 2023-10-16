using UnityEngine;

public class CowboyBehavior : MonoBehaviour, ITargetBehavior
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip spinSound = null;
    [SerializeField] private GameObject targetPrefab = null;
    [SerializeField] private float targetScale = 1.0f;
    [SerializeField] private int pointValue = 20;

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
        animator?.SetTrigger("TriggerCowboySpin");

        _audioSource?.PlayOneShot(spinSound);

        _shootingGalleryService?.AddToScore(pointValue);
    }
}
