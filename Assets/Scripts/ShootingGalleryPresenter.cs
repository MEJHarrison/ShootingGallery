using TMPro;
using UnityEngine;

public class ShootingGalleryPresenter : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreText;

    private ShootingGalleryService _shootingGalleryService;

    private void Start()
    {
        _shootingGalleryService = FindObjectOfType<ShootingGalleryService>();

        if (_shootingGalleryService != null)
        {
            _shootingGalleryService.ScoreUpdated += OnScoreUpdated;
            //_shootingGalleryService.AmmoUpdated += OnAmmoUpdated;
        }
    }

    private void OnDestroy()
    {
        if (_shootingGalleryService != null)
        {
            _shootingGalleryService.ScoreUpdated -= OnScoreUpdated;
            //_shootingGalleryService.AmmoUpdated -= OnAmmoUpdated;
        }
    }

    private void OnScoreUpdated(int newScore)
    {
        ScoreText.text = "Score: " + newScore.ToString();
    }

    //private void OnAmmoUpdated(int totalShots, int shotsTaken)
    //{
    //    // Update ammo left text
    //}
}
