using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

}
