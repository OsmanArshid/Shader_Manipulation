# **Dissolve Shader Effect**

This project demonstrates a **Dissolve Shader Effect** implemented in Unity. The shader dynamically dissolves a 3D object (a sphere) using noise, allowing for customizable very slight edge glow and colors.

## **Features**
- A slider for float `[0.0f, 1.0f]` that controls the dissolve percentage:
  - `0.0f` = Fully visible sphere with no glowing edge.
  - `1.0f` = sphere entirely dissolved (transparent).
- A color picker for edge color customization.
- Inspector Adjustable dissolve duration (default is 1 second).
- Slight edge glow is integrated into the shader and controlled via the Unity Shader Graph.
- **Event-driven Dissolve Trigger**: Dissolve process starts only when the user presses the **Spacebar**.

---

## **Technical Details**
The project includes:
1. A **Shader Graph** implementation for the dissolve effect:
   - Noise-based transitions for the dissolve-boundary.
2. A **C# script** (`DissolveController`) for:
   - Triggering the dissolve animation.
   - Updating shader properties dynamically (dissolve amount, edge color).
3. Material customizations exposed to the Unity Inspector:
   - **Dissolve Percentage Slider**: Controls the dissolve progression.
   - **Edge Color Picker**: Customizes the glowing edge color.
   - **Dissolve Time**: Defines the duration of the dissolve animation.

---

## **How to Use**
1. Open the project in **Unity**.
2. Play the scene.
3. **Press the Spacebar** to trigger the dissolve animation for the sphere.
   - The sphere will start dissolving and disappear completely after the dissolve duration ends.
   - Once the sphere is fully dissolved, it gets **destroyed** automatically.

---

## **Why Use Event-Driven Dissolution?**
Triggering the dissolve animation using the **Spacebar** ensures a controlled and intentional animation sequence. Avoiding the awkward behavior of the object dissolving automatically when the scene starts.

---

Feel free to customize this project further and experiment with other Shader Graph effects! 
Copyrights to Usman Arshid
