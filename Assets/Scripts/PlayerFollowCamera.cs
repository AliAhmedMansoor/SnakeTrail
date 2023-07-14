using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerFollowCamera : MonoBehaviour
{


    public Transform cam;
    public GameObject SytheProjectile;
    Transform SytheBlade;
    float Xaxis;
    public float fallHeight;
    public Image Panel;
    float OpLevel;
    Color tempColor;
    public float Sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        tempColor = Panel.color;
        tempColor.a = 0;
        OpLevel = 0;
        SytheBlade =cam.GetChild(0).GetChild(0).GetChild(1);
            Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        DeathChecker();
        Xaxis = Input.GetAxis("Mouse X") *Sensitivity*Time.deltaTime;
        transform.Rotate(0, Xaxis, 0, Space.Self);
     
    }

    public void PrimaryAttackEnded()
    {
        Instantiate(SytheProjectile, SytheBlade.position, SytheBlade.rotation);
    }
    void DeathChecker()
    {
        if(transform.position.y<fallHeight)
        {

            RevealPanel();
      


        }
    }
    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(0);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    public void LoadScene()
    {
        StartCoroutine(LoadYourAsyncScene());
    }
    void RevealPanel()
    {
        if (!Panel.gameObject.activeSelf)
        {
            Panel.gameObject.SetActive(true);
            Panel.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

        tempColor.a =OpLevel;
        Panel.color = tempColor;
        OpLevel += Time.deltaTime;
        if(OpLevel>=1)
        {
            if (Cursor.lockState != CursorLockMode.None)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }


                Panel.gameObject.transform.GetChild(0).gameObject.SetActive(true);
          
        }
    }
}
