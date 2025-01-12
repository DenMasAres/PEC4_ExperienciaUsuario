using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit;

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
	[SerializeField] private ContinuousMoveProviderBase moveProvider;
	[SerializeField] private ContinuousTurnProviderBase turnProvider;
	private int currentPlayerMoveSpeed = 3;
	private int currentPlayerRotationSpeed = 60;

    [Header("Credits")]
    [SerializeField] private Animator textAnimator;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        PlayCredits();
    }

    #region - AudioMixerController -

    public void IncreaseMasterVolume()
	{
		if (currentMasterVolume < 10)
		{
			currentMasterVolume++;
            audioMixer.SetFloat("MasterVolume",  GetValue(currentMasterVolume));
            masterVolumeText.text = currentMasterVolume.ToString();
        }

	}

	public void DecreaseMasterVolume()
	{
		if (currentMasterVolume > 0)
		{
			currentMasterVolume--;
            audioMixer.SetFloat("MasterVolume", GetValue(currentMasterVolume));
            masterVolumeText.text = currentMasterVolume.ToString();
        }
    }

	public void IncreaseBSOVolume()
	{
		if (currentBSOVolume < 10)
		{
			currentBSOVolume++;
            audioMixer.SetFloat("BSOVolume", GetValue(currentBSOVolume));
            BSOVolumeText.text = currentBSOVolume.ToString();
        }
	}

	public void DecreaseBSOVolume()
	{
		if (currentBSOVolume > 0)
		{
			currentBSOVolume--;
            audioMixer.SetFloat("BSOVolume", GetValue(currentBSOVolume));
            BSOVolumeText.text = currentBSOVolume.ToString();
        }
	}

	public void IncreaseSFXVolume()
	{
		if (currentSFXVolume < 10)
		{
			currentSFXVolume++;
            audioMixer.SetFloat("SFXVolume", GetValue(currentBSOVolume));
            SFXVolumeText.text = currentSFXVolume.ToString();
        }
	}

	public void DecreaseSFXVolume()
	{
		if (currentSFXVolume > 0)
		{
			currentSFXVolume--;
            audioMixer.SetFloat("SFXVolume", GetValue(currentBSOVolume));
            SFXVolumeText.text = currentSFXVolume.ToString();
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
		if(currentPlayerMoveSpeed < 20f)
		{
			currentPlayerMoveSpeed++;
            moveProvider.moveSpeed = currentPlayerMoveSpeed;
            playerSpeedText.text = currentPlayerMoveSpeed.ToString();	

        }
    }

    public void DecreasePlayerSpeed()
    {
        if (currentPlayerMoveSpeed > 1f)
        {
            currentPlayerMoveSpeed--;
            moveProvider.moveSpeed = currentPlayerMoveSpeed;
            playerSpeedText.text = currentPlayerMoveSpeed.ToString();
        }
    }

	public void IncreasePlayerRotationSpeed()
	{
        if(currentPlayerRotationSpeed < 100f)
        {
            currentPlayerRotationSpeed++;
            turnProvider.turnSpeed = currentPlayerRotationSpeed;
            playerRotationText.text = currentPlayerRotationSpeed.ToString();
        }
    }

    public void DecreasePlayerRotationSpeed()
    {
        if (currentPlayerRotationSpeed > 10f)
        {
            currentPlayerRotationSpeed--;
            turnProvider.turnSpeed = currentPlayerRotationSpeed;
            playerRotationText.text = currentPlayerRotationSpeed.ToString();
        }
    }

    #endregion

    public void PlayCredits()
    {
        textAnimator.SetTrigger("StartAnimation");
    }


}
