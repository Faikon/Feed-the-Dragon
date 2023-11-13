using UnityEngine;

public class GoldAreaView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private SfxClips _sfxClips;

    private GoldArea _goldArea;

    private void Awake()
    {
        _goldArea = GetComponentInParent<GoldArea>();
    }

    private void OnEnable()
    {
        _goldArea.GoldTransfered += OnGoldTransfered;
    }

    private void OnDisable()
    {
        _goldArea.GoldTransfered -= OnGoldTransfered;
    }

    private void OnGoldTransfered()
    {
        _sfxClips.PlayGetGold();
        _particleSystem.Play();
    }
}
