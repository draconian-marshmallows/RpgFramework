using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using DraconianMarshmallows.RpgFramework.Structures;
using System.IO;
using System;

namespace DraconianMarshmallows.RpgFramework
{
    public class DataManager : MonoBehaviour
    {
        private const string PLAYER_DATA_FILE_NAME = "/PlayerData.json";
        private Character player;

        private void Start()
        {
            #region DEBUG TEST CODE
            player = new Character
            {
                ChosenClass = Character.Class.Warrior,
                Experience = 100
            };

            string characterJson = SavePlayer();
            Debug.Log("Player saved: " + characterJson + " @ " + Application.persistentDataPath);

            player = LoadPlayer();
            Debug.Log("Loaded player: " + player.Experience);
            #endregion
        }

        private Character LoadPlayer()
        {
            // var fileStream = File.OpenRead(Application.persistentDataPath + PLAYER_DATA_FILE_NAME);
            // string playerJson = fileStream.Read(new byte[fileStream.Length], 0, fileStream.Length as int);
            string playerJson = File.ReadAllText(Application.persistentDataPath + PLAYER_DATA_FILE_NAME);
            Debug.Log("Loaded player data: " + playerJson);
            return JsonConvert.DeserializeObject<Character>(playerJson);
        }

        private string SavePlayer()
        {
            var characterJson = JsonConvert.SerializeObject(player);
            var streamWriter = File.CreateText(Application.persistentDataPath + PLAYER_DATA_FILE_NAME);
            streamWriter.Write(characterJson);
            streamWriter.Flush();
            streamWriter.Close();
            return characterJson;
        }
    }
}
