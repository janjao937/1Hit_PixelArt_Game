using UnityEngine;
public enum AtkRunState
{
    START,
    UPDATE,
    CHANGE_STATE,
}
public class BaseAtkState 
{
    private UseAttack useAttack = default;

    private float timeRange;
    private float timeTemp = 0;
    private AtkRunState atkRunState = AtkRunState.START;

    protected BaseAtkState nextAtkState = default;

    public BaseAtkState(UseAttack atkObject)
    {
        useAttack = atkObject;
        timeRange = useAttack.AtkTimeRange;
    }

    public void UseAtkState()//For out side //Run state
    {
       
     if(atkRunState ==AtkRunState.START)
     {
        StartAtk();
     }
     else if (atkRunState ==AtkRunState.UPDATE)
     {
        UpdateAtk();
     }
     else if(atkRunState == AtkRunState.CHANGE_STATE)
     {
        ChangeAtkState();
     }

    }

    protected virtual void StartAtk()
    {
        //Set Up

        //OpenSlash
        useAttack.OpenATK();
        //ChangeState
        atkRunState = AtkRunState.UPDATE;
    }
    protected virtual void UpdateAtk()
    {

        //CountTime
        if(timeRange>=timeTemp)
        {
            timeRange-= Time.deltaTime;
            return;
        }

        //OffSlash
        useAttack.OffATK();
        //ChangeState
        atkRunState = AtkRunState.CHANGE_STATE;
    }

    protected virtual void ChangeAtkState()
    {
        useAttack.OffATK();
    }

}
