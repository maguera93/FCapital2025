using TMPro;
using UnityEngine;

namespace UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI m_salaryText;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
#if UNITY_EDITOR
            GlobalVariables.instance.Salary = 1100;
#endif
        }

        // Update is called once per frame
        void Update()
        {
            m_salaryText.text = GlobalVariables.instance.Salary.ToString();

        }
    }
}
