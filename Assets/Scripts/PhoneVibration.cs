using UnityEngine;

public static class PhoneVibration
{
#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject phoneVibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "phoneVibrator");
#else
    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject phoneVibrator;
#endif

    public static void Vibrate(long ms = 250)
    {
        if (IsAndroid())
        {
            Handheld.Vibrate();
        }
        else
        {
            Handheld.Vibrate();
        }
    }

    public static void Cancel()
    {
        if (IsAndroid())
        {
            phoneVibrator.Call("cancel");
        }
    }

    public static bool IsAndroid()
    {
#if UNITY_ANDROID 
        return true;
#else
        return false;
#endif
    }
}
