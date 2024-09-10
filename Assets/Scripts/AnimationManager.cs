using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    WaveManager waveManager;

    public Animation cameraAnim;
    public Animation wallAnim;
    public Animation waveAnim;

    void Start()
    {
        waveManager = GetComponent<WaveManager>();
    }
    public void PlayCameraAnimation()
    {
        cameraAnim.Stop();
        cameraAnim.Play("CameraShake");
    }

    public void RaiseWallInvoke()
    {
        Invoke(nameof(RaiseWall), 2.4f);
    }

    void RaiseWall()
    {
        wallAnim.Stop();
        wallAnim.Play("UpWall");
    }
    public void LowerWall()
    {
        wallAnim.Stop();
        wallAnim.Play("DownWall");
    }

    public void NewWave()
    {
        waveAnim.Stop();
        waveAnim.Play("WaveOut");
        Invoke(nameof(WaveIn), 1.5f);
    }

    public void WaveIn()
    {     
        waveAnim.Stop();
        waveAnim.Play("WaveIn");
        waveManager.UpdateLevelName();
    }
    
}
