using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlickerPlayer : MonoBehaviour
{
    public SpriteRenderer sprite;
    public int flickerAmnt;
    public float flickerDuration;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage()
    {
        StartCoroutine(Damage());
    }

    IEnumerator Damage()
    {
        for (int i = 0; i < flickerAmnt; i++)
        {
            //sprite.color = new Color(1f, 1f, 1f, .5f);
            sprite.color = Color.red;
            yield return new WaitForSeconds(flickerDuration);
            sprite.color = Color.white;
            yield return new WaitForSeconds(flickerDuration);
        }

        //for (int i = 0; i < flickerAmnt; i++)
        //{
        //    foreach(SpriteRenderer s in sprites)
        //    {
        //        s.color = new Color(1f, 1f, 1f, .5f);
        //    }
        //    yield return new WaitForSeconds(flickerDuration);
        //    foreach(SpriteRenderer s in sprites)
        //    {
        //        s.color = Color.white;
        //    }
        //    yield return new WaitForSeconds(flickerDuration);
        //}
    }
}
