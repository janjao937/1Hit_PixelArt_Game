using UnityEngine;

public class UseAttack : MonoBehaviour
{
    
    [SerializeField] private LayerMask canAtkLayer;
    
    [SerializeField]private Transform atkPos;
    [SerializeField]private float atkRadius;
    [SerializeField]private float atkTimeRange;
    [SerializeField]private float idleTimeRange;

    private PlayerInput playerInput;
    private bool canAtk = true;
   // private BaseAtkState atkState = default;
    float timeTemp;
    public float  AtkTimeRange{get => atkTimeRange;}
    public float  IdleTimeRange{get => idleTimeRange;}

    private void Awake() 
    {
        playerInput = GetComponent<PlayerInput>();
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
        if(!canAtk)return;
        // atkState.UseAtkState();
        OpenATK();
        canAtk = false;
    }

    public void OpenATK()
    {
     
        Collider[] a = Physics.OverlapSphere(atkPos.position,atkRadius,canAtkLayer);
        
        foreach(var b in a){
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
