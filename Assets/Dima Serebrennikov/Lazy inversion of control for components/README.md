# Global common unity service

The technology provides the TheUnityObject.InstanceFromAsset method, which accepts a UnityEngine.Component and returns it, ensuring it's initialized fromt the same asset. This allows for lazy scene construction without explicitly specifying components. This Inversion of Control implementation relies on the Unity engine, using static state instead of recursion.

For example, in assets there is 1 camera that needs to be used in two prefabs, then you can provide this camera in them as asset, and inside each component execute 

`var cam = TheUnityObject.InstanceFromAsset(_yourCamera);`

To get access to the same instance.

Don't forget to update the static state using the TheUnityObject.Refresh method.