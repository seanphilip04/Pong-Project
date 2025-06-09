using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PlayerScoreL = 0;
    public int PlayerScoreR = 0;

    //Buat UI Text
    public TMP_Text txtPlayerScoreL;
    public TMP_Text txtPlayerScoreR;
    public GameObject winCon;
    public TMP_Text txtWin;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip winnerSound;
    private AudioSource audioSource;


    public static GameManager instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //Mengisikan nilai integer PlayerScore ke UI
        txtPlayerScoreL.text = PlayerScoreL.ToString();
        txtPlayerScoreR.text = PlayerScoreR.ToString();
        audioSource = GetComponent<AudioSource>();
    }


    //Method penyeleksi untuk menambah score
    public void Score(string wallID)
    {
        bool gameEnded = false;
        if (wallID == "WallL")
        {
            // StartCoroutine(ShakeCam(0.7f));
            PlayerScoreR = PlayerScoreR + 1; //menambah score
            txtPlayerScoreR.text = PlayerScoreR.ToString(); //mengisikan nilai integer PlayerScore ke UI
            gameEnded = ScoreCheck();
        }
        else
        {
            // StartCoroutine(ShakeCam(0.7f));
            PlayerScoreL = PlayerScoreL + 1;
            txtPlayerScoreL.text = PlayerScoreL.ToString();
            gameEnded = ScoreCheck();
        }
        if (!gameEnded)
        {
            audioSource.clip = winSound;
            audioSource.Play();
        }
    }

    public bool ScoreCheck()
    {
        if (PlayerScoreL >= 10 && PlayerScoreL >= (PlayerScoreR + 2))
        {
            audioSource.clip = winnerSound;
            audioSource.Play();
            WinCondition("Left Player Wins!");
            return true;
        }
        else if (PlayerScoreR >= 10 && PlayerScoreR >= (PlayerScoreL + 2))
        {
            audioSource.clip = winnerSound;
            audioSource.Play();
            WinCondition("Right Player Wins!");
            return true;
        }
        return false;
    }

    private void WinCondition(string text)
    {
        winCon.SetActive(true);
        txtWin.text = text;
        Time.timeScale = 0;

    }

}