using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public Pause pause;
    SpriteRenderer spriteRenderer;
    public string bonusGun;
    public int bonusMoney;
    float fallingSpeed = 0.04f;

    bool repeatTrigger = false;
    float destroyTime = 8f;
    bool animation1 = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        if (pause.gamePaused) return;

        if(transform.position.y > fallingSpeed)
        {
            transform.Translate(new Vector3(0, -fallingSpeed, 0));
        }

        if (transform.position.y <= fallingSpeed)
        {
            destroyTime -= Time.fixedDeltaTime;

            if (destroyTime > 0 && destroyTime <= 3 && !repeatTrigger)
            {
                repeatTrigger = true;
                InvokeRepeating(nameof(PlayAnimation), 0.2f, 0.2f);
            }

            else if (destroyTime <= 0) Destroy(gameObject);
        }
    }

    void PlayAnimation()
    {
        if(!animation1)
            spriteRenderer.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 100 / 255f);
        else
            spriteRenderer.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);

        animation1 = !animation1;
    }
}
