using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Video;

namespace RhythmGame
{
    public class NoteSpawnManager : MonoBehaviour
    {
        public static NoteSpawnManager instance;

        public float noteFallingDistance => transform.position.y - noteHitters.position.y;
        public float noteFallingTime => noteFallingDistance / GameManager.instance.speed;
        [SerializeField] private Transform noteHitters;
        private Dictionary<KeyCode, NoteSpawner> _spawners = new Dictionary<KeyCode, NoteSpawner>();
        private Queue<NoteData> _noteQueue;
        private float _timeMark;
        private bool _doSpawn;
        [SerializeField] private VideoPlayer _videoPlayer;
        private bool _isCorouting;
        private Coroutine _coroutine;

        public void StartSpawn()
        {
            if (_isCorouting)
                return;

            _timeMark = Time.time;
            _videoPlayer.clip = SongDataLoader.videoClip;
            _doSpawn = true;

            // Coroutine : 협동루틴, 특정 함수가 끝날때 다른 함수를 호출하도록 협동해서 동작하는 루틴
            // Unity 의 Coroutine : IEnumerator 를 MonoBehaviour 에 등록하면, 
            // 해당 MonoBehaviour 의 Update() 로직이 끝난 후에 등록된 IEnumerator.MoveNext() 를
            // 일괄 호출하는 형태로 비동기루틴을 구현해줌.
            // StartCoroutine() 은 단순히 등록만 하는것이기 때문에 한 프레임에서 다중호출될 위험을 막아줘야함.
            // 주체가되는 MonoBehaviour 가 비활성화/파괴 될 시 코루틴을 지속할 수 없음.
            _isCorouting = true;
            _coroutine = StartCoroutine(PlayVideo(noteFallingTime));
        }

        private IEnumerator PlayVideo(float delay)
        {
            yield return new WaitForSeconds(delay);
            _videoPlayer.Play();
            _isCorouting = false;
        }

        public void Register(NoteSpawner spawner)
        {
            if (_spawners.ContainsKey(spawner.key))
            {
                throw new System.Exception($"[NoteSpawnManager] : {spawner.key} 에 해당하는 노트 생성기는 이미 등록되어있습니다. NoteSpawner 들의 key 값을 확인하세요.");
            }
            else
            {
                _spawners.Add(spawner.key, spawner);
            }
        }

        private void Awake()
        {
            instance = this;
            _noteQueue = new Queue<NoteData>(SongDataLoader.songData.noteList.OrderBy(note => note.time));
        }

        private void Update()
        {
            if(_doSpawn)
                Spawning();
        }

        private void Spawning()
        {
            while (_noteQueue.Count > 0)
            {
                // 맨 앞 노트의 시간이 경과되었는지 확인
                if (_noteQueue.Peek().time <= Time.time - _timeMark)
                {
                    _spawners[_noteQueue.Dequeue().key].Spawn();
                }
                else
                {
                    break;
                }
            }
        }
    }
}
