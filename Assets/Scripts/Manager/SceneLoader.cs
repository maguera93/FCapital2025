using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private Image fadeImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.DOFade(0.0f, 1f).OnComplete(() => fadeImage.gameObject.SetActive(false));
    }

    public void LoadScene(int scene)
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.DOFade(1f, 1f).OnComplete(()=>
        {
            SceneManager.LoadScene(scene);
        });
    }
}
