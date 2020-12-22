using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public static EnergyBar instance { get; private set;}

    public Slider eneryBar;
    public float maxEnergy = 100, currentEnergy;

    //preventing from constantly creating a new waitforseconds every time while loop is called
    private WaitForSeconds regenTime = new WaitForSeconds(0.1f);

    private void Awake()
    {
        //Awake is always call before start.
        instance = this; 
    }

    private void Start()
    {
        currentEnergy = maxEnergy;
        eneryBar.maxValue = maxEnergy;
        eneryBar.value = maxEnergy;
    }

    public void UseFart(float amount)
    {
        if(currentEnergy - amount >= 0)
        {
            currentEnergy -= amount;
            eneryBar.value = currentEnergy;
        }
    }

    public IEnumerator regenEnergy()
    {
        //wait for 0.75 before running the couroutine
        yield return new WaitForSeconds(0.5f);

        //checking energy status
        while(currentEnergy < maxEnergy)
        {
            //regardless what the stamina is, it should fill up at the same rate with this calculation
            currentEnergy += maxEnergy / 100;

            eneryBar.value = currentEnergy;
            yield return regenTime;
        }
    }
}
