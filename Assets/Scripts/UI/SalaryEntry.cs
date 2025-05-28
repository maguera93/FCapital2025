using TMPro;
using UnityEngine;

public class SalaryEntry : MonoBehaviour
{
    private bool selected = false;
    [SerializeField]
    private int value;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private GameObject arrows;

    public bool Selected { get => selected; set
        { 
            selected = value;
            arrows.SetActive(selected);
        }
    }
    public int Value { get => value; set => this.value = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Selected)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
                ValueUp();
            else if (Input.GetKeyUp(KeyCode.DownArrow))
                    ValueDown();
        }
    }

    void ValueUp()
    {
        Value++;

        if (Value > 9)
            Value = 0;

        text.text = Value.ToString();
    }
    void ValueDown()
    {
        Value--;

        if (Value < 0)
            Value = 9;

        text.text = Value.ToString();
    }
}
