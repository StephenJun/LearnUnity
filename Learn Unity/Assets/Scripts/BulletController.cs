using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    public float duration = 5;
    private Text killCount;

    // Start is called before the first frame update 
    void Start()
    {
        Invoke("DestroyMe", duration);
        killCount = GameObject.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);
    }

    private void DestroyMe()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyController enemy = collision.transform.GetComponent<EnemyController>();
        if (enemy != null)
        {
            Destroy(enemy.gameObject);
            Destroy(this.gameObject);
            print(killCount.text.Substring(11));
            int currentKill = int.Parse(killCount.text.Substring(11));
            currentKill++;
            killCount.text = "Kill Enemy:" + currentKill.ToString();
        }
    }
}
