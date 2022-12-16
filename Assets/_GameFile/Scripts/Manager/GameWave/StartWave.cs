using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWave : BaseWave
{    
    
    private float time = 0;
    private float timeForChangeState = 2;
    public StartWave(Wave wave) : base(wave)
    {
       
    }

    protected override void SetUp()
    {
        base.SetUp();
    }

    protected override void Update()
    {
        if(time < timeForChangeState)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
            Debug.Log("StartWave");
            base.Update();
        }
        
    }

    protected override void Bussy()
    {
        
        nextWaveState = new StartWave(this.wave);
    }
}
