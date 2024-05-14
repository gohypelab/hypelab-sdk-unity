# HypeLab SDK for Unity

Integrate HypeLab ads in your Android/iOS Unity app.

## Getting Started

### Install HypeLab SDK

Install via [OpenUPM](https://openupm.com/packages/com.hypelab.hypelab-sdk/):

```sh
openupm install com.hypelab.hypelab-sdk
```

You might need to install the [`com.google.external-dependency-manager`](https://github.com/googlesamples/unity-jar-resolver) package if it cannot be automatically resolved as a dependency.

Make sure that the external dependency manager resolves the Android/iOS dependencies (Assets > External Dependency Manager > Android/iOS Resolver).

### Building for iOS

Under the Project Settings > Player > iOS > Other Settings, set the following:

- Scripting Backend: `IL2CPP` (default)
- Target minimum iOS version: `>= 15.0`

Post build, open the generated `.xcworkspace` file in Xcode.
Select the `Unity-iPhone` project, then select the `Unity-iPhone` target. Under the `General` tab, find the `Frameworks, Libraries, and Embedded Content` section.
Add a new entry using the `+` icon and select `HypeLabSdk.xcframework` under Workspace > Pods, and make sure the `HypeLabSdk.xcframework` is set to `Embed & Sign`.

### Building for Android

The HypeLab SDK requires certain player settings to be configured.

Under the Project Settings > Player > Android > Other Settings, set the following:

- Minimum API Level: `>= 24`
- Scripting Backend: `IL2CPP`

### Configure HypeLab SDK

```c_sharp
using HypeLabSdk.Editor;

// ...

Config config = new Config("environment", "propertySlug");
HypeLab.Initialize(config);
```

### Create a Rewarded ad

```c_sharp
Rewarded rewarded = new Rewarded("placementSlug");
rewarded.SetOnReady(OnReady);
rewarded.SetOnError(OnError);
rewarded.SetOnVideoStart(OnVideoStart);
rewarded.SetOnVideoComplete(OnVideoComplete);
rewarded.SetOnVideoError(OnVideoError);
rewarded.SetOnImpression(OnImpression);
rewarded.SetOnClick(OnClick);

// ...

void OnReady() { Debug.Log("Rewarded onReady"); }
void OnError() { Debug.Log("Rewarded onError"); }
void OnVideoStart() { Debug.Log("Rewarded onVideoStart"); }
void OnVideoComplete() { Debug.Log("Rewarded onVideoComplete"); }
void OnVideoError() { Debug.Log("Rewarded onVideoError"); }
void OnImpression() { Debug.Log("Rewarded onImpression"); }
void OnClick() { Debug.Log("Rewarded onClick"); }
```

### Show a Rewarded ad

```c_sharp
rewarded.Show()
```
