using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    float _rotationSpeed = 180f;
   [SerializeField] RunTimeData _runtimeData;
    [SerializeField] GameObject _parentQuiz;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        transform.Find("Spot Light").gameObject.SetActive(true);
        _runtimeData.CurrentFoodMousedOver = name;
    }

    private void OnMouseOver()
    {
        transform.Find("Food Mesh").RotateAround(transform.position,Vector3.up, _rotationSpeed * Time.deltaTime);
    }
    private void OnMouseExit()
    {
        transform.Find("Spot Light").gameObject.SetActive(false);
        _runtimeData.CurrentFoodMousedOver = "";
    }
    private void OnMouseDown()
    {
        if (_runtimeData.CurrentGameplayState == GameplayState.FreeWalk)
       StartCoroutine(_parentQuiz.GetComponent<FoodQuiz>().FoodSelected(gameObject));
        _runtimeData.CurrentFoodMousedOver = "";
    }
}
