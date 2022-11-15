using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateButtonLogic : MonoBehaviour
{
    Client client;

    public void setClient(Client client_) => client = client_; 

    /// <summary>
    /// Button-interactive script used by the player to create units
    /// </summary>
    public void createUnit(string type)
    {
        client.spawnUnit(type);
    }
}
