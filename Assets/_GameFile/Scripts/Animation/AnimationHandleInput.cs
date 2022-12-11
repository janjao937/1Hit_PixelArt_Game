using UnityEngine;

public class AnimationHandleInput : MonoBehaviour
{
    [SerializeField] private string walkAnimName = default;
    [SerializeField] private string meleeAtkAnimName = default;
    [SerializeField] private string blockAnimName = default;
    private Animator anim;
    private PlayerInput playerInput;
    private UseAttack useAttack;
    private UseBlock useBlock;

    private void Awake() 
    {
        anim= GetComponent<Animator>();
        useAttack = GetComponent<UseAttack>();
        playerInput = GetComponent<PlayerInput>();
        useBlock= GetComponent<UseBlock>();

        playerInput.OnMoveAnim += SetWalkAnim;
        useBlock.OnBlock += SetBlockAtkAnim;
        useAttack.OnAtk += SetTriggerAtkAnim;
    }
    private void SetBlockAtkAnim(bool isBlock)
    {
        anim.SetBool(blockAnimName,isBlock);
    }
    private void SetTriggerAtkAnim()
    {
        anim.SetTrigger(meleeAtkAnimName);
    }
    public void SetWalkAnim(bool isWalk)
    {
        anim.SetBool(walkAnimName,isWalk);
    }
}
