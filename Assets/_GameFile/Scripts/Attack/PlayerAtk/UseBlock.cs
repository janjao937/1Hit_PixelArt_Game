using System.Collections;
using System;
using UnityEngine;

public class UseBlock : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerCharacter player;
    public event Action<bool> OnBlock;
    public bool isBlock = false;
    
     private void Awake() 
    {
       playerInput = GetComponent<PlayerInput>();
       player = GetComponent<PlayerCharacter>();

       playerInput.Onblock += Block;
    }
    private void Update() 
    {
        if(!isBlock)return;
        if(!player.UseStaminaBlock())
        {
            this.isBlock = false;
            OnBlock?.Invoke(this.isBlock);
            return;
        }
    }
    private void Block(bool isBlock)
    {
        if(!player.UseStaminaBlock())
        {
            this.isBlock = false;
            OnBlock?.Invoke(this.isBlock);
            return;
        }
        this.isBlock = isBlock;

        OnBlock?.Invoke(this.isBlock);
    }
}
