#if UNITY_IOS
using AOT;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;
#elif UNITY_ANDROID
using UnityEngine;
#endif

namespace HypeLabSdk {

public class Rewarded {
#if UNITY_IOS
  [DllImport("__Internal")]
  private static extern IntPtr HypeLabSdk_Rewarded_new(string placementSlug);
  [DllImport("__Internal")]
  private static extern void HypeLabSdk_Rewarded_show(IntPtr rewarded);
  [DllImport("__Internal")]
  private static extern void HypeLabSdk_Rewarded_setOnReady(IntPtr rewarded, EventCallback_iOS onReady);
  [DllImport("__Internal")]
  private static extern void HypeLabSdk_Rewarded_setOnError(IntPtr rewarded, EventCallback_iOS onError);
  [DllImport("__Internal")]
  private static extern void HypeLabSdk_Rewarded_setOnReward(IntPtr rewarded, EventCallback_iOS onReward);
  [DllImport("__Internal")]
  private static extern void HypeLabSdk_Rewarded_setOnVideoStart(IntPtr rewarded, EventCallback_iOS onVideoStart);
  [DllImport("__Internal")]
  private static extern void HypeLabSdk_Rewarded_setOnVideoComplete(IntPtr rewarded, EventCallback_iOS onVideoComplete);
  [DllImport("__Internal")]
  private static extern void HypeLabSdk_Rewarded_setOnVideoError(IntPtr rewarded, EventCallback_iOS onVideoError);
  [DllImport("__Internal")]
  private static extern void HypeLabSdk_Rewarded_setOnImpression(IntPtr rewarded, EventCallback_iOS onImpression);
  [DllImport("__Internal")]
  private static extern void HypeLabSdk_Rewarded_setOnClick(IntPtr rewarded, EventCallback_iOS onClick);

  private IntPtr _rewarded;

  private delegate void EventCallback_iOS(IntPtr rewarded);
#elif UNITY_ANDROID
  private AndroidJavaObject _rewarded;
#endif

  public delegate void EventCallback();

  public string placementSlug;

  public Rewarded(string placementSlug) {
    this.placementSlug = placementSlug;

    if (Application.isEditor)
      return;

#if UNITY_IOS
    this._rewarded = HypeLabSdk_Rewarded_new(this.placementSlug);
#elif UNITY_ANDROID
    AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
    object[] args = new object[] { unityActivity, placementSlug };
    this._rewarded = new AndroidJavaObject("com.hypelab.hypelab_sdk.Rewarded", args);
#endif
  }

  public void Show() {
    if (Application.isEditor)
      return;

#if UNITY_IOS
    HypeLabSdk_Rewarded_show(_rewarded);
#elif UNITY_ANDROID
    _rewarded.Call("show");
#endif
  }

  public void SetOnReady(EventCallback onReady) {
    if (Application.isEditor)
      return;

#if UNITY_IOS
    RewardedEventRouter_iOS.SetCallback(_rewarded, EventType_iOS.Ready, onReady);
    HypeLabSdk_Rewarded_setOnReady(_rewarded, Rewarded.OnReady);
#elif UNITY_ANDROID
    _rewarded.Call("setOnReady", new Function0_Android(onReady));
#endif
  }

  public void SetOnError(EventCallback onError) {
    if (Application.isEditor)
      return;

#if UNITY_IOS
    RewardedEventRouter_iOS.SetCallback(_rewarded, EventType_iOS.Error, onError);
    HypeLabSdk_Rewarded_setOnError(_rewarded, Rewarded.OnError);
#elif UNITY_ANDROID
    _rewarded.Call("setOnError", new Function0_Android(onError));
#endif
  }

  public void SetOnReward(EventCallback onReward) {
    if (Application.isEditor)
      return;

#if UNITY_IOS
    RewardedEventRouter_iOS.SetCallback(_rewarded, EventType_iOS.Reward, onReward);
    HypeLabSdk_Rewarded_setOnReward(_rewarded, Rewarded.OnReward);
#elif UNITY_ANDROID
    _rewarded.Call("setOnReward", new Function0_Android(onReward));
#endif
  }

  public void SetOnVideoStart(EventCallback onVideoStart) {
    if (Application.isEditor)
      return;

#if UNITY_IOS
    RewardedEventRouter_iOS.SetCallback(_rewarded, EventType_iOS.VideoStart, onVideoStart);
    HypeLabSdk_Rewarded_setOnVideoStart(_rewarded, Rewarded.OnVideoStart);
#elif UNITY_ANDROID
    _rewarded.Call("setOnVideoStart", new Function0_Android(onVideoStart));
#endif
  }

  public void SetOnVideoComplete(EventCallback onVideoComplete) {
    if (Application.isEditor)
      return;

#if UNITY_IOS
    RewardedEventRouter_iOS.SetCallback(_rewarded, EventType_iOS.VideoComplete, onVideoComplete);
    HypeLabSdk_Rewarded_setOnVideoComplete(_rewarded, Rewarded.OnVideoComplete);
#elif UNITY_ANDROID
    _rewarded.Call("setOnVideoComplete", new Function0_Android(onVideoComplete));
#endif
  }

  public void SetOnVideoError(EventCallback onVideoError) {
    if (Application.isEditor)
      return;

#if UNITY_IOS
    RewardedEventRouter_iOS.SetCallback(_rewarded, EventType_iOS.VideoError, onVideoError);
    HypeLabSdk_Rewarded_setOnVideoError(_rewarded, Rewarded.OnVideoError);
#elif UNITY_ANDROID
    _rewarded.Call("setOnVideoError", new Function0_Android(onVideoError));
#endif
  }

  public void SetOnImpression(EventCallback onImpression) {
    if (Application.isEditor)
      return;

#if UNITY_IOS
    RewardedEventRouter_iOS.SetCallback(_rewarded, EventType_iOS.Impression, onImpression);
    HypeLabSdk_Rewarded_setOnImpression(_rewarded, Rewarded.OnImpression);
#elif UNITY_ANDROID
    _rewarded.Call("setOnImpression", new Function0_Android(onImpression));
#endif
  }

  public void SetOnClick(EventCallback onClick) {
    if (Application.isEditor)
      return;

#if UNITY_IOS
    RewardedEventRouter_iOS.SetCallback(_rewarded, EventType_iOS.Click, onClick);
    HypeLabSdk_Rewarded_setOnClick(_rewarded, Rewarded.OnClick);
#elif UNITY_ANDROID
    _rewarded.Call("setOnClick", new Function0_Android(onClick));
#endif
  }

#if UNITY_IOS
  [MonoPInvokeCallback(typeof(EventCallback_iOS))]
  private static void OnReady(IntPtr rewarded) {
    RewardedEventRouter_iOS.InvokeCallback(rewarded, EventType_iOS.Ready);
  }

  [MonoPInvokeCallback(typeof(EventCallback_iOS))]
  private static void OnError(IntPtr rewarded) {
    RewardedEventRouter_iOS.InvokeCallback(rewarded, EventType_iOS.Error);
  }

  [MonoPInvokeCallback(typeof(EventCallback_iOS))]
  private static void OnReward(IntPtr rewarded) {
    RewardedEventRouter_iOS.InvokeCallback(rewarded, EventType_iOS.Reward);
  }

  [MonoPInvokeCallback(typeof(EventCallback_iOS))]
  private static void OnVideoStart(IntPtr rewarded) {
    RewardedEventRouter_iOS.InvokeCallback(rewarded, EventType_iOS.VideoStart);
  }

  [MonoPInvokeCallback(typeof(EventCallback_iOS))]
  private static void OnVideoComplete(IntPtr rewarded) {
    RewardedEventRouter_iOS.InvokeCallback(rewarded, EventType_iOS.VideoComplete);
  }

  [MonoPInvokeCallback(typeof(EventCallback_iOS))]
  private static void OnVideoError(IntPtr rewarded) {
    RewardedEventRouter_iOS.InvokeCallback(rewarded, EventType_iOS.VideoError);
  }

  [MonoPInvokeCallback(typeof(EventCallback_iOS))]
  private static void OnImpression(IntPtr rewarded) {
    RewardedEventRouter_iOS.InvokeCallback(rewarded, EventType_iOS.Impression);
  }

  [MonoPInvokeCallback(typeof(EventCallback_iOS))]
  private static void OnClick(IntPtr rewarded) {
    RewardedEventRouter_iOS.InvokeCallback(rewarded, EventType_iOS.Click);
  }
#endif
}

#if UNITY_IOS
enum EventType_iOS { Ready, Error, Reward, VideoStart, VideoComplete, VideoError, Impression, Click }

class RewardedEventRouter_iOS {
  private static Dictionary<Tuple<IntPtr, EventType_iOS>, Rewarded.EventCallback> _callbacks =
      new Dictionary<Tuple<IntPtr, EventType_iOS>, Rewarded.EventCallback>();

  public static void SetCallback(IntPtr rewarded, EventType_iOS type, Rewarded.EventCallback callback) {
    if (callback != null)
      _callbacks[GetKey(rewarded, type)] = callback;
    else
      _callbacks.Remove(GetKey(rewarded, type));
  }

  public static void InvokeCallback(IntPtr rewarded, EventType_iOS type) {
    Rewarded.EventCallback _callback = _callbacks[GetKey(rewarded, type)];
    if (_callback != null)
      _callback();
  }

  private static Tuple<IntPtr, EventType_iOS> GetKey(IntPtr rewarded, EventType_iOS type) {
    return new Tuple<IntPtr, EventType_iOS>(rewarded, type);
  }
}
#endif

#if UNITY_ANDROID
class Function0_Android : AndroidJavaProxy {
  private Rewarded.EventCallback _callback;
  public Function0_Android(Rewarded.EventCallback callback) : base("kotlin.jvm.functions.Function0") {
    this._callback = callback;
  }

  public void invoke() { _callback(); }
}
#endif

}
