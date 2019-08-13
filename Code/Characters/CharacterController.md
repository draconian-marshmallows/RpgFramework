# Player AI Character Controller #

## Install/Integration
Installing and setting up the character-controller requires embedding 
DraconianMarshmallows/RpgFramework and creating/adding a prefab-variant 
based on prefabs from the framework. 

This requires the following steps: 
- Add our RpgFramework repository as a Git submodule to your project 
under a directory named `DraconianMarshmallows/RpgFramework` in your 
project's Assets directory. 

- Create a prefab-variant from our character controller prefab and add 
it to your project. 
```
This prefab can be found at the following path in the Assets directory 
`DraconianMarshmallows/RpgFramework/Prefabs/Characters/AIThirdPersonPlayerContainer`.
An example of this variant is in the same directory and called 
`AIThirdPersonPlayerContainerExample`.
```

- Next a character model/rig needs to be embedded in the prefab-variant. 
To do this enter prefab-mode to edit the variant outside of a scene. 
`This model should have a humanoid-rig for Mechanime to apply humanoid 
animations to. `

- Add the following components to the model if they're not already 
present: `Animator`, `NavMeshAgent`, and `ThirdPersonCharacter`. 

- Now add references to the components by selecting the prefabs' root 
GameObject and dragging the model into the three corresponding slots in 
the inspector for the AI Character Controller component. 

- Now you can save the prefab-variant and drop it into your scene. 
