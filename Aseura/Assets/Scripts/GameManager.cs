using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    /// <summary>
    /// Create a new world
    /// </summary>
    public void CreateWorld(Text newWorldName)
    {
        RoomManager.LoadRoom(newWorldName.ToString());
    }
}
