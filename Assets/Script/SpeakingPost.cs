using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class SpeakingPost : MonoBehaviour
{
    public PostProcessVolume volume;

    private LensDistortion _Lens;
    
    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out _Lens);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LensPlayerTalking()
    {
        StartCoroutine(PlayerTalking(3f));
    }

    public void LensJanTalking()
    {
        var currentValue = _Lens.intensity.value;
        StartCoroutine(JanMoving(3f));
        // post.GetComponent<LensDistortion>().intensity.value = 50; 
    }
    

    IEnumerator JanMoving(float time )
    {
        
        float elapsedTime = 0;
        var currentValue = _Lens.intensity.value; 
 
        while (elapsedTime < time)
        {
            _Lens.intensity.value = Mathf.Lerp(currentValue, 50, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    
    IEnumerator PlayerTalking(float time )
    {
        
        float elapsedTime = 0;
        var currentValue = _Lens.intensity.value; 
 
        while (elapsedTime < time)
        {
            _Lens.intensity.value = Mathf.Lerp(currentValue, 0, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    
}
