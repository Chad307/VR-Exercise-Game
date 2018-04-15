//=============================================================================
//
// Chad Johnson
// 1763718
// johns428@mail.chapman.edu
// CPSC-340-01 & CPSC-344-01
// Group Project
//
// SettingsValues saves changes made to settings through settings menu and 
// implements game adjustments using values for sounds, display, etc. Values
// are stored as variables and as PlayerPrefs. Note: PlayerPrefs do not 
// support booleans, so conversion is used between boolean and stored int
// values (0 = false, 1 = true). In addition, audio sources require the
// VolumeAdjustment component in order to update volume level.
//
//=============================================================================

using System;
using UnityEngine;
using UnityEngine.PostProcessing;

namespace Game
{
    /// <summary>
    /// Store settings values.
    /// </summary>
    public class SettingsValues : MonoBehaviour
    {
        /// <summary>
        /// Master volume level.
        /// </summary>
        public float masterVolume;

        /// <summary>
        /// Default master volume level.
        /// </summary>
        public float defaultMasterVolume;

        /// <summary>
        /// References to Volume Adjustment components.
        /// </summary>
        private VolumeAdjustment[] volumeAdjustments;

        /// <summary>
        /// Type of color blind mode.
        /// </summary>
        public ColorBlindMode.Mode colorBlindMode;

        /// <summary>
        /// Default color blind mode.
        /// </summary>
        public ColorBlindMode.Mode defaultColorBlindMode;

        [Header("References")]
        /// <summary>
        /// Reference to ReferenceManager.
        /// </summary>
        private ReferenceManager reference;

        /// <summary>
        /// Find references. Get PlayerPrefs value and set game settings.
        /// </summary>
        private void Awake()
        {
            GetPlayerPrefs();
            reference = FindObjectOfType<ReferenceManager>();
            volumeAdjustments = FindObjectsOfType<VolumeAdjustment>();
            SetAwakeValues();
        }

        /// <summary>
        /// Store value for masterVolume.
        /// </summary>
        /// <param name="masterVolume">New masterVolume value.</param>
        public void SetMasterVolume(float masterVolume)
        {
            this.masterVolume = masterVolume;
            AudioListener.volume = masterVolume;
        }

        /// <summary>
        /// Change and store value for colorBlindMode.
        /// </summary>
        /// <param name="colorBlindMode">New colorBlindMode value.</param>
        public void SetColorBlindMode(ColorBlindMode.Mode colorBlindMode)
        {
            this.colorBlindMode = colorBlindMode;
            reference.colorBlindMode.SetMode(colorBlindMode);
        }

        /// <summary>
        /// Set all player prefs.
        /// </summary>
        public void SetPlayerPrefs()
        {
            PlayerPrefs.SetFloat("masterVolume", masterVolume);
            PlayerPrefs.SetInt("colorBlindMode", Convert.ToInt32(colorBlindMode));
        }

        /// <summary>
        /// Get all player prefs, or default values if prefs not yet set.
        /// </summary>
        private void GetPlayerPrefs()
        {
            masterVolume = PlayerPrefs.GetFloat("masterVolume", defaultMasterVolume);
            colorBlindMode = (ColorBlindMode.Mode)PlayerPrefs.GetInt("colorBlindMode", 
                Convert.ToInt32(defaultColorBlindMode));
        }

        /// <summary>
        /// Set values for objects/components on awake that do not update independently.
        /// </summary>
        private void SetAwakeValues()
        {
            SetColorBlindMode(colorBlindMode);
        }
    }
}
