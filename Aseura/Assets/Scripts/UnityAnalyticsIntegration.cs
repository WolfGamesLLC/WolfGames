using UnityEngine;
using System.Collections;
using UnityEngine.Cloud.Analytics;

public class UnityAnalyticsIntegration : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        const string projectId = "PROJECTID-GOES-HERE-66fb5cf028d728bb";
        UnityAnalytics.StartSDK(projectId);

    }

}
