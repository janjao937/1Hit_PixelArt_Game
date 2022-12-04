using System.Collections;
using TMPro;
using UnityEngine;

public class SpeedInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputF;
   [SerializeField] private PlayerMovement playerMovement;

   [SerializeField]private GameObject player;
      private Vector3 firstTransform = default;
private void Awake() {
    
    firstTransform = player.transform.position;
}
   public void ChangeMoveSpeed(){
   float.TryParse(inputF.text,out  float a ) ;
    playerMovement.MoveSpeed = a;
   
   }
   public void ResetPlayerPos(){
    player.transform.position = firstTransform;
   }
}
