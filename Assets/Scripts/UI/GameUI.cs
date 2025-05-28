using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI m_salaryText;
        [SerializeField]
        private Image[] heartImages;
        [SerializeField]
        private Sprite emptyHeart;
        [SerializeField]
        private Sprite fullHeart;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            UpdateLifes();
            GlobalVariables.instance.OnPlayerHit += UpdateLifes;
            GlobalVariables.instance.OnLifeUp += UpdateLifes;
        }

        private void OnDestroy()
        {
            GlobalVariables.instance.OnPlayerHit -= UpdateLifes;
            GlobalVariables.instance.OnLifeUp -= UpdateLifes;
        }

        // Update is called once per frame
        void Update()
        {
            m_salaryText.text = GlobalVariables.instance.Salary.ToString();

        }

        void UpdateLifes()
        {
            int lifes =  GlobalVariables.instance.Lifes;

            for (int i = 0; i < heartImages.Length; i++)
            {
                heartImages[i].sprite = emptyHeart;
            }

            for (int i = 0; i < lifes; i++)
            {
                heartImages[i].sprite = fullHeart;
            }
        }
    }
}
