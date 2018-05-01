//=============================================================================
//
// Chad Johnson
// 1763718
// johns428@mail.chapman.edu
// CPSC-440-01
// Group Project
//
// GameValues stores information from the Start Menu.
//
//=============================================================================

using System;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Stores selected game mode and loadout information.
    /// </summary>
    public class GameValues : MonoBehaviour
    {
        /// <summary>
        /// State of whether environment is on.
        /// </summary>
        public bool environmentOn;

        /// <summary>
        /// Default environmentOn value.
        /// </summary>
        public bool defaultEnvironmentOn;

        [Header("References")]
        /// <summary>
        /// Reference to ReferenceManager.
        /// </summary>
        private ReferenceManager reference;

        /// <summary>
        /// Reference to environment gameobject;
        /// </summary>
        private GameObject environmentGO;

        public enum Difficulty
        {
            Beginner,
            Advanced
        }

        public Difficulty difficulty;

        public Difficulty defaultDifficulty;

        /// <summary>
        /// Find references. Get PlayerPrefs value and set game settings.
        /// </summary>
        private void Awake()
        {
            GetPlayerPrefs();
            reference = FindObjectOfType<ReferenceManager>();
            environmentGO = reference.environmentGO;
            SetAwakeValues();
        }

        /// <summary>
        /// Change and store value for environnmentOn.
        /// </summary>
        /// <param name="environmentOn">New environmentOn value.</param>
        public void SetEnvironmentOn(bool environmentOn)
        {
            this.environmentOn = environmentOn;
            //environmentGO.SetActive(environmentOn);
            if (environmentOn)
            {
                RenderSettings.skybox = reference.spaceSkybox;
            }
            else
            {
                RenderSettings.skybox = reference.defaultSkybox;
            }
        }

        public void SetDifficulty(Difficulty difficulty)
        {
            this.difficulty = difficulty;
        }

        /// <summary>
        /// Set player prefs for gameplay values.
        /// </summary>
        public void SetGameplayPlayerPrefs()
        {
            PlayerPrefs.SetInt("scoreDisplay", Convert.ToInt32(environmentOn));
        }

        /// <summary>
        /// Set all player prefs.
        /// </summary>
        public void SetPlayerPrefs()
        {
            PlayerPrefs.SetInt("environmentOn", Convert.ToInt32(environmentOn));
            PlayerPrefs.SetInt("difficulty", (int)difficulty);
        }

        /// <summary>
        /// Get all player prefs, or default values if prefs not yet set.
        /// </summary>
        private void GetPlayerPrefs()
        {
            environmentOn = Convert.ToBoolean(PlayerPrefs.GetInt("environmentOn", 
                Convert.ToInt32(defaultEnvironmentOn)));
            difficulty = (Difficulty)PlayerPrefs.GetInt("difficulty", (int)defaultDifficulty);
        }

        /// <summary>
        /// Set values for objects/components on awake that do not update independently.
        /// </summary>
        private void SetAwakeValues()
        {
            SetEnvironmentOn(environmentOn);
        }
    }
}
