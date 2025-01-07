using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HUDLevelController : MonoBehaviour
{
	[Header("Audio")]
	[SerializeField] private AudioMixer audioMixer;
	private int currentMasterVolume = 10;
	private int currentBSOVolume = 10;
	private int currentSFXVolume = 10;

    private void Update()
    {

		if(Input.GetKeyDown(KeyCode.P))
		//print(Mathf.Log10(1) * 20);
		audioMixer.SetFloat("Volume", Mathf.Log10(0.1f) * 20);
	}


    #region - AudioMixerController -

    public void IncreaseMasterVolume()
	{
		if (currentMasterVolume < 10) currentMasterVolume ++ ;
	}

	public void DecreaseMasterVolume()
	{
		if (currentMasterVolume > 0) currentMasterVolume -- ;
	}

	public void IncreaseBSOVolume()
	{
		if (currentBSOVolume < 10) currentBSOVolume++;
	}

	public void DecreaseBSOVolume()
	{
		if (currentBSOVolume > 0) currentBSOVolume--;
	}

	public void IncreaseSFXVolume()
	{
		if (currentSFXVolume < 10) currentSFXVolume++;
	}

	public void DecreaseSFXVolume()
	{
		if (currentSFXVolume > 0) currentSFXVolume--;
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

	public void PlayCredits()
	{

	}

    #endregion

}
