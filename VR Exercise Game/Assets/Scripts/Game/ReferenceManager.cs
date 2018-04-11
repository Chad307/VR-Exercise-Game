
using UnityEngine;

namespace Game
{
    public class ReferenceManager : MonoBehaviour
    {
        [Header("Systems and Managers")]
        public GameSettings gameSettings;



        [Header("Options")]
        public OptionsValues optionsValues;

        public ColorBlindMode colorBlindMode;


        [Header("Shared Sound Effects")]
        public AudioClip menuSelect;

        public AudioClip menuBack;

        public AudioClip uiHover;


        [Header("Player")]
        public GameObject player;


        [Header("Menus and UI")]
        public GameObject mainMenu;



    }
}
