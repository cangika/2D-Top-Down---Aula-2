using UnityEngine;
//camelCase is used for class names in C#

public class CameraFollow : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public float followSpeed = 0.1f; // Speed at which the camera follows the player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the position to go to based on the player's position
        Vector3 posToGo = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        // Move the camera towards the player's position
        // Lerp is used to smoothly transition the camera position
        transform.position = Vector3.Lerp(transform.position, posToGo, followSpeed);

    }
}