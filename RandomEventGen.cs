using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventGen : MonoBehaviour
 {
    public bool radioRinging = false;

    public bool CleanUpEventActive = false;

    public float eventInterval = 20.0f;
    private float timer;

    AnswerRadio answerRadio;
    [SerializeField] GameObject radio;

    private Animator animator; 

    // List of predefined events
    private System.Action[] events;

    void Awake()
    {
        answerRadio = radio.GetComponent<AnswerRadio>();
    }

    void Start()
    {

        // Initialize the timer
        timer = eventInterval;

        // Initialize the events array with some example events
        events = new System.Action[]
        {
            Event1,
            Event2,
            Event3
        };
    }

    void Update()
    {

        timer -= Time.deltaTime;

        // Check if the timer has reached zero
        if (timer <= 0)
        {
            // Reset the timer
            timer = eventInterval;

            // Trigger a random event
            TriggerRandomEvent();
        }
        if(answerRadio.Answered == true) {
            radioRinging = false;
        }
        if(answerRadio.CleanUpEventCompleted == true) {
            CleanUpEventActive = false;
        }
    }

    void TriggerRandomEvent()
    {
        // Choose a random event from the array
        int randomIndex = Random.Range(0, events.Length);

        // Invoke the selected event
        events[randomIndex].Invoke();
    }

    // Events:
    void Event1() // CleanUp: Clean up on aisle 4!!!
    {
        Debug.Log("Event 1 triggered!");
        // To make the radio be animated and to tell the radio code it's event is happening.
        if(
            CleanUpEventActive == false
            ) {
                radioRinging = true;
                CleanUpEventActive = true;
        }
    }

    void Event2() // MoneyTime: Counting money for taxes is so fun!!
    {
        Debug.Log("Event 2 triggered!");
        //
        if(
            CleanUpEventActive == false
            ) {
        }
        else{
            CleanUpEventActive = false;
        };
    }

    void Event3() // Complaintus: "Read" the complaints and throw them out
    {
        Debug.Log("Event 3 triggered!");
        //
        if(
            CleanUpEventActive == false
            ) {
        }
        else{
            CleanUpEventActive = false;
        };
    }
}
