#if UNITY_IOS
using System.Runtime.InteropServices;
using System;
#endif
using UnityEngine;

namespace HypeLabSdk {

public class Config {
#if UNITY_IOS
  [DllImport("__Internal")]
  private static extern IntPtr HypeLabSdk_Config_new(string environment, string propertySlug);
  [DllImport("__Internal")]
  private static extern void HypeLabSdk_Config_set__flags(IntPtr config, int flags);
#endif

#if UNITY_IOS
  public IntPtr _config;
#endif
#if UNITY_ANDROID
  public AndroidJavaObject _config;
#endif

  public string environment;
  public string propertySlug;

  public Config(string environment, string propertySlug) {
    this.environment = environment;
    this.propertySlug = propertySlug;

    if (Application.isEditor)
      return;

#if UNITY_IOS
    this._config = HypeLabSdk_Config_new(this.environment, this.propertySlug);
    HypeLabSdk_Config_set__flags(this._config, 0x2 | 0x4);
#elif UNITY_ANDROID
    object[] args = new object[2];
    args[0] = environment;
    args[1] = propertySlug;
    this._config = new AndroidJavaObject("com.hypelab.hypelab_sdk.Config", args);
    this._config.Call("set__flags", 0x1 | 0x4);
#endif
  }
}

}
