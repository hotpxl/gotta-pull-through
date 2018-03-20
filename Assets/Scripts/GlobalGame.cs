public class GlobalGame
{
	static readonly GlobalGame instance = new GlobalGame ();
	public Level currentLevel;
	bool paused = false;
	bool interactive = false;

	GlobalGame ()
	{
	}

	public static GlobalGame Get ()
	{
		return instance;
	}

	public void SetPause (bool p)
	{
		paused = p;
	}

	public void SetInteractive(bool p) {
		interactive = p;
	}

	public bool IsPlayable ()
	{
		return !paused && interactive;
	}
}
