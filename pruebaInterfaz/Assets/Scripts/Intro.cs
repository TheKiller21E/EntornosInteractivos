using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    private GameObject _principal;
    private GameObject _controles;
    private GameObject _resolucion;
    private GameObject _spam;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float duration = 1f;
    private Vector3 _princPos;
    private Vector3 _contrPos;
    private Vector3 _resPos;
    private Vector3 _spamPos;
    void Start()
    {
        _principal = GameObject.FindWithTag("principal");
        _controles = GameObject.FindWithTag("settings");
        _resolucion = GameObject.FindWithTag("resolution");
        _spam = GameObject.FindWithTag("spam");
        _princPos = _principal.transform.position;
        _contrPos = _controles.transform.position;
        _resPos = _resolucion.transform.position;
        _spamPos = _spam.transform.position;
    }

    public void PrincipalButton()
    {
        SceneManager.LoadScene(1);
    }
    public void SettingButton()
    {
        StartCoroutine(Move(_principal, _spamPos));
        StartCoroutine(Move(_controles, _princPos));
    }

    public void ResolutionButton()
    {
        StartCoroutine(Move(_resolucion,_princPos));
    }
    public void SpamButton()
    {
        StartCoroutine(Move(_spam, _princPos));
        StartCoroutine(Move(_principal, _contrPos));
    }
    public void BackButton()
    {
        StopAllCoroutines();
        StartCoroutine(Move(_principal, _princPos));
        StartCoroutine(Move(_controles, _contrPos));
        StartCoroutine(Move(_resolucion, _resPos));
        StartCoroutine(Move(_spam, _spamPos));

    }
    IEnumerator Move(GameObject toMove, Vector3 destination)
    {        
        float time = 0f;
        while (time < duration)
        {
            float step = speed * Time.deltaTime;
            toMove.transform.position = Vector3.MoveTowards(toMove.transform.position, destination, step);
            time += Time.deltaTime;
            yield return null;
        }        
        
    }
}
