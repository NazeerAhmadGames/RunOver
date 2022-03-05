using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;

public class HapticManager : MonoBehaviour
{
    public static HapticManager instance;
    private void Awake()
    {
        instance = this;
    }
    public void playTheLightHaptics()
    {
        MMVibrationManager.Haptic(HapticTypes.LightImpact);
    }
    public void playTheSoftHaptics()
    {
        MMVibrationManager.Haptic(HapticTypes.SoftImpact);

    }
    public void playTheHeavyHaptics()
    {
        MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
    }
}
