using UnityEngine;

public class GlobalGame
{
	static readonly GlobalGame instance = new GlobalGame ();

	public static readonly string[] levels = {
		"Level1",
		"Level2",
		"Level3"
	};
	public Level currentLevel;
	public int totalDeath = 0;
	public int levelIndex = 0;

	GlobalGame ()
	{
	}

	public static GlobalGame Get ()
	{
		return instance;
	}
}
