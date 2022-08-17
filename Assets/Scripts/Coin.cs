using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

[RequireComponent(typeof(Collider))]
public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject MeshObject;
    [SerializeField] private AudioSource Audio;

    private TweenerCore<Vector3, Vector3, VectorOptions> _flyingAction;
    private TweenerCore<Quaternion, Vector3, QuaternionOptions> _rotatingAction;

    private void OnTriggerEnter(Collider other)
    {
        if (other == null || other.tag != "Player")
            return;

        if (Audio != null)
            Audio.Play();

        Events.CoinPicked.Invoke();

        StartCoroutine(DestroyAfterAnimation(1f));
    }
    private IEnumerator DestroyAfterAnimation(float delay)
    {
        MeshObject.transform.DOMoveY(10, delay);

        yield return new WaitForSecondsRealtime(delay);

        SafeDestroy();
    }
    private void SafeDestroy()
    {
        _flyingAction.Kill();
        _rotatingAction.Kill();
        Destroy(gameObject);
    }

    private void Start()
    {
        _flyingAction = MeshObject.transform.DOMoveY(2, 2).SetLoops(-1, LoopType.Yoyo);
        _rotatingAction = MeshObject.transform.DOLocalRotate(new Vector3(0, 360, 0), 5).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }
}
