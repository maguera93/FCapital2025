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
        [Space, SerializeField]
        protected GlobalVariables m_globalVariables;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            UpdateLifes();
            m_globalVariables.OnPlayerHit += UpdateLifes;
            m_globalVariables.OnLifeUp += UpdateLifes;
        }

        private void OnDestroy()
        {
            m_globalVariables.OnPlayerHit -= UpdateLifes;
            m_globalVariables.OnLifeUp -= UpdateLifes;
        }

        // Update is called once per frame
        void Update()
        {
            m_salaryText.text = m_globalVariables.Salary.ToString();

        }

        void UpdateLifes()
        {
            int lifes =  m_globalVariables.Lifes;

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
