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
        int modelParam = 0; // selector for the created model

        // determine event type and process
        switch (e.getType())
        {

            // grid cell has spawned
            case 0:
                graphicsFactory.CreateGraphicalObject(modelParam, e.getCoords1(), new Color());
                break;

            // unit has moved
            case 1:
                // the unit that moved can be a fighter that actually moves or a city that just spawned
                if (e.getMessage()[0] == "fighter")
                {
                    if (e.getMessage()[1] == "melee")
                        modelParam = 2;
                    else if (e.getMessage()[1] == "ranged")
                        modelParam = 3;
                    else
                        modelParam = 4;

                    // this is a fighter and it just spawned or moved
                    if (e.getCoords0() == null)
                    {
                        // the fighter just spawned
                        graphicsFactory.CreateGraphicalObject(modelParam, e.getCoords1(), new Color());
                    }
                    else
                    {
                        // the fighter just moved
                        // delete old corresponding graphical object


                        // create new corresponding graphical object
                        graphicsFactory.CreateGraphicalObject(modelParam, e.getCoords1(), new Color());
                    }
                }
                else
                {
                    modelParam = 1;
                    // this is a city and it just spawned
                    graphicsFactory.CreateGraphicalObject(modelParam, e.getCoords1(), new Color());
                }

                break;

        }
    }
}