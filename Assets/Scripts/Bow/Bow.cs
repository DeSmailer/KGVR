using System.Collections;
using UnityEngine;

public class Bow : MonoBehaviour
{

    public float Tension;
    private bool _pressed;
    public Transform RopeTransform;
    public Vector3 RopeNearLocalPosition;
    public Vector3 RopeFarLocalPosition;
    public AnimationCurve RopeReturnAnimation;
    public float ReturnTime;
    public Arrow CurrentArrow = null;
    public AudioSource ArrowAudio;
    public AudioSource BowAudio;

    public GameObject ar;

    void Update()
    {

        float screenPosition_x = Input.mousePosition.x;
        float screenPosition_y = Input.mousePosition.y;

        if (screenPosition_x > 90 * Screen.width / 100 && screenPosition_y < Screen.width / 10)
            return;

        if (Stats.Instance.Ammo <= 0)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            _pressed = true;

            if (CurrentArrow == null)
                CurrentArrow = Instantiate(ar).GetComponent<Arrow>();

            CurrentArrow.SetToRope(RopeTransform, transform);

            BowAudio.pitch = Random.Range(0.8f, 1.2f);
            BowAudio.Play();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _pressed = false;

            StartCoroutine(RopeReturn());
            CurrentArrow.Shot(Stats.Instance.ArrowSpeed * Tension);
            Tension = 0;

            BowAudio.Stop();

            ArrowAudio.pitch = Random.Range(0.8f, 1.2f);
            ArrowAudio.Play();
            CurrentArrow = null;

            Stats.Instance.Ammo--;
        }

        if (_pressed)
        {
            if (Tension < 1f)
            {
                Tension += Time.deltaTime;
            }
            RopeTransform.localPosition = Vector3.Lerp(RopeNearLocalPosition, RopeFarLocalPosition, Tension);
        }
    }

    IEnumerator RopeReturn()
    {
        Vector3 startLocalPosition = RopeTransform.localPosition;
        for (float f = 0; f < 1f; f += Time.deltaTime / ReturnTime)
        {
            RopeTransform.localPosition = Vector3.LerpUnclamped(startLocalPosition, RopeNearLocalPosition, RopeReturnAnimation.Evaluate(f));
            yield return null;
        }
        RopeTransform.localPosition = RopeNearLocalPosition;
    }

}
