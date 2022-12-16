using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum State
{
    SetUp,
    UPDATE,
    BUSSY,
}
public class BaseWave 
{
   protected BaseWave nextWaveState;
   protected Wave wave;
   private State state;

   public BaseWave(Wave wave)
   {
    this.wave = wave;
    state = State.SetUp;


   }

   public BaseWave RunGameWave()
   {
    if(state == State.SetUp) SetUp();
    else if(state == State.UPDATE) Update();
    else if(state == State.BUSSY)
    {
        Bussy();
        return nextWaveState;
    }  
    return this;
   }

   protected virtual void SetUp()
   {
    state = State.UPDATE;
   }
   protected virtual void Update()
   {
    state = State.BUSSY;
   }
   protected virtual void Bussy()
   {
    nextWaveState = new BaseWave(this.wave);
   }
}
