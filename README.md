# SeniorProject

### Important info
If you want to test the VR-supported version of the game, you must have SteamVR
installed and a compatible VR headset. We designed the game using the Meta
Quest 2, but other headsets that support SteamVR and have a grip and trigger
button on the controllers might work.

Additional Angel players require a standard video game controller (such as Xbox
or PlayStation controllers) to be connected to the PC.

### How to pull
- Create a Unity 3D URP Project
- Once open, close Unity and go to the directory for the project
- Delete the Assets, Packages, and ProjectSettings folders
- Open git in the project folder and type these commands:
> git init
> git remote add SeniorProject https://github.com/WillJoeLee/SeniorProject.git
> git pull SeniorProject

If running the game without VR:
git checkout Game_without_VR

If running the game with VR:
git checkout Game_with_VR

You should now be able to launch the game via the Unity project.

### Authors
- Michel K. Gonzalez
- Felipe Novaes
- William Lee
- Nicholas Gongee
