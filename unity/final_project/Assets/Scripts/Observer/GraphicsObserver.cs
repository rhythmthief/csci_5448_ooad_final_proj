using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsObserver : Observer
{
    // singleton
    static GraphicsObserver singleton = new GraphicsObserver();

    static GraphicsFactory graphicsFactory = null;
    List<GameObject> graphicsObjects = new List<GameObject>();

    private GraphicsObserver() { }

    public static GraphicsObserver getGraphicsObserver() => singleton;

    public void setGraphicsFactory(GraphicsFactory graphicsFactory_)
    {
        // set a graphicsfactory reference for use with the singleton
        graphicsFactory = graphicsFactory_;
    }

    public void update(Event e)
    {
        // determine event type and process
        switch (e.getType())
        {

            // grid cell has spawned
            case 0:
                graphicsFactory.CreateGraphicalObject(0, e.getCoords1(), new Color());
                break;

            // unit has moved
            case 1:
                // the unit that moved can be a fighter that actually moves or a city that just spawned
                if (e.getMessage()[0] == "fighter")
                {
                    // this is a fighter and it just spawned or moved

                }
                else
                {
                    // this is a city and it just spawned
                    graphicsFactory.CreateGraphicalObject(1, e.getCoords1(), new Color());
                }

                break;

        }
    }
}