# bHaptics haptic devices C# plugin
This project helps to utilize haptic devices in Unity and other C# based platform.
Current version is 1.3.0

## Prerequisite
* bHaptics Player has to be installed (Windows)
   * The app can be found in 
   bHaptics webpage: [http://www.bhaptics.com](http://bhaptics.com/)

## How to use codes
* You can download library (Bhaptics.Tac) with nuget manager [Bhaptics.Tac](https://www.nuget.org/packages/Bhaptics.Tac/)
* To install Bhaptics.Tac, run the following command in the Package Manager Console
```
PM> Install-Package Bhaptics.Tac
```
#### or 
    
* Clone the git then apply dll in src folder
```
$ git clone https://github.com/bhaptics/tac-sharp.git
```

## Sample (Unity plug-in)
* Sample source codes for Unity is already available now. 
* For more detail, you can find in [unity-plugin](https://github.com/bhaptics/tactosy-sharp/tree/master/samples/tac-sharp-unity)


## Websocket Communication V2

* request url : /v2/feedbacks

### How to use

 * Import namespaces into classes that will be using haptic feedback.

```
using Bhaptics.Tact;
using Bhaptics.Tact.Unity;
```

* Use HapticPlayer

```C#
var hapticPlayer = new HapticPlayer((connected) =>
{
    Debug.WriteLine("Connected");
});
hapticPlayer.Register(key, "BowShoot.tact");

hapticPlayer.StatusReceived += feedback =>
{
    if (feedback.ActiveKeys.Count <= 0)
    {
        return;
    }
};

Thread.Sleep(100);
hapticPlayer.SubmitRegistered(key);
Thread.Sleep(1000);
hapticPlayer.Dispose();
```
 
    
* Apply more feedback effects: with .tact file
  
>You can create Tact feeback effects via https://designer.bhaptics.com. The .tact files generated by the designer are timeline based haptic feedback effect files.<br/>
You can find more details of the designer [here](http://bhaptics.com/studio.html).<br/>


* Play feedback effects in C# Script: List of PathPoints

```
var motorCount = 2; // number of motors for PathPoint
List<PathPoint> pathPoints = new List<PathPoint>
{
    new PathPoint(x_position, y_position, intensity)
    /* x_position, y_position are floats in
        normalized value (0.0f to 1.0f) beginning from upper left of the device.*/
    , new PathPoint(x_position, y_position, intensity, motorCount)
};
HapticPlayer.Submit("Point", PositionType.Right, pathPoints, duration);
/* duration is a positive integer in milliseconds */
```
	
	
* Play feedback effects in C# Script: DotPoints

```
HapticPlayer.Submit("space", PositionType.Head, new DotPoint(3, 100), 1000);
```


* Play feedback effects in C# Script: Array of Bytes

```
byte[] bytes =
{
    0, 0, 0, 0, 0,
    0, 0, 0, 0, 0,
    0, 0, 100, 100, 0,
    0, 0, 0, 0, 0
}; 
/* Values should be an int (0~100)
/* Each number is the intensity of the point*/
HapticPlayer.Submit("Bytes", PositionType.Right, bytes);
```

* Play registered .tact feedback effects using file names
   * The plugin will automatically register tact files in the specified pathPrefix in [bhaptics Manager], using their file name as a key.

```
/* Just play feedback of Fireball.tact file */
HapticPlayer.SubmitRegistered("Fireball");

/* play feedback of RifleImpact.tact file with counter-clockwise angle and yOffset */
HapticPlayer.SubmitRegisteredVestRotation("RifleImpact", new RotationOption(180f, .5f));

/* play feedback of RifleImpact.tact file with different key. */
HapticPlayer.SubmitRegisteredVestRotation("RifleImpact", "for_backward" new RotationOption(180f, .5f));
HapticPlayer.SubmitRegisteredVestRotation("RifleImpact", "for_front" new RotationOption(0f, .5f));
```

* Check if Device is connected

```
HapticPlayer.IsActive(PositionType.Right)
```


* TurnOff Signal

```
/* Turn off all current Haptic feedback effects */
HapticPlayer.TurnOff();
/* Turn off the specified Haptic feedback effect using its Key string */
HapticPlayer.TurnOff("Fireball");
```

* Check whether some feedback is playing or not

```
/* Return the bool whether 'Fireball' is playing */
bool isFireballFeedbackPlaying = HapticPlayer.IsPlaying("Fireball");
/* Return the bool whether any feedback is playing */
bool isAnyFeedbackPlaying = HapticPlayer.IsPlaying();
```


## Contact
* Official Website: http://www.bhaptics.com/
* E-mail: developer@bhaptics.com
* Issues : https://github.com/bhaptics/tac-sharp/issues/new

Last update of README.md: Apr 4th, 2018.
Last update of README.md: Apr 4th, 2018.

###### Copyright (c) 2018 bHaptics Inc. All rights reserved.
