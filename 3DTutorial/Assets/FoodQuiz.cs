using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class FoodQuiz : MonoBehaviour
{
    [SerializeField] Dialogue _dialogue;

    [SerializeField] Dialogue _correctChoiceDialogue;

    [SerializeField] Dialogue _incorrectChoiceDialogue;

    [SerializeField] GameObject _correctFood;



    public Transform target;
    float speed = 1f;
    bool moveToward = false;
    public static int hunger = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveToward == true && Player.isAlive == true)
        {
            GameObject cameraObj = Camera.main.gameObject;
            target = cameraObj.transform;
            Transform foodTran = _correctFood.transform;
            foodTran.position = Vector3.MoveTowards(foodTran.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter()
    {
        GameEvents.InvokeDialogInitiated(_dialogue);
    }
    public IEnumerator FoodSelected(GameObject food)
    {
        yield return new WaitForEndOfFrame();
        if (food == _correctFood)
        {
            GameEvents.InvokeDialogInitiated(_correctChoiceDialogue);
            GameObject cameraObj = Camera.main.gameObject;
            moveToward = true;
            hunger++;
        }
        else
        {
            GameEvents.InvokeDialogInitiated(_incorrectChoiceDialogue);
            Destroy(food);
            hunger--;
            if (hunger == 0)
            {
                Player.isAlive = false;
            }
        }
        
        
    }

    
      
}
