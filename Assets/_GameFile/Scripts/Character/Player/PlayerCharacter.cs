using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
   private bool isDeath;
   [Header("Player Item")]
   [SerializeField] private StaminaItem staminaItem;
   [Space]
   [SerializeField]private float currentStamina;
   private (float min,float max) minMaxStamina;

    private void Awake() {

        try
        {
        SetUpStamina(staminaItem.MaxStamina);
        }
        catch
        {
            gameObject.SetActive(false);
        }
        
    }
    private void Update() 
    {
        IncreseStamina();
    }
    private void SetUpStamina(float max)
    {
        minMaxStamina.min = 0;
        minMaxStamina.max = max;
        currentStamina = max;

    }
   public bool UseStaminaAtk()//For Block/Atk
   {
        if(currentStamina< staminaItem.AtkStamina) return false;
        if(minMaxStamina.min >= currentStamina) return false;
        currentStamina-= staminaItem.AtkStamina;
        return true;
   }
   public bool UseStaminaBlock()//For Block/Atk
   {
        if(currentStamina< staminaItem.BlockStamina) return false;
        if(minMaxStamina.min >= currentStamina) return false;
        currentStamina-= staminaItem.BlockStamina*Time.deltaTime;
        return true;
   }

   private void IncreseStamina()//For IncreseStamina per sec
   {
        if(minMaxStamina.max <= currentStamina) return;

        currentStamina += staminaItem.IncreseStaminaPerSecound * Time.deltaTime;

   }
}
