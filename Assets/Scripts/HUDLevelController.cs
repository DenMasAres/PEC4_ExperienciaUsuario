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


    #region - AudioMixerController -

    public void IncreaseMasterVolume()
	{

	}

	public void DecreaseMasterVolume()
	{

	}

	public void IncreaseBSOVolume()
	{

	}

	public void DecreaseBSOVolume()
	{

	}

	public void IncreaseSFXVolume()
	{

	}

	public void DecreaseSFXVolume()
	{

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
