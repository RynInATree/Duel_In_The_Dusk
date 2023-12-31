using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudManager : MonoBehaviour
{
    public static AudManager Instance;
    public bool playBackgroundMusic;
    public bool saloonMusic;
    public bool townMusic;
    public bool bankMusic;
    public bool stationMusic;
    public bool horseMusic;
    public bool mainMenusBG;
    public Sound[] musicSounds, sfxSounds, walkSound, dialogueSound;
    public AudioSource musicSource, sfxSource, walkSource, dialogueSource;
    [SerializeField] DialgoueManager dialogueManager;
    [SerializeField] GameObject dialogueObject;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        else
        {
            Destroy(gameObject);
        }
        
    }
    private void Start()
    {
        if (playBackgroundMusic == true)
        {
            if (saloonMusic == true)
                PlayMusic("SaloonBG");
            if (townMusic == true)
                PlayMusic("TownBG");
            if (bankMusic == true)
                PlayMusic("BankBG");
            if (stationMusic == true)
                PlayMusic("stationBG");
            if (horseMusic == true)
                PlayMusic("HorseBG");
            if (mainMenusBG == true)
                PlayMusic("MenusBG");

        }
    }
    public void Update()
    {
        if(SceneManager.GetActiveScene().name == "Combat"){
            if(musicSource.clip.name == "onehorsetown")
            {
                PlayMusic("CombatBG");
            }
        }
        if(SceneManager.GetActiveScene().name != "Combat")
        {
            if(musicSource.clip.name == "lassolady" || musicSource.clip.name != "onehorsetown")
            {
                PlayMusic("TownBG");
            }
        }
        if (SceneManager.GetActiveScene().name == "cutSceneFirst" || SceneManager.GetActiveScene().name == "Train Station" || SceneManager.GetActiveScene().name
            == "Bank Interrior" || SceneManager.GetActiveScene().name == "SampleScene" || SceneManager.GetActiveScene().name == "Saloon")
        {
            dialogueObject = GameObject.FindWithTag("dialogueManager");
            dialogueManager = dialogueObject.GetComponent<DialgoueManager>();
            if (dialogueManager != null)
            {
                if (dialogueManager.muteDialogueAudio == true)
                {
                    dialogueSource.volume = 0;
                }
                else if (dialogueManager.muteDialogueAudio == false)
                {
                    dialogueSource.volume = 1;
                }

            }
            else
            {
                Debug.Log("Cannot find the Dialogue Manager (line 73)");
            }
        }
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Music not found!!!");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Soundeffect not found!!!");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void PlayWalk(string name)
    {
        Sound s = Array.Find(walkSound, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Walk sound not found!!!");
        }
        else
        {
            walkSource.clip = s.clip;
            walkSource.Play();
        }
    }

    public void PlayDialogue(string name)
    {
        Sound s = Array.Find(dialogueSound, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Dialgoue sound not found!!!");
        }
        else
        {
            dialogueSource.clip = s.clip;
            dialogueSource.Play();
        }
    }
}
