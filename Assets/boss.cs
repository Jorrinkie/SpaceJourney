using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
    [SerializeField] private float Timer;
    [SerializeField] private int RandomWait;
    [SerializeField] private int RandomYValue;
    [SerializeField] Vector3 NewPosition;
    [SerializeField] private Vector3 Oldpos;
    [SerializeField] private float Duration = 3f;
    [SerializeField] private float TimePassed;
    [SerializeField] private float Healthh = 100;
    public Slider slider;
    [SerializeField] private GameObject SliderHolder;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject Bullet2;
    [SerializeField] private float Timer2;
    [SerializeField] private float shootchance;
    [SerializeField] private GameObject BulletSpawner;
    [SerializeField] private float Xpos;
    [SerializeField] private InfoGiver info;
    [SerializeField] private HighScore score;

    // Start is called before the first frame update
    void Start()
    {
        info = transform.parent.parent.GetComponent<InfoGiver>();
        SliderHolder = GameObject.Find("Healthbar");
        slider = SliderHolder.GetComponent<Slider>();
        BulletSpawner = GameObject.Find("BulletSpawner");
        Xpos = 6;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Healthh;

        Healthh -= 1 * Time.deltaTime;
        Timer2 += Time.deltaTime;
        if (Timer2 > 1)
        {
            Timer2 = 0;
            shootchance = Random.Range(1, 3);
            if (shootchance == 1)
            {
                Shoot();
            }

        }
        Timer += Time.deltaTime;
        TimePassed += Time.deltaTime;
        float percantagecomplete = TimePassed / Duration;

        if (Healthh < 34)
        {
            Xpos = 0;
            Timer += 100;
        }

        if (Timer > RandomWait)
        {
            RandomWait = Random.Range(8, 16);
            Timer = 0;
            if (Healthh > 34)
            {
                RandomYValue = Random.Range(-4, 4);
            }
            else
            {
                RandomYValue = 0;
                
            }
            NewPosition = new Vector3(Xpos, RandomYValue, -9.8f);
            Oldpos = transform.position;
            
            TimePassed = 0;
        }
        transform.position = Vector3.Lerp(Oldpos, NewPosition, Mathf.SmoothStep(0, 1, percantagecomplete));


    }

    private void Shoot()
    {
        if (Healthh > 66 && Healthh < 98)
        {
            //phase 1


                Vector3 SpawnLocation = new Vector3(transform.position.x, transform.position.y + Random.Range(-0.5f, 0.5f), -1);
                GameObject newObject = Instantiate(Bullet, SpawnLocation, transform.rotation);
                newObject.transform.parent = BulletSpawner.transform;
            SpawnLocation = new Vector3(transform.position.x, transform.position.y + Random.Range(-0.5f, 0.5f), -1);
            GameObject newObject2 = Instantiate(Bullet, SpawnLocation, transform.rotation);
            newObject2.transform.parent = BulletSpawner.transform;
            SpawnLocation = new Vector3(transform.position.x, transform.position.y + Random.Range(-0.5f, 0.5f), -1);
            GameObject newObject3 = Instantiate(Bullet, SpawnLocation, transform.rotation);
            newObject3.transform.parent = BulletSpawner.transform;

        }
        else if (Healthh > 33 && Healthh < 66)
        {
            //phase 2
            Vector3 SpawnLocation = new Vector3(transform.position.x, transform.position.y + Random.Range(-0.5f, 0.5f), -1);
            GameObject newObject = Instantiate(Bullet2, SpawnLocation, transform.rotation);
            newObject.transform.parent = BulletSpawner.transform;




        }
        else if (Healthh > 0 && Healthh < 30)
        {
            //phase 3
            info.CircleSpawner.SetActive(true);
        }
        else if (Healthh < 1)
        {
            //Death
            info.CircleSpawner.SetActive(false);
            score = info.Canvas.GetComponent<HighScore>();
            score.TimeF += 50;
            Destroy(gameObject);
        }
    }

    

}
