using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaHandeler : MonoBehaviour
{
    public Image ManaUI;
    public float ManaGainedSpeed;
    float CurrentManaGained;

    public static bool UpdateMana;
    public static float ManaGained;
    // Start is called before the first frame update
    void Start()
    {
        UpdateMana = false;
        ManaUI.fillAmount = 0.175f;
    }

    // Update is called once per frame
    void Update()
    {
        ManaState();
        if (ManaUI.fillAmount==1)
        {

        }
    }
    void ManaState()
    {
        if (UpdateMana)
        {
            ManaUI.fillAmount += ManaGained;
            UpdateMana = false;
            //// CurrentManaGained += ManaGainedSpeed * Time.deltaTime;
            //// CurrentManaGained = Mathf.Clamp(CurrentManaGained, 0, ManaGained);

            // ManaUI.fillAmount += CurrentManaGained;
            // if (CurrentManaGained ==ManaGained)
            // {
            //    // ManaUI.fillAmount += ManaGained;
            //     CurrentManaGained = 0;
            //     UpdateMana = false;
            // }
        }
    }
}
