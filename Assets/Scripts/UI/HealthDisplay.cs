using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

    [Range(0f, 1f)][SerializeField] float healthPercentage = 1f;

    [Header("Tip: Check alpha values when setting colours.")]
    public Color highHP;
    public Color medHP;
    public Color lowHP;

    float nominalBarSize;

    private RectTransform barSize;
    private Image bar;

	// Use this for initialization
	void Start () {
        barSize = GetComponent<RectTransform>();
        nominalBarSize = barSize.rect.width;
        bar = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update () {

        barSize.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, healthPercentage * nominalBarSize);

        if (healthPercentage > 0.66f && bar.color != highHP) {
            bar.color = highHP;
        } else if (healthPercentage <= 0.66f && healthPercentage > 0.4f && bar.color != medHP) {
            bar.color = medHP;
        } else if (healthPercentage <= 0.4f && bar.color != lowHP) {
            bar.color = lowHP;
        }
	}
}
