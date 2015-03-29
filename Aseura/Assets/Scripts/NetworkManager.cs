using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour 
{
    #region Members

    private PhotonView photonView;
    private Queue<string> messages;
    private int MAX_MESSAGE_COUNT = 6;

    #endregion

    #region Editor Properties

    [SerializeField]
    private Text connectionText;
 
    [SerializeField]
    private InputField messageWindow;

    #endregion

    #region Properties


    #endregion

    #region Initialization

    /// <summary>
    /// initialize the NetworkManager object
    /// </summary>
    void Start () 
    {
        photonView = GetComponent<PhotonView>();
        messages = new Queue<string>(MAX_MESSAGE_COUNT);

//        PhotonNetwork.logLevel = PhotonLogLevel.Full; 	// allow us to see every thing photon does
        PhotonNetwork.ConnectUsingSettings("0.8");		// connect us to a room 

        StartCoroutine("UpdateConnectionString");		// log connection information to the screen
    }

    #endregion

    #region Methods

    /// <summary>
    /// Start a thread to monitor the connection status of the network
    /// </summary>
    /// <returns>IEnumerator rquired return from a Coroutine</returns>
    IEnumerator UpdateConnectionString()
    {
        while (true)
        {
            connectionText.text = PhotonNetwork.connectionStateDetailed.ToString(); // allow the demo to see the current network state
            yield return null;
        }
    }

    // Update is called once per frame
	void Update () 
    {

    }

    #endregion
}
