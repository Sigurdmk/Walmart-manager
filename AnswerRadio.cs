using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class AnswerRadio : MonoBehaviour, IInteractable
{
    RandomEventGen randomEventGen;
    [SerializeField] GameObject player;

    private Animator animator;
    [SerializeField] Transform targetPosition;

    public float answeringDuration = 15f;
    private float answeringTimer;

    public float answerDuration = 30f;
    private float answerTimer;

    public bool FailedAnswer = false;

    public bool Answered = false;
    public bool Waited = false;
    public bool CleanUpEventCompleted = false;

    void Awake()
    {
        randomEventGen = player.GetComponent<RandomEventGen>();
    }

    void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
        answeringTimer = answeringDuration;
        answerTimer = answerDuration;
    }

    void Update() {
        // To begin the radio ringing
        if(randomEventGen.radioRinging == true) {
            animator.ResetTrigger("UnAnswerRadioAnimation");
            animator.SetTrigger("RadioIsRinging");
            CleanUpEventCompleted = false;
            answerTimer -= Time.deltaTime;
            if(answerTimer <= 0) {
                FailedToCleanUp();
            }
        }
        // When the radio is clicked, we begin the wait time the task takes
            if(Answered == true) {
                answeringTimer -= Time.deltaTime;
                if(answeringTimer <= 0) {
                    Waited = true;
                    answeringTimer = answeringDuration;
                    Debug.Log("Timer reached 0");
                }
            // When done with the CleanUp Task
                if(Waited == true) {
                    animator.SetTrigger("UnAnswerRadioAnimation");
                    Answered = false;
                    Waited = false;
                    randomEventGen.radioRinging = false;
                    CleanUpEventCompleted = true;
                    animator.ResetTrigger("RadioIsRinging");
                }
            }
    }

    // To interact with the Radio 
    public void Interact() {
       animator.SetTrigger("AnswerRadioAnimation");
       Debug.Log(Random.Range(0, 100));
       Answered = true;
       Debug.Log(Answered);
       Debug.Log(randomEventGen.radioRinging);
    }
    
    public void FailedToCleanUp() {
        Debug.Log("YOU FAILED TO CLEAN UP");
        animator.ResetTrigger("RadioIsRinging");
        Answered = false;
        Waited = false;
        randomEventGen.radioRinging = false;
        animator.SetTrigger("UnAnswerRadioAnimation");
     }
}