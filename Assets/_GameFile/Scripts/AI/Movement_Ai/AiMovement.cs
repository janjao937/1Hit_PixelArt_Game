using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    [SerializeField] private GameObject nextTarget;
    [SerializeField] private float lookSpeed = 2;
    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private float stopDistance = 1.5f;

    private AnimationAiHandle aiAnim;
    private Vector3 direction;
    private GameObject target;
    private void Awake() 
    {
        aiAnim = GetComponent<AnimationAiHandle>();
    }
    void Update()
    {
        Move(nextTarget);
        //aiAnim.SetFloatWalkAnim(Vector3.Distance(transform.position , target.transform.position));
    }

    private void Move(GameObject target)
    {
        if(this.target != target) 
        {
          this.target = target;
        }
        GetTargetDirection();//Get Direction
        LookTarget(direction);//Rotate
        MoveToTarget(direction);//Move
    }

    private void GetTargetDirection()
    {
        direction = (target.transform.position - transform.position).normalized;
    }
    private void MoveToTarget(Vector3 dir)
    {
        float distance = Vector3.Distance(transform.position , target.transform.position);
        if(distance > stopDistance)
        {
            transform.position += direction * moveSpeed * Time.deltaTime;
           // transform.forward = direction; //Look Direction
            aiAnim.SetWalkAnim(true);
        }
        else aiAnim.SetWalkAnim(false);
    }
    private void LookTarget(Vector3 dir)
    {
        Quaternion rotateGoal = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation,rotateGoal,lookSpeed);
    }
    

}
