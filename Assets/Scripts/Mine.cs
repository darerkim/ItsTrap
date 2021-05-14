using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] float verticalDistance;
    [SerializeField] float horizontalDistance;
    [Range(0, 1)]
    [SerializeField] float moveSpeed;
    [SerializeField] int hp;
    [SerializeField] int demage;
    [SerializeField] GameObject go_EffectPrefab;
    // Start is called before the first frame update

    Vector3 endPos1;
    Vector3 endPos2;
    Vector3 currentDestination;

    private void Start()
    {
        Vector3 originPos = transform.position;
        endPos1.Set(originPos.x, originPos.y + verticalDistance, originPos.z + horizontalDistance);
        endPos2.Set(originPos.x, originPos.y - verticalDistance, originPos.z - horizontalDistance);
        currentDestination = endPos1;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, currentDestination, moveSpeed);
        if ((transform.position - endPos1).sqrMagnitude <= 0.1f)
            currentDestination = endPos2;
        else if ((transform.position - endPos2).sqrMagnitude <= 0.1f)
            currentDestination = endPos1;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.name == "Player")
        {
            other.transform.GetComponent<StatusManager>().DecreaseHP(demage);
            Explosion();
        }
    }

    public void Demaged(int _num)
    {
        hp -= _num;
        if (hp <=0) Explosion();
    }

    void Explosion()
    {
        var clone = Instantiate(go_EffectPrefab, transform.position, Quaternion.identity);
        SoundManager.instance.PlaySE("Mine");
        Destroy(clone, 2f);
        Destroy(gameObject);
    }
}
