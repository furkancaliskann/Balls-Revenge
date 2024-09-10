using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider soundLevelSlider;
    public float soundLevel;
    AudioSource audioSource;

    public Toggle fpsCounterToggle;
    public bool isFpsCounterOn;

    public Text versionText;


    void Start()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1.0f;

        #if UNITY_EDITOR
        PlayerPrefs.SetInt("Bundle Version", PlayerSettings.Android.bundleVersionCode);
        #endif

        GameObject audioCheck = GameObject.FindGameObjectWithTag("Manager");
        if (audioCheck != null) audioSource = audioCheck.GetComponent<AudioSource>();

        GetSoundLevel();
        GetFpsSetting();

        SetVersionText();
    }

    public void GetSoundLevel()
    {
        soundLevel = PlayerPrefs.GetFloat("Sound Level", 0.5f);

        if(soundLevelSlider != null)
            soundLevelSlider.value = soundLevel;
        if(audioSource != null)
            audioSource.volume = soundLevel;
    }

    public void GetFpsSetting()
    {
        int number = PlayerPrefs.GetInt("FPS Counter", 1);
        
        if(number == 1)
        {
            isFpsCounterOn = true;

            if(fpsCounterToggle != null)
                fpsCounterToggle.isOn = true;
        }
        else
        {
            isFpsCounterOn = false;

            if (fpsCounterToggle != null)
                fpsCounterToggle.isOn = false;
        }
    }

    public void ChangeSoundLevel()
    {
        soundLevel = soundLevelSlider.value;
        PlayerPrefs.SetFloat("Sound Level", soundLevel);

        if (audioSource != null)
            audioSource.volume = soundLevel;
    }

    public void SetFpsSetting()
    {
        isFpsCounterOn = fpsCounterToggle.isOn;

        if (isFpsCounterOn) PlayerPrefs.SetInt("FPS Counter", 1);
        else PlayerPrefs.SetInt("FPS Counter", 0);
    }

    void SetVersionText()
    {
        if (versionText != null)
        versionText.text = "v" + Application.version.ToString() + " (b" + PlayerPrefs.GetInt("Bundle Version", 1) + ")";
    }

    
}
