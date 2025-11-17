using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PauseManager : MonoBehaviour
{
    bool isPaused = false;
    [SerializeField] GameObject pauseText;
    [SerializeField] CameraController cameraController;
    [SerializeField] PlayerController playerController;
    void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerController.enabled = isPaused;
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0.01f : 1;
            // pauseText.SetActive = isPaused; 
            cameraController.ChangeCameraFOV(80);
            pauseText.SetActive(isPaused);
            }
    }
}