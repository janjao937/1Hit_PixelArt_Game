using UnityEngine;
using System.Collections;

public class DashSkill : MonoBehaviour
{
  
    [SerializeField] private float force = 5;
    private PlayerInput playerInput;
    private Rigidbody rb;
  

    private void Awake() 
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        playerInput.OnUseSkill += Dash;
    }
    private void Dash()
    {
       
        rb.AddForce(transform.forward*force,ForceMode.Impulse);
        //transform.position += transform.forward*20;

    }


 /* 

    public float T;
    private float t = 0;
 
     private void Dash()
    {
       
        //rb.AddForce(transform.forward*force,ForceMode.Impulse);
       
        StartCoroutine(PlayerDash());
       
    }

    IEnumerator PlayerDash()
    {
        
        while(t < T)
        {
            transform.position += transform.forward*Time.deltaTime;
            t++;

        }
        
         yield return new WaitForSeconds(0.1f);
         t = 0;


    }
    */

}
