using UnityEngine;

public class AnimationHandleInput : MonoBehaviour
{
    [SerializeField] private string walkAnimName = default;
    private Animator anim;
    private PlayerInput playerInput;

    private void Awake() 
    {
         anim= GetComponent<Animator>();
         playerInput = GetComponent<PlayerInput>();
         playerInput.OnMoveAnim += SetWalkAnim;
      
    }
    public void SetWalkAnim(bool isWalk)
    {
        anim.SetBool(walkAnimName,isWalk);
    }
}
