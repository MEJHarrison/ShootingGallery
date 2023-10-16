using UnityEngine;

public class CowboyBehavior : MonoBehaviour, ITargetBehavior
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip spinSound = null;
    [SerializeField] private GameObject targetPrefab = null;
    [SerializeField] private float targetScale = 1.0f;
    //[SerializeField] private int pointValue = 10;

    private AudioSource _audioSource;
    //private ShootingGalleryService _shootingGalleryService;

    void Start()
    {
        _audioSource = FindObjectOfType<AudioSource>();
        //_shootingGalleryService = FindObjectOfType<ShootingGalleryService>();

        if (targetPrefab != null)
        {
            targetPrefab.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
        }
    }

    [ContextMenu("Play Animations")]
    public void PlayAnimations()
    {
        Debug.Log("Spin cowbow, spin!");
        if (animator == null)
        {
            Debug.Log("The cowboy has no animator.");
        }
        else
        {
            Debug.Log("The cowboy has an animator!");
        }
        animator?.SetTrigger("TriggerCowboySpin");

        _audioSource?.PlayOneShot(spinSound);

        //_shootingGalleryService?.AddToScore(pointValue);
    }
}
