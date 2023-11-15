<h1 align="center">TumBox</h1>

<p align="center">
  <img src="Editor\Icons\logo.png" width="64">
</p>

<p align="center">
  <a href="#about">About</a> &bull;
  <a href="#How-do-I-install">Install</a> &bull;
  <a href="#releases">Releases</a> &bull;
  <a href="#Special-Thanks">Special Thanks</a> &bull;
  <a href="#Support">Support</a> &bull;
</p>

## About

TumBox is a carefully curated collection of extensions and tools designed to enhance your workflow, streamline development processes, and unlock new possibilities within the Unity environment. 
From time-saving utilities to powerful extensions, TumBox equips developers with a versatile toolkit, making Unity development more efficient and enjoyable. 

**Version**:  1.0.0

**Author**:  Tomek Kierpiec

## How do I install?

<details>
<summary>Install as GIT dependency via Package Manager</summary>

#### Unity 2022.3 or newer

1. Open Package Manager window (Window | Package Manager)
1. Click `+` button on the upper-left of a window, and select "Add package from git URL..."
1. Enter the following URL and click `Add` button

```
https://github.com/Tomek09/TumBox.git?path=/TumBox
```

> **_NOTE:_** To install a concrete version you can specify the version by prepending #v{version} e.g. `#v2.0.0`. For more see [Unity UPM Documentation](https://docs.unity3d.com/Manual/upm-git.html).

#### Unity 2022.2 or earlier

1. Close Unity Editor
1. Open Packages/manifest.json by any Text editor
1. Insert the following line after `"dependencies": {`, and save the file.

    ```json
    "com.atom3y.tumbox": "https://github.com/Tomek09/TumBox.git?path=/TumBox",
    ```

1. Reopen Unity project in Unity Editor

</details>

<details>
<summary>Install via .unitypackage file</summary>

Install the provided Unity package into your Unity project. Located [here](https://github.com/Tomek09/TumBox/releases).

Download the `*.unitypackage` file. Right-click on it in File Explorer and choose "Open in Unity."

</details>

# Releases
- [v1.0.0](https://www.google.pl/)

## Special Thanks
- [Kenney](https://www.kenney.nl/) for lovely icons. 

## Support
Need help?  Found a bug?
  
Send your questions, bug reports: `kierpiec.tomek@gmail.com`

Alternatively, report bugs directly to our [issues page](https://github.com/Tomek09/TumBox/issues)