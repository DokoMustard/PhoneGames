using UnityEngine;
using UnityEngine.UI;

// Advanced touch input MonoBehaviour that spawns balls at touch positions.
public class AdvancedTouchInput : MonoBehaviour
{
    // Reference to touch count Text component in the scene.
    [SerializeField] private Text touchCountText;

    // Reference to ball Prefab in the project assets.
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject capsulePrefab;
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private GameObject cylinderPrefab;



    // Update method is called every frame, if the MonoBehaviour is enabled.
    private void Update()
    {
        // Display the current touch count in the Text component.
        touchCountText.text = "Touch count: " + Input.touchCount;

        // Make sure there are currently touches on the screen (at least one).
        if (Input.touchCount > 0)
        {
            // Obtain all the Touches currently available.
            for (int i = 0; i < Input.touchCount; i++)
            {
                // Get the Touch at index.
                Touch touch = Input.GetTouch(i);

                // Convert the screen position to world position.
                // A Z-coordinate ("10f") is passed to the method to account for offset from the Camera position.
                var worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));

                // Log the touch phase events.
                if (touch.phase == TouchPhase.Began)
                {
                    Debug.Log("TouchPhase.Began: " + i);
                    // Spawn a new ball instance from the prefab each time the screen is touched.
                    

                    if (i == 0)
                        Instantiate(ballPrefab, worldPosition, Quaternion.identity);
                    else if (i == 1)
                        Instantiate(capsulePrefab, worldPosition, Quaternion.identity);
                    else if (i == 2)
                        Instantiate(cubePrefab, worldPosition, Quaternion.identity);
                    else if (i == 3)
                        Instantiate(cylinderPrefab, worldPosition, Quaternion.identity);
                }
            }
        }
    }
}