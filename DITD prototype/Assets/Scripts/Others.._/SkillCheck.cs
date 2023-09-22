using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;

public class SkillCheck : MonoBehaviour
{
    public Slider mSlider;
    public bool index; //this is used to determine which direction the marker faces
    public float markerSpeed;
    public bool playerShot;
    public float playerAccuracy;
    public GameObject drawText;
    public GameObject reloadingText;
    
    
    //varibles to control the draw function (timers mainly)
    private float timeDuration = 11f;
    public int drawTime;
    private float timer;
    private bool timerActive;
    public float xPositionShot;
    public GameObject shotArea;
    public bool fireTime; //should be the same value as the canvas group this is made for other scripts to reference
    int drawIndex = 0; //so the draw function doesn't run constantly

    //variables and etc for reload function
    public bool timerReloadTime;
    float timerReload;
    public checkScript CheckScript;


    [SerializeField] private CanvasGroup canvasGroup; //will also work as a variable which keeps track of when its draw time
    // Start is called before the first frame update
    void Start()
    {
        drawText.SetActive(false);
        reloadingText.SetActive(false);
        drawTime = Random.Range(2, 10);
        canvasGroup.alpha = 0;
        fireTime = false;
        mSlider.value = 100;
        playerShot = false; //did they shoot?
        index = false;
        timerActive = true;
        generateShotArea();
        timerReloadTime = false;


    }

    public void generateShotArea() //controls shoot area (orange thing)
    {
        xPositionShot = Random.Range(-88.7f, 88.518f);
        shotArea.GetComponent<RectTransform>().anchoredPosition = new Vector3(xPositionShot, 0.8536f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive == true) //controls when the draw will happen
        {
            timer = timer + Time.deltaTime;
        }
        if(timer >= drawTime)
        {
            timerActive = false;
            Draw();
        }

        if (canvasGroup.alpha == 1 || fireTime == true) //draw just happened 
        {
            if (Input.GetKeyDown("space")) //Player shoot
            {
                playerShot = true;
            }

            if (mSlider.value == mSlider.maxValue)
            {
                index = true;
            }
            if (mSlider.value == mSlider.minValue)
            {
                index = false;
            }
        }

        //controls the main reload mechanic
        if (timerReloadTime == true)
        {
            timerReload = timerReload + Time.deltaTime;
            reloadingText.SetActive(true);
            if (timerReload >= 1.5)
            {
                reloadingText.SetActive(false);
                drawIndex = 0;
                Draw();
                timerReload = 0;
                timerReloadTime = false;
                playerShot = false;
                CheckScript.shotIndex = 0;
            }
        }
    }
    void FixedUpdate()
    {

        if(playerShot == false && canvasGroup.alpha == 1) //control the marker movement at a fixed rate
        {
            if (index == false)
            {
                mSlider.value += markerSpeed;
            }
            else if (index == true)
            {
                mSlider.value -= markerSpeed;
            }
        }
    }

    public void Draw()
    {
        if(drawIndex == 0)
        {
            drawText.SetActive(true);
            canvasGroup.alpha = 1;
            fireTime = true;
            drawIndex=1;
        }

    }

    public void hideDraw()
    {
        drawText.SetActive(false);
        canvasGroup.alpha = 0;
        fireTime = false;
    }

    public void playerDeath()
    {
        canvasGroup.alpha = 0;
        drawText.SetActive(false);
        fireTime = false;
        Debug.Log("Player Has fallen");
    }

}