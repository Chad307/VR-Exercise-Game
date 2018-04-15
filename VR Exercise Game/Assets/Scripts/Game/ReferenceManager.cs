
using UnityEngine;
using Menus;

namespace Game
{
    public class ReferenceManager : MonoBehaviour
    {
        [Header("Game")]
        public GameValues gameValues;

        [Header("Environment")]
        public GameObject environmentGO;

        [Header("Settings")]
        public SettingsValues settingsValues;
        public ColorBlindMode colorBlindMode;

        [Header("Audio")]
        public AudioSource mainCanvasAudioSource;
        public AudioClip menuSelect;
        public AudioClip menuBack;
        public AudioClip uiHover;

        [Header("Player")]
        public GameObject playerGO;
        public GameObject cameraGO;

        [Header("Menus and UI")]
        public MenuTransitionManager menuTransitionManager;
        public GameObject mainCanvasGO;
        public GameObject mainMenuGO;
        public GameObject settingsMenuGO;
        public GameObject startMenuGO;
    }
}
