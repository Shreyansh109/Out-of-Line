
using UnityEngine;
using System.Collections;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    public Camera mainCamera;

    public float spawnDistance = 1f;

    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;

    // Four possible spawn heights
    public float[] spawnHeights = { 1f, 2f, 3f, 4f };

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        StartCoroutine(SpawnBirds());
    }

    IEnumerator SpawnBirds()
    {
        while (true)
        {
            float waitTime = Random.Range(
                minSpawnTime, maxSpawnTime);

            yield return new WaitForSeconds(waitTime);

            SpawnBird();
        }
    }

    void SpawnBird()
    {
        // Get the camera's left edge in world coordinates
        float cameraZDistance = Mathf.Abs(
            mainCamera.transform.position.z);

        Vector3 leftEdge = mainCamera.ViewportToWorldPoint(
            new Vector3(0f, 0.5f, cameraZDistance));

        // Choose one of the four heights randomly
        int index = Random.Range(0, spawnHeights.Length);

        Vector3 spawnPosition = new Vector3(
            leftEdge.x - spawnDistance,
            spawnHeights[index],
            0f
        );

        Instantiate(birdPrefab, spawnPosition, Quaternion.identity);
    }
}
