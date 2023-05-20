using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RhythmGame
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<GameManager>();
                    DontDestroyOnLoad(_instance.gameObject);
                }
                return _instance;
            }
        }
        private static GameManager _instance;

        public enum State
        {
            Idle,
            LoadSongData,
            WaitUntilSongDataLoaded,
            StartGame,
            WaitUntilGameFinished,
            DisplayResult,
            WaitForUser
        }
        public State current;
        public string songSelected
        {
            get
            {
                return _songSelected;
            }
            set
            {
                _songSelected = value;
                onSongSelectedChanged?.Invoke(value);
            }
        }
        private string _songSelected;
        public float speed = 4.0f;
        public event Action<string> onSongSelectedChanged;

        public void PlayGame()
        {
            if (current != State.Idle)
                return;

            current++;
        }

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            switch (current)
            {
                case State.Idle:
                    break;
                case State.LoadSongData:
                    {
                        SongDataLoader.Load(_songSelected);
                        current++;
                    }
                    break;
                case State.WaitUntilSongDataLoaded:
                    {
                        if (SongDataLoader.isLoaded)
                        {
                            SceneManager.LoadScene("Play");
                            current++;
                        }
                    }
                    break;
                case State.StartGame:
                    {
                        NoteSpawnManager.instance.StartSpawn();
                        current++;
                    }
                    break;
                case State.WaitUntilGameFinished:
                    break;
                case State.DisplayResult:
                    break;
                case State.WaitForUser:
                    break;
                default:
                    break;
            }
        }
    }
}
