using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Buttons : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ActiveAnimation()
    {
        _animator.SetTrigger("On");
    }
}
