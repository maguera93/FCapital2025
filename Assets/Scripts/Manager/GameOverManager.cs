using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private int scene = 1;
    [SerializeField]
    private SceneLoader loader;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
            loader.LoadScene(scene);
    }
}
