using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
   [SerializeField] private bool isBlockInput = false;
   private Input input;

   public Action<Vector2> OnMove;
   public Action OnAtk;

   public Action<bool> OnMoveAnim;

   private void OnDisable() 
   {
     input.Disable();
   }

   private void Awake() 
   {
      input = new Input();
      input.Enable();

      input.Player.Block.performed += Block;
      input.Player.Block.canceled += UnBlock;
      input.Player.ATK.performed += ATK;
   }
   private void Update() 
   {
      MoveInput();
   }
   

   private void ATK(InputAction.CallbackContext ctx)
   {
      Debug.Log("ATK");
      //Stamina Codition
      OnAtk?.Invoke();
   }
   private void Block(InputAction.CallbackContext ctx)
   {
      Debug.Log("Block");
      //Stamina Codition
      isBlockInput = true;
   }
    private void UnBlock(InputAction.CallbackContext ctx)
   {
      Debug.Log("UnBlock");
      isBlockInput = false;
   }

   private void MoveInput()
   {
      Vector2 inPutDir =  input.Player.Move.ReadValue<Vector2>();
      if(inPutDir==Vector2.zero)
      {
         OnMoveAnim?.Invoke(false);
         return;
      }
      OnMove?.Invoke(inPutDir);
      OnMoveAnim?.Invoke(true);

   }

 
}
