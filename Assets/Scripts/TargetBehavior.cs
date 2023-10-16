using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float animationDelay = 3f;
    [SerializeField] private ParticleSystem targetHitParticles = null;
    [SerializeField] private float targetHitParticlesTime = .5f;
    [SerializeField] private AudioClip targetHitSound = null;

    private AudioSource _audioSource;
    private bool _targetDown = false;
    private ParticleSystem _targetHitParticlesInstance = null;
    //private ShootingGalleryService _shootingGalleryService;

    void Start()
    {
        _audioSource = FindObjectOfType<AudioSource>();

        if (targetHitParticles != null)
        {
            Quaternion paticleRotation = Quaternion.Euler(90, 0, 0);

            _targetHitParticlesInstance = Instantiate(targetHitParticles, transform.position, transform.rotation * paticleRotation);
        }

        //_shootingGalleryService = FindObjectOfType<ShootingGalleryService>();
    }

    [ContextMenu("Hit Target")]
    public void HitTarget()
    {
        if (!_targetDown)
        {
            _targetDown = true;

            PlaySoundEffectAndParticles();

            animator?.SetTrigger("TriggerTargetDown");

            ITargetBehavior animatedObject = this.gameObject.GetComponentInParent<ITargetBehavior>();

            if (animatedObject != null)
            {
                animatedObject.PlayAnimations();

                StartCoroutine(DelayAnimation());
            }
        }
    }

    //[ContextMenu("Hit Menu Target")]
    //public void HitMenuTarget()
    //{
    //    PlaySoundEffectAndParticles();

    //    _shootingGalleryService.StartGame();
    //}

    private void PlaySoundEffectAndParticles()
    {
        if (_targetHitParticlesInstance != null)
        {
            _targetHitParticlesInstance.Play();

            StartCoroutine(ParticleTimer());
        }

        _audioSource?.PlayOneShot(targetHitSound);
    }

    IEnumerator ParticleTimer()
    {
        yield return new WaitForSeconds(targetHitParticlesTime);

        if (_targetHitParticlesInstance != null)
        {
            _targetHitParticlesInstance.Stop();
        }
    }

    IEnumerator DelayAnimation()
    {
        yield return new WaitForSeconds(animationDelay);

        _targetDown = false;

        if (animator != null)
        {
            animator.SetTrigger("TriggerTargetUp");
        }
    }
}