using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.5f;

    private PlayerInput playerInput;
    private Vector2 inputDir = Vector2.zero;
    private float rotSpeed = default;

    public float MoveSpeed{get=>moveSpeed;set=>moveSpeed = value;}

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.OnMove+= GetInput;
        rotSpeed = moveSpeed * 4;
    }

    private void GetInput(Vector2 input)
    {
        inputDir = input;
        Move();
    }

    private void Move()
    {
      Vector3 moveDir = new Vector3(inputDir.x,0,inputDir.y);
      Quaternion rot = Quaternion.Slerp(transform.rotation , Quaternion.LookRotation(moveDir), rotSpeed * Time.deltaTime);

      transform.position += moveDir * moveSpeed * Time.deltaTime;
      transform.rotation = rot;
    }
}
