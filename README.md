Flat Colorizer: 
https://www.youtube.com/watch?v=fp6x5F2Dqe4&t=1s

Download the package from the Unity assets store: https://assetstore.unity.com/packages/tools/utilities/flat-colorizer-254539


Model UV Preparation Most low poly models like Synty Studios models for example are ready to use but if you are using a costum model follow the steps down.


1.open the model in Blender

2.make sure to give the model a unique name

3.open the UV editing window and select the faces that you want them to be in one color

![241161879-b570c7e0-9376-4dd9-8073-b9d3c61fe951](https://github.com/zr77hh/FlatColorizer/assets/76841804/6ef570ad-9575-4f58-ab9f-b03eff30ac33)

4.new scale them down to zero

![241161965-9dffb9f8-0bd0-4b6a-b872-307bedb06c2b](https://github.com/zr77hh/FlatColorizer/assets/76841804/8dc4da64-f0da-4b57-ab52-2620c9aaaf57)

5.repeat the process for each color you want

![241162083-fd7a47df-cc4d-4d3c-a349-ab70e6b133c8](https://github.com/zr77hh/FlatColorizer/assets/76841804/a32ae393-dfc6-43d4-ba72-e601d26164c4)

in this case, we have 3 colors

6.new import the model back to unity and start using it

after having the models ready you can follow the following steps to flat colorize them.

How To Flat Colorize The Models

1.select the object that you want to flat colorize

![241162830-2a9488f7-004f-4f03-bfcf-e34186bf7653](https://github.com/zr77hh/FlatColorizer/assets/76841804/331a44a7-2501-4a77-a9cf-6aadd7776ac4)

2.add a FlatColorizer component by either clicking on the Add Flatcolorizer button or by adding the component manually

![241162972-fa18e141-8f19-43ca-9179-f71bf7b4caa5](https://github.com/zr77hh/FlatColorizer/assets/76841804/896b6d12-6733-4699-bc4c-5f86206cf7ce)

3.start adjusting the colors

![241163092-41aabb92-5c7e-458e-84e9-e59f20c6057f](https://github.com/zr77hh/FlatColorizer/assets/76841804/7df1fd12-47cc-4232-878f-c5fa18494f47)

Important Notes:

1.every mesh you want to flat colorize should have a unique name since this plugin uses the name to save the mesh data.

2.you should not delete or change the directory or change the name of the FlatColorizerData folder unless you know what you are doing since that might risk losing mesh data so make sure to make a backup before playing around with the FlatColorizerData folder. but in normal you should not worry about this folder at all.
