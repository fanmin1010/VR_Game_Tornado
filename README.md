# 3D-UI-AR-Assignment1

Name: Min Fan   <br>
UNI: mf3084 <br>
Computer Platform: MacBook Pro (Retina, 13-inch, Early 2015) with macOS Sierra (v 10.12.3)  <br>
Project title: 3D-UI-AR-Assignment1 <br>
Project directory overview: <br>
 - Assets/
    - Models/   (including all models used for the project)
        - barn.fbx
        - car.fbx
        - cow.fbx
        - house2.fbx
        - shark.fbx
        - tornado.obj
    - Prefabs/  (empty folder)
    - Scenes/
        - GameScene.unity
    - Scripts/  (contains all the C# scripts)
        - Barn.cs
        - Cam.cs
        - CanvasControl.cs
        - Car.cs
        - Cow.cs
        - DummyTornado.cs
        - FlyCamera.cs
        - House.cs
        - Polygon1.cs
        - Shark.cs
        - Tornado.cs
<h3> Instructions for App Usage</h3>
<br>Instructions for deploying the app: No special instructions. Follow the standard Unity "Build and Run", and make sure the Android app ID is correct.
<br>
Instructions for using the app:
1. Deploy the application to your Android device and open the app (Assignment1).
2. This will first load into the main screen, containing a rotating tornado with some aerial objects, a car and a static house.
3. Clicking on the tornado will stop all the movement and show the tornado control panel. Respectively, clicking on the barn, the shark, the car, and the cow will stop their local movements and show their control panels. In the control panels, the sliders will control their speed or scale depending on the names of the sliders.
4. Clicking on the sky will deselect any selected object. Clicking on the ground will move the tornado and its surrounding objects towards the clicked location. When the tornado is too close to the camera or the tornado is too big, the main camera will move backwards to keep all objects in the view. When the tornado touches the static house, the house will be destroyed. Other objects touching the house have no impact on the house.
5. The bottom right two buttons are used for switching views. Clicking on the car view will show you the view of the driver in the car. In the car view, you can change the camera's pitch and yaw. Clicking on the main-view button on the upper right will transfer you back to the main camera view.
6. There is one more view, which is from the aerial object looking at the car. To activate the view, first click on the aerial object that you want to attach the camera to, and then click on the fly-mode button. It will show you the view from that object looking at the car. Clicking on the main-view button in this view will transfer you back to the main camera view.
Enjoy!
<br>
Demonstration video link:
<br>
Missing features: None. <br>
Bugs in my code and Unity: Not found.   <br>
Asset sources:  <br>
The car.fbx was downloaded from turbosquid.com. (Author: FaTTTTaH) <br>
The tornado.fbx was downloaded from yobi3d.com. <br>
The barn.fbx was downloaded from themovies3d.com and converted to fbx format. <br>
The house2.fbx was downloaded from turbosquid.com. (Author: 3D COR) <br>
The cow.fbx was downloaded from tf3dm.com and converted to fbx format. <br>
The shark.fbx was downloaded from tf3dm.com. <br>
The terrain object was created within Unity and the texture material was downloaded from http://www.m4x0r.com/blog/wp-content/uploads/2010/05/selectblend.png.
