using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 1;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    // Функция вызывается, когда с триггером сталкивается другой объект
    void OnTriggerEnter(Collider other) 
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        // Проверка, является ли этот объект игроком
        if (player != null)
        {
            player.Hurt(damage);
        }
        Destroy(this.gameObject);
    }
}
