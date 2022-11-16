using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event
{
    /*
        Event types
            0 - Cell spawned
            1 - Unit moved
            2 - Unit died
    */


    int type;
    int[] coords0; // xyz coordinates related to the event
    int[] coords1; // xyz coordinates related to the event

    // the user is expected to be nice and pass the correct number of messages with each message type
    // see relevant observer implementations 
    string[] message;
    Color color; // for graphics observer


    public Event(int type_, int[] coords0_, int[] coords1_, string[] message_, Color color_)
    {
        type = type_;
        coords0 = coords0_;
        coords1 = coords1_;
        message = message_;
        color = color_;
    }

    public int getType() => type;

    public int[] getCoords0() => coords0;
    public int[] getCoords1() => coords1;
    public string[] getMessage() => message;
    public Color getColor() => color;
}
