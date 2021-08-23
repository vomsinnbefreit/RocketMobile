using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

	[SerializeField] public RocketStats stats;

	[SerializeField] public FuelUpgrade fuelUpgrade;

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
			LoadGame();
		}
		else if(instance != this)
		{
			Destroy(this);
		}

		DontDestroyOnLoad(this);
	}

	void OnApplicationQuit()
	{
		SaveGame();
	}

	public bool IsSaveFile()
	{
		return Directory.Exists(Application.persistentDataPath + "/game_save");
	}

	public void SaveGame()
	{
		if (!IsSaveFile())
		{
			Directory.CreateDirectory(Application.persistentDataPath + "/game_save");
		}

		BinaryFormatter bf = new BinaryFormatter();

		FileStream file = File.Create(Application.persistentDataPath + "/game_save/stats.txt");
		var json = JsonUtility.ToJson(stats);
		bf.Serialize(file, json);
		file.Close();

		FileStream sFile = File.Create(Application.persistentDataPath + "/game_save/fuelUpgrade.txt");
		var sjson = JsonUtility.ToJson(fuelUpgrade);
		bf.Serialize(sFile, sjson);
		file.Close();
	}

	public void LoadGame()
	{
		if (!IsSaveFile())
		{
			return;
		}

		BinaryFormatter bf = new BinaryFormatter();

		if(File.Exists(Application.persistentDataPath + "/game_save/stats.txt"))
		{
			FileStream file = File.Open(Application.persistentDataPath + "/game_save/stats.txt", FileMode.Open);
			JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), stats);
			file.Close();
		}

		if (File.Exists(Application.persistentDataPath + "/game_save/fuelUpgrade.txt"))
		{
			FileStream file = File.Open(Application.persistentDataPath + "/game_save/fuelUpgrade.txt", FileMode.Open);
			JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), fuelUpgrade);
			file.Close();
		}
	}
}
