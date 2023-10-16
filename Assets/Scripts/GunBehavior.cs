using System.Collections;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private float shootDistance = 10f;
    [SerializeField] public ParticleSystem gunshotParticales = null;
    [SerializeField] public float gunshotParticlesAnimationLength = 2f;
    [SerializeField] private AudioClip gunshotSound = null;

    private AudioSource _audioSource;
    private ParticleSystem _targetHitParticlesInstance = null;
    //private ShootingGalleryService _shootingGalleryService;

    void Start()
    {
        _audioSource = FindObjectOfType<AudioSource>();
        //_shootingGalleryService = FindObjectOfType<ShootingGalleryService>();

        _targetHitParticlesInstance = Instantiate(gunshotParticales, raycastOrigin.position, raycastOrigin.rotation);
    }

    public void Shoot()
    {
        RaycastHit hit;
        //bool gameOver = _shootingGalleryService.GameOver;

        PlayParticleEffects();

        _audioSource?.PlayOneShot(gunshotSound);

        //_shootingGalleryService?.TakeShot();

        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, shootDistance))
        {
            TargetBehavior targetBehavior = hit.collider.GetComponentInParent<TargetBehavior>();

            if (hit.transform.CompareTag("Target"))
            {
                targetBehavior?.HitTarget();
            }

            //if (!gameOver && hit.transform.CompareTag("Target"))
            //{
            //    targetBehavior?.HitTarget();
            //}
            //else if (hit.transform.CompareTag("StartButton"))
            //{
            //    targetBehavior?.HitMenuTarget();
            //}
        }
    }

    private void PlayParticleEffects()
    {
        if (_targetHitParticlesInstance != null)
        {
            _targetHitParticlesInstance.transform.SetPositionAndRotation(raycastOrigin.position, raycastOrigin.rotation);

            _targetHitParticlesInstance.Play();

            StartCoroutine(ParticleTimer());
        }
    }

    private IEnumerator ParticleTimer()
    {
        yield return new WaitForSeconds(gunshotParticlesAnimationLength);

        if (_targetHitParticlesInstance != null)
        {
            _targetHitParticlesInstance.Stop();
        }
    }
}
