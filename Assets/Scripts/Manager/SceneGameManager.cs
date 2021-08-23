using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGameManager : MonoBehaviour
{
	public Animator transition;

	float transitionTime = 1f;

    public void LoadScene(string sceneToLoad)
	{
		StartCoroutine(LoadLevel(sceneToLoad));
	}

	IEnumerator LoadLevel(string sceneToLoad)
	{
		transition.SetTrigger("Start");

		yield return new WaitForSeconds(transitionTime);

		SceneManager.LoadScene(sceneToLoad);
	}
}
