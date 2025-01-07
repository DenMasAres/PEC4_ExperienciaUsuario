using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class HUDLevelController : MonoBehaviour
{
	[Header("Audio")]
	[SerializeField] private AudioMixer audioMixer;
	[SerializeField] private TextMeshProUGUI masterVolumeText;
	[SerializeField] private TextMeshProUGUI BSOVolumeText;
	[SerializeField] private TextMeshProUGUI SFXVolumeText;
    private int currentMasterVolume = 10;
	private int currentBSOVolume = 10;
	private int currentSFXVolume = 10;

	[Header("PlayerStats")]
    [SerializeField] private TextMeshProUGUI playerSpeedText;
    [SerializeField] private TextMeshProUGUI playerRotationText;



    #region - AudioMixerController -

    public void IncreaseMasterVolume()
	{
		if (currentMasterVolume < 10)
		{
			currentMasterVolume++;
            audioMixer.SetFloat("MasterVolume",  GetValue(currentMasterVolume));
        }

	}

	public void DecreaseMasterVolume()
	{
		if (currentMasterVolume > 0)
		{
			currentMasterVolume--;
            audioMixer.SetFloat("MasterVolume", GetValue(currentMasterVolume));
        }
	}

	public void IncreaseBSOVolume()
	{
		if (currentBSOVolume < 10)
		{
			currentBSOVolume++;
            audioMixer.SetFloat("BSOVolume", GetValue(currentBSOVolume));
        }
	}

	public void DecreaseBSOVolume()
	{
		if (currentBSOVolume > 0)
		{
			currentBSOVolume--;
            audioMixer.SetFloat("BSOVolume", GetValue(currentBSOVolume));
        }
	}

	public void IncreaseSFXVolume()
	{
		if (currentSFXVolume < 10)
		{
			currentSFXVolume++;
            audioMixer.SetFloat("SFXVolume", GetValue(currentBSOVolume));
        }
	}

	public void DecreaseSFXVolume()
	{
		if (currentSFXVolume > 0)
		{
			currentSFXVolume--;
            audioMixer.SetFloat("SFXVolume", GetValue(currentBSOVolume));
        }
	}

	private float GetValue(float value)
	{
		return Remap(value, 0f, 10f, -80f, 0f);
    }

    private float Remap(float value, float inputMin, float inputMax, float outputMin, float outputMax)
    {
        return (value - inputMin) / (inputMax - inputMin) * (outputMax - outputMin) + outputMin;
    }


    #endregion


    #region - CharacterParameters

    public void IncreasePlayerSpeed()
	{

	}

    public void DecreasePlayerSpeed()
    {

    }

	public void IncreasePlayerRotationSpeed()
	{

	}

    public void DecreasePlayerRotationSpeed()
    {

    }

    #endregion

    public void PlayCredits()
    {

    }


}
