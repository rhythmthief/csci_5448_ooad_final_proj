using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsObserver : Observer
{
    // singleton
    static GraphicsObserver singleton = new GraphicsObserver();

    static GraphicsFactory graphicsFactory = null;
    //List<GameObject> graphicsObjects = new List<GameObject>();

    static MonoHelper monoHelper;

    private GraphicsObserver() { }

    public static GraphicsObserver getGraphicsObserver() => singleton;

    public void setupGraphicsObserver(GraphicsFactory graphicsFactory_, MonoHelper monoHelper_)
    {
        // set a graphicsfactory reference for use with the singleton
        graphicsFactory = graphicsFactory_;
        monoHelper = monoHelper_;
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
                        graphicsFactory.CreateGraphicalObject(modelParam, e.getCoords1(), e.getColor());
                    }
                    else
                    {
                        // the fighter just moved
                        // delete old corresponding graphical object
                        removeOldObject(e.getMessage()[1] + "_" + string.Join("-", e.getCoords0()));



                        // create new corresponding graphical object
                        graphicsFactory.CreateGraphicalObject(modelParam, e.getCoords1(), e.getColor());
                    }
                }
                else
                {
                    modelParam = 1;
                    // this is a city and it just spawned
                    graphicsFactory.CreateGraphicalObject(modelParam, e.getCoords1(), e.getColor());
                }

                break;

            // unit has died
            case 2:
                // delete old corresponding graphical object
                removeOldObject(e.getMessage()[1] + "_" + string.Join("-", e.getCoords1()));
                break;

            case 3:
                // unit has been selected, update its material
                setUnitSelectedMaterialColor(e.getMessage()[1] + "_" + string.Join("-", e.getCoords1()), Color.yellow);
                break;

            case 4:
                // unit has been deselected
                setUnitSelectedMaterialColor(e.getMessage()[1] + "_" + string.Join("-", e.getCoords1()), e.getColor());
                break;
        }
    }

    // locate a unit on the board and change its color
    void setUnitSelectedMaterialColor(string objName, Color color_)
    {
        GameObject obj = graphicsFactory.transform.Find(objName).gameObject; // find the old object
        obj.GetComponent<Renderer>().material.SetColor("_Color", color_);
    }


    void removeOldObject(string oldName)
    {
        GameObject oldObj = graphicsFactory.transform.Find(oldName).gameObject; // find the old object

        //graphicsObjects.Remove(oldObj); // remove old object reference from the list
        monoHelper.DestroyObjectHelper(oldObj); // destroy old object
        oldObj = null;
    }
}