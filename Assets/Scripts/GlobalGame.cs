using UnityEngine;

public class GlobalGame
{
	static readonly GlobalGame instance = new GlobalGame ();
	public Level currentLevel;

	GlobalGame ()
	{
	}

	public static GlobalGame Get ()
	{
		return instance;
	}
}
