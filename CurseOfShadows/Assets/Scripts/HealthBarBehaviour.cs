using UnityEngine;
using UnityEngine.UI;
public class HealthBarBehaviour : MonoBehaviour 
{ 
    public Slider Slider; 
    public Color low;
    public Color high;
    public Vector3 Offset;


    //geting helth and max health
    public void SetHealth(float health, float maxHealth) 
    { 
    
        //checking if the enemies health is lower than its max
        Slider.gameObject.SetActive(health < maxHealth); 
        //setting the sliders value to the health the enemy has
        Slider.value = health; 
        //setting the maximim value of the health bar
        Slider.maxValue = maxHealth; 


        //using the value collected from health to blend the colour high and colour low and creating a gradient of the 2 colours depending on the state of the health
        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, Slider.normalizedValue); 
    } 


    void Update() 
    { 
        //Slider.transform.position = Camera.main.WorldToScreenPoint(transform.position + Offset);
        //Slider.transform.position = transform.position + Offset;
    } 
}