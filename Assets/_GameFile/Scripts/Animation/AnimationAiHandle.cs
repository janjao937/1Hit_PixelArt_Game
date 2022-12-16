
using UnityEngine;

public class AnimationAiHandle : MonoBehaviour
{
    [SerializeField] private string walkAnimName = default;
    private Animator anim;
    private void Awake() 
    {
        anim = GetComponent<Animator>();
    }
    public void SetWalkAnim(bool value)
    {
        anim.SetBool(walkAnimName,value);
    }

}
