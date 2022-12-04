using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 2.5f;
   private float rotSpeed = default;
   private Input input;

   private void OnDisable() 
   {
     input.Disable();
   }
   private void Awake() 
   {
      input = new Input();
      input.Enable();
      rotSpeed = moveSpeed * 4;
      input.Player.ATK.performed += ATK;
   }

   private void Update() 
   {
      Move();
   }

   private void ATK(InputAction.CallbackContext ctx)
   {
        Debug.Log("ATK");
   }
   private void Move()
   {
      Vector2 inPutDir =  input.Player.Move.ReadValue<Vector2>();
      if(inPutDir==Vector2.zero)return;

      Vector3 moveDir = new Vector3(inPutDir.x,0,inPutDir.y);
      Quaternion rot = Quaternion.Slerp(transform.rotation , Quaternion.LookRotation(moveDir), rotSpeed * Time.deltaTime);

      transform.position += moveDir * moveSpeed * Time.deltaTime;
      transform.rotation = rot;
        
   }
}
