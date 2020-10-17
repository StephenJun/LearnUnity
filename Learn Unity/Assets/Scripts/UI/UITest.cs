using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    private Slider testSlider;

    private Button testButton;

    // Start is called before the first frame update
    void Start()
    {
        testSlider = GetComponent<Slider>();
        testSlider.onValueChanged.AddListener(OnSliderValueChange);
        testButton = GetComponent<Button>();
        testButton.onClick.AddListener(OnButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSliderValueChange(float sliderValue)
    {
        print(sliderValue);
    }

    private void OnButtonClicked()
    {
        print(11111);
    }
}
