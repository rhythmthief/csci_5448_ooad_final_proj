using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event
{
    /*
        Event types
            0 - Unit spawned
    */


    int type;
    int[] coords; // xyz coordinates related to the event

    // the user is expected to be nice and pass the correct number of messages with each message type
    // see relevant observer implementations 
    string[] message;


    public Event(int type_, int[] coords_, string[] message_)
    {
        type = type_;
        coords = coords_;
        message = message_;
    }
}
