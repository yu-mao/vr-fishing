using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TextMeshPro _title;

    private void Start()
    {
        StartCoroutine(PlayStartupSequence());
    }

    private IEnumerator PlayStartupSequence()
    {
        _title.transform.localScale = Vector3.zero;

        yield return _title.transform.DOScale(endValue: 2f, duration: 3f).WaitForCompletion();
        yield return new WaitForSeconds(1f);

        yield return _title.transform.DOScale(endValue: 0f, duration: 0.3f).WaitForCompletion();
        yield return new WaitForSeconds(0.5f);

        _gameManager.GoToGameScene();
    }
}
