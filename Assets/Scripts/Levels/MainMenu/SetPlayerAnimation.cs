using UnityEngine;

[RequireComponent (typeof(Animator))]
public class SetPlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private string _danceAnimationHash = "dance2";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _animator.Play(_danceAnimationHash);
    }
}
