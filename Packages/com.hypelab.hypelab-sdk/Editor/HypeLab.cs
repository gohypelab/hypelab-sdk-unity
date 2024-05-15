#if UNITY_IOS
using System.Runtime.InteropServices;
using System;
#endif
using UnityEngine;

namespace HypeLabSdk {

public class HypeLab {
#if UNITY_IOS
  [DllImport("__Internal")]
  private static extern void HypeLabSdk_HypeLab_initialize(IntPtr config);
#endif

  public static void Initialize(Config config) {
    if (Application.isEditor)
      return;

#if UNITY_IOS
    HypeLabSdk_HypeLab_initialize(config._config);
#endif

#if UNITY_ANDROID
    AndroidJavaClass hypeLabClass = new AndroidJavaClass("com.hypelab.hypelab_sdk.HypeLab");
    object[] args = new object[1];
    args[0] = config._config;
    hypeLabClass.CallStatic("initialize", args);
#endif
  }
}

}
