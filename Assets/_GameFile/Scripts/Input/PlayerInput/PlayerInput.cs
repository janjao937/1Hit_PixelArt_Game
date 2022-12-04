using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
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

      input.Player.ATK.performed += ATK;
      
   }
   private void Update() 
   {
      MoveInput();
   }
   

   private void ATK(InputAction.CallbackContext ctx)
   {
        Debug.Log("ATK");
        OnAtk?.Invoke();
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
