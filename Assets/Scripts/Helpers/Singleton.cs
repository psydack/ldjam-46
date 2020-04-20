using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	// Check to see if we're about to be destroyed.
	private static bool m_ShuttingDown = false;
	private static object m_Lock = new object();
	private static T m_Instance;

	/// <summary>
	/// Access singleton instance through this propriety.
	/// </summary>
	public static T Instance
	{
		get
		{
			if (m_ShuttingDown)
			{
				Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
					"' already destroyed. Returning null.");
				return null;
			}
			return m_Instance;
		}
	}

	private void Awake()
	{
		m_Instance = gameObject.GetComponent<T>();
	}

	private void OnApplicationQuit()
	{
		m_ShuttingDown = true;
	}


	private void OnDestroy()
	{
		m_ShuttingDown = true;
	}
}