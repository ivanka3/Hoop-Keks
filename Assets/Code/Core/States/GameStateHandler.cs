using System;
using System.IO;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Code.Core
{
    public class GameStateHandler : MonoBehaviour
    {
        [SerializeField]private GameState _gameState;

        private static GameStateHandler _gameStateHandler;
        public GameState State => _gameState;

        public static GameStateHandler StateHandler => _gameStateHandler;

        private void Awake()
        {
            if (_gameStateHandler == null)
            {
                _gameStateHandler = this;
            }
        }
        

        private void Start()
        {
            LoadGameState();
            
        }

        private void OnDestroy()
        {
            SaveGameState();
        }

        public void SaveGameState()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("gameState.dat", FileMode.Create))
            {
                formatter.Serialize(fs, _gameState);
                Debug.Log("Объект сериализован");
            }
        }

        private void LoadGameState()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            if (File.Exists("gameState.dat"))
            {
                using (FileStream fs = new FileStream("gameState.dat", FileMode.Open))
                {
                    GameState gameState =  (GameState)formatter.Deserialize(fs);
                    if (gameObject != null)
                    {
                        _gameState = gameState;
                    }
                    else
                    {
                        throw new Exception("opa gg");
                    }
                }
            }
            else
            {
                GameState gameState = new GameState();
                _gameState = gameState;
                SaveGameState();
            }
            
        }
    }
}