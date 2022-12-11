using UnityEngine;
using System;

public class UseAttack : MonoBehaviour
{
    
    [SerializeField] private LayerMask canAtkLayer;
    
    [SerializeField]private Transform atkPos;
    [SerializeField]private float atkRadius;
    [SerializeField]private float atkTimeRange = 1.4f;
    [SerializeField]private float idleTimeRange;

    private PlayerInput playerInput;
    private bool canAtk = true;

    private float timeTemp;
    private PlayerCharacter playerCharacter;

    public event Action OnAtk;
    public float  AtkTimeRange{get => atkTimeRange;}
    public float  IdleTimeRange{get => idleTimeRange;}
    public bool CanAtk {get=>canAtk;}

    private void Awake() 
    {
        playerInput = GetComponent<PlayerInput>();
        playerCharacter = GetComponent<PlayerCharacter>();

       playerInput.OnAtk += UseAtk;
       timeTemp = atkTimeRange;
    }

    private void Update() 
    {
        CoolDown();
    }
   
    private void CoolDown()
    {
        if(canAtk)return;

        if(atkTimeRange>=0)
        {
            atkTimeRange-= Time.deltaTime;
            return;
        }
        canAtk = true;
        atkTimeRange = timeTemp;
    }
    public void UseAtk()
    {
        if(!playerCharacter.UseStaminaAtk()) return;
        if(!canAtk)return;
        // atkState.UseAtkState();
        OnAtk?.Invoke();
        OpenATK();
        canAtk = false;
    }

    public void OpenATK()
    {
        Collider[] a = Physics.OverlapSphere(atkPos.position,atkRadius,canAtkLayer);
        
        foreach(var b in a)
        {
            b.gameObject.SetActive(false);
        }

    }
    public void OffATK()
    {
        Debug.Log("off");      
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if(atkPos==null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(atkPos.position,atkRadius);
    }
#endif
}
