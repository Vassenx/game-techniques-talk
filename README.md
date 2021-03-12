# Intermediate Game Dev Techniques Tech Talk
Intermediate Talk on design patterns and JSON data in Unity for GameDev McGill

![Visual of tutorial: Monster instantiated near portal with wave and monster count on bottom left](Images/techniques_tech_talk_visual.png?raw=true "Tutorial Visuals")

Monsters are instantiated on start via object pooling and shown in the image above to come out of a portal. Every time a monster moves off screen, it is returned to the object pool and the next monster in the wave appears out of the portal. The monsters' properties are set up using JSON.

Link to talk slides: https://docs.google.com/presentation/d/1wKwPOv-uBNEBqQ94tQg5VV0hQpyudXin1Ukcb_llkjI/edit?usp=sharing

Also went over an implementation of the Factory pattern using Reflection.
