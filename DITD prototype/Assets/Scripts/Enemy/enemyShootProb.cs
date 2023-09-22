using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShootProb : MonoBehaviour
{
    public float timer;
    public SkillCheck skillCheck; //reference to the skill check script
    public checkScript CheckScript; 
    public int probOfShooting;
    public int probOfLanding;
    public int fireIndex;
    // Start is called before the first frame update
    void Start()
    {
        fireIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckScript.playerShotAcc == false)
        {
            if (skillCheck.fireTime == true && fireIndex == 0)
            {
                timer = timer + Time.deltaTime;
                if (timer > 1.5f)
                {
                    probOfShooting = Random.Range(0, 100);
                    if (probOfShooting < 50)
                    {
                        enemyFire();
                        fireIndex++;
                    }
                    else if (probOfShooting > 50)
                    {
                        fireIndex = 0;
                        timer = 0;
                        Debug.Log("Enemy did not decide to shoot this time, maybe soon");
                    }
                }
            }
        }

    }

    private void enemyFire()
    {
        probOfLanding = Random.Range(0, 100);
        if(probOfLanding < 60)
        {
            Debug.Log("PlayerGotShot");
            skillCheck.playerDeath();
            fireIndex++;
        }
        else
        {
            Debug.Log("Miss!");
            fireIndex = 0;
            timer = 0;
        }
    }
}