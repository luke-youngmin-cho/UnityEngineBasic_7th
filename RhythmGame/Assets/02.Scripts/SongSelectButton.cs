using UnityEngine;
using UnityEngine.UI;

namespace RhythmGame
{
    public class SongSelectButton : MonoBehaviour
    {
        [SerializeField] private string _songName;

        private void Start()
        {
            GetComponent<Button>()
                .onClick
                .AddListener(() => GameManager.instance.songSelected = _songName);
        }
    }
}
