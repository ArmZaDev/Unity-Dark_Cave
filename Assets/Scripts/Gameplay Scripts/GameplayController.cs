using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField]
    private Slider airSlider, timeSlider;

    [SerializeField]
    private float airMax = 20f, timeMax = 20f;

    private float airValue, timeValue;

    [SerializeField]
    private float airDeductValue = 1f;

    private bool gameRunning;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        timeValue = timeMax;

        timeSlider.maxValue = timeValue;
        timeSlider.minValue = 0f;
        airSlider.value = timeValue;

        airSlider.maxValue = airValue;
        airSlider.minValue = 0f;
        airSlider.value = airValue;

        gameRunning = true;

    }

    private void Update()
    {
        if (!gameRunning)
            return;

        ReduceTime();
        ReduceAir();
    }

    void ReduceTime()
    {
        timeValue -= Time.deltaTime;
        timeSlider.value = timeValue;

        if (timeValue <= 0f)
        {
            // game over
            gameRunning = false;

        }
    }

    void ReduceAir()
    {
        airValue -= airDeductValue * Time.deltaTime;
    }




}//class





