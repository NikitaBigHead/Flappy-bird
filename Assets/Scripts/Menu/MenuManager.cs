using AppsFlyerSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public AppsFlyerObjectScript appFlyer;
    private void Start()
    {
        appFlyer.onConversionDataSuccess("install_time");
        appFlyer.onConversionDataSuccess("is_first_launch");

    }
}
