﻿//=============================================================================
//
// Chad Johnson
// 1763718
// johns428@mail.chapman.edu
// CPSC-340-01 & CPSC-344-01
// Group Project
//
// MainMenu controls interactions with the Main Menu.
//
//=============================================================================

using UnityEditor;
using UnityEngine;
using Game;

namespace Menus
{
    /// <summary>
    /// Contains navigation functions for the Start and Options menu and prompting of applcation
    /// exit on Main Menu.
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        /// <summary>
        /// Reference to ReferenceManager.
        /// </summary>
        private ReferenceManager reference;

        /// <summary>
        /// Reference to Menu Transition Manager.
        /// </summary>
        public MenuTransitionManager transitionManager;

        /// <summary>
        /// Reference to Start Menu.
        /// </summary>
        public GameObject startMenuGO;

        /// <summary>
        /// Reference to Extras Menu.
        /// </summary>
        public GameObject extrasMenuGO;

        /// <summary>
        /// Reference to Options Menu.
        /// </summary>
        public GameObject optionsMenuGO;

        /// <summary>
        /// Reference to Menu Audio source.
        /// </summary>
        public AudioSource source;


        private void Awake()
        {
            reference = FindObjectOfType<ReferenceManager>();
        }

        /// <summary>
        /// Start button pressed. Navigate to Start Menu.
        /// </summary>
        public void PressStart()
        {
            source.PlayOneShot(reference.menuSelect);
            transitionManager.Transition(startMenuGO);
        }

        /// <summary>
        /// Extras button pressed. Navigate to Extras Menu.
        /// </summary>
        public void PressExtras()
        {
            source.PlayOneShot(reference.menuSelect);
            transitionManager.Transition(extrasMenuGO);
        }

        /// <summary>
        /// Options button pressed. Navigate to Options Menu.
        /// </summary>
        public void PressOptions()
        {
            source.PlayOneShot(reference.menuSelect);
            transitionManager.Transition(optionsMenuGO);
        }

        /// <summary>
        /// Quit button pressed. Exit application.
        /// </summary>
        public void PressQuit()
        {
            if (Application.isEditor)
            {
                EditorApplication.isPlaying = false;
            }
            else
            {
                Application.Quit();
            }
        }
    }
}