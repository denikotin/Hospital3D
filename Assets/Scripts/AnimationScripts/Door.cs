using UnityEngine;

public class Door : MonoBehaviour
{
    private bool _isOpened;
    [SerializeField] Animator _animator;

    public void Open()
    {
        _isOpened = !_isOpened;
        _animator.SetBool("isOpened", _isOpened);
    }
}
