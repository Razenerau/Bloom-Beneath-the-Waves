using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlacementSaveData : MonoBehaviour
{
    public static PlacementSaveData Instance;
    public Dictionary<string, Dictionary<Vector3Int, GameObject>> OccupiedTilesByScene = new();
    public PlayerModel PlayerModel;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe to avoid errors
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("New scene loaded: " + scene.name);
        // Put your "per-scene" logic here (e.g., finding a new Player object)

        string sceneName = SceneManager.GetActiveScene().name;

        if (!PlacementSaveData.Instance.OccupiedTilesByScene.TryGetValue(sceneName, out var cells))
            return;

        ObjectPlacementController.Instance.RebuildObject(cells);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Get the index of the currently active scene
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Load the scene with the next index (current + 1)
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex - 1);
        }
    }
}
