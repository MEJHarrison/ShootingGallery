# ShootingGallery
 A basic shooting gallery for VR

How to use this project.

These instructions were made with Unity Version: 2021.3.30f1.  If you have a different version of Unity, things might be slightly different.

##### Heading level 5
Create a new Unity project
    Make sure to create a 3D (URP) project

Add XR Interaction Toolkit from Unity
    Go to Window -> Package Manager.  You want Packages: Unity Registry.  Search for XR Interaction Toolkit.  Install it.
    It will want to restart the editor which is fine

Go back to the XR Interaction Toolkit
    Install the Start Assets under Samples

Add the XR Interaction Setup prefab to your scene.
    It should be under Assets/Samples/XR Interaction Toolkit/2.4.3/Start Assets/Prefabs

Remove Main Camera

Edit -> Project settings
    Under XR Plugin Management (not XR Plug-in Management), click Install XR Plugin Management
    Once installed, click the Open XR checkbox.  Fix the issues.
    Under OpenXR, add Interaction Profiles.  Here's a good list:
        Oculus Touch Controller Profile
        Valve Index Controller Profile
        Microsoft Motion Controller Profile
        HTC Vive Controller Profile

Add Audio Source

Import Shooting Gallery prefab

Convert to URP

Add prefab to scene
    It will want to install Text Mesh Pro.  Click the Import TMP Essentials
    Close the TMP Important window

In the scene, navigate to Shooting Gallery -> Guns -> Water Pistol
    * Add an XR Grab Interactible to the Water Pistol
    * Under Rigidbody, change Collision Detection from Discrete to Continuous Dynamic
    * Under XR Grab Interable, make the following settings:
        * Movement Type should be switched from Instantaneous to Velocity Tracking
        Check Smooth Position
        Check Smooth Rotation
        Check Use Dynamic Attach
        Expand Interactible Events
            Under Activate, click the plus button, then drag the Water Pistol from your scene to where it says None (Object)
            Where it says No Function, navigate to GunBehavior -> Shoot

            If you want picking up the gun to automatically start the game, add this:
            Under Select, click the plus button, then drag the Shooting Gallery from your scene to where it says None (Object)
            Where it says No Function, navigate to ShootGalleryService -> StartGame

