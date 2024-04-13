using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{
    private bool active = false;

    private int count = 0;

    private float t;
    public Text timeText;

    private int rangeID = 0;
    private string range = "A";

    public GameObject finishPage;
    public Text title;
    public Text score;

    public string[] titleContent;

    public void OnHit(RaycastHit hit)
    {
        print("Hit" + hit.transform.name);
        if (hit.transform.tag == "Target")
        {
            hit.transform.GetComponent<Rigidbody>().isKinematic = false;
            hit.transform.tag = "Untagged";
            Check();
            Destroy(hit.transform.gameObject, 4f);
        }
    }

    void Check()
    {
        if (count <= 0)
        {
            active = true;
        }
        count++;
        if (count >= 15)
        {
            print("END");
            timeText.transform.parent.gameObject.SetActive(false);
            finishPage.SetActive(true);
            title.text = titleContent[rangeID];
            score.text = range;
            active = false;
        }
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (active)
        {
            if(!timeText.transform.parent.gameObject.activeSelf)
                timeText.transform.parent.gameObject.SetActive(true);

            t += Time.deltaTime;
            timeText.text = "" + (int)t;

            if (t <= 30)
            {
                range = "A";
                rangeID = 0;
                timeText.color = Color.green;

            }
            else if (t <= 45)
            {
                range = "B";
                rangeID = 1;
                timeText.color = Color.white;

            }
            else if (t <= 60)
            {
                range = "C";
                rangeID = 2;
                timeText.color = Color.yellow;

            }
            else
            {
                range = "F";
                rangeID = 3;
                timeText.color = Color.red;

            }

        }
    }
}
