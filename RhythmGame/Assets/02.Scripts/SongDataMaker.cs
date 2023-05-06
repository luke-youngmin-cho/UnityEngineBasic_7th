using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace RhythmGame
{
    public class SongDataMaker : MonoBehaviour
    {
        private KeyCode[] _keys = { KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.Space, KeyCode.J, KeyCode.K, KeyCode.L };
        private SongData _songData;
        [SerializeField] private VideoPlayer _videoPlayer;
        private bool _doRecord;

        public void StartRecord()
        {
            if (_doRecord)
                return;

            _songData = new SongData(_videoPlayer.clip.name);
            _videoPlayer.Play();
            _doRecord = true;
        }

        public void StopRecord()
        {
            if (_doRecord == false)
                return;

            _videoPlayer.Stop();
            string dir = UnityEditor.EditorUtility.SaveFilePanelInProject("노래 데이터 저장",
                                                                                                       _songData.name,
                                                                                                       "json",
                                                                                                       String.Empty);
            System.IO.File.WriteAllText(dir, JsonUtility.ToJson(_songData));
            _songData = null;
        }

        private void Update()
        {
            if (_doRecord)
                Recording();
        }

        private void Recording()
        {
            for (int i = 0; i < _keys.Length; i++)
            {
                if (Input.GetKeyDown(_keys[i]))
                {
                    _songData.noteList.Add(CreateNoteData(_keys[i]));
                }
            }
        }

        private NoteData CreateNoteData(KeyCode key)
        {
            NoteData noteData = new NoteData()
            {
                key = key,
                time = (float)Math.Round(_videoPlayer.time, 2)
            };
            return noteData;
        }
    }
}
