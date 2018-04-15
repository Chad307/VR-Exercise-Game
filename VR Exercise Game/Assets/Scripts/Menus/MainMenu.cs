//=============================================================================
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
    /// Contains navigation functions for the Start and Settings menus and prompting of applcation
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
        private MenuTransitionManager menuTransitionManager;

        /// <summary>
        /// Reference to Start Menu.
        /// </summary>
        private GameObject startMenuGO;

        /// <summary>
        /// Reference to Settings Menu.
        /// </summary>
        private GameObject settingsMenuGO;

        /// <summary>
        /// Reference to Menu Audio source.
        /// </summary>
        private AudioSource source;

        /// <summary>
        /// Find references.
        /// </summary>
        private void Awake()
        {
            reference = FindObjectOfType<ReferenceManager>();
            menuTransitionManager = reference.menuTransitionManager;
            startMenuGO = reference.startMenuGO;
            settingsMenuGO = reference.settingsMenuGO;
            source = reference.mainCanvasAudioSource;
        }

        /// <summary>
        /// Start button pressed. Navigate to Start Menu.
        /// </summary>
        public void PressStart()
        {
            source.PlayOneShot(reference.menuSelect);
            menuTransitionManager.Transition(startMenuGO);
        }

        /// <summary>
        /// Settings button pressed. Navigate to Settings Menu.
        /// </summary>
        public void PressSettings()
        {
            source.PlayOneShot(reference.menuSelect);
            menuTransitionManager.Transition(settingsMenuGO);
        }

        /// <summary>
        /// Exit button pressed. Exit application.
        /// </summary>
        public void PressExit()
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