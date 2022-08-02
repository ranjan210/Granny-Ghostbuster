using UnityEngine;
public class UnityAndroidVibrator : MonoBehaviour
{
#if UNITY_ANDROID || UNITY_EDITOR
    private static AndroidJavaObject plugin = null;
#endif

    bool isVibrate = true;

    // Use this for initialization
    void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        plugin = new AndroidJavaClass("com.Clawon.GrannYghostbuster.UnityAndroidVibrator").CallStatic<AndroidJavaObject>("instance");
#endif

    if(PlayerPrefs.GetInt("vibration")==1){
        isVibrate = true;
    }
    else{
        isVibrate = false;
    }
    }


    /// <summary>
    /// <para>Vibrates For Given Amount Of Time.</para>
    /// <para>1 sec = 1000 Millseconds :)</para>
    /// </summary>
    /// <param name="DurationInMilliseconds">Duration in milliseconds.</param>
    public void VibrateForGivenDuration(int DurationInMilliseconds)
    {
        if (plugin == null) { return; }
        if (isVibrate)
        {
            plugin.Call("VibrateForGivenDuration", DurationInMilliseconds);
        }

    }

    /// <summary>
    /// Stoping All Vibrate.
    /// </summary>
    public void StopVibrate()
    {
        if (plugin == null) { return; }

        plugin.Call("StopVibrate");
    }


    /// <summary>
    /// <para>Customs Vibrate or Vibration with Pattern.</para>
    /// <para>Start without a delay</para>
    /// <para>Each element then alternates between vibrate, sleep, vibrate, sleep...</para>
    /// <para>long[] Pattern = {0, 100, 100, 300};</para>
    /// </summary>
    /// <param name="Pattern">Pattern.</param>
    public void CustomVibrate(long[] Pattern)
    {
        if (plugin == null) { return; }

        plugin.Call("CustomVibrate", Pattern);
    }

    public bool switchVibration()
    {
        isVibrate = !isVibrate;
        return isVibrate;
    }


}