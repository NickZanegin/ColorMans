using UnityEngine;
using GameAnalyticsSDK;

public class GameAnalyticsEvent : MonoBehaviour
{
    private void Awake()
    {
        GameAnalytics.Initialize();
    }
}
