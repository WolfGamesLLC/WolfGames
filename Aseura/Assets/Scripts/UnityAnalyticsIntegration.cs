using UnityEngine;
using System.Collections;
using UnityEngine.Cloud.Analytics;

public class UnityAnalyticsIntegration : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        const string projectId = "15b1a224-bd8f-4d59-b887-3ac17099b137";
        UnityAnalytics.StartSDK(projectId);

    }

}
