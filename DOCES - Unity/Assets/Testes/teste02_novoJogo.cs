using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[IntegrationTest.DynamicTestAttribute("testScene")]
// [IntegrationTest.Ignore]
[IntegrationTest.ExpectExceptions(false, typeof(ArgumentException))]
[IntegrationTest.SucceedWithAssertions]
[IntegrationTest.TimeoutAttribute(1)]
[IntegrationTest.ExcludePlatformAttribute(RuntimePlatform.Android, RuntimePlatform.LinuxPlayer)]




public class teste02_novoJogo : MonoBehaviour
{
	GameObject obj;		
	public static class WaitFor{
    	public static IEnumerator Frames(int frameCount){
   
        while (frameCount > 0){
            frameCount--;
            yield return null;
        }
    }
}

	public IEnumerator novo_jogo(){
			obj = GameObject.Find("NewGameButton");
			ClickAnimationControl component = obj.GetComponent<ClickAnimationControl>();		
			Debug.Log("Int Teste 2: Estado 1");
	    	component.OnMouseEnter();
			component.fakeClick(false);		
	    	yield return WaitFor.Frames(2); 
	    	//yield return new WaitForSeconds( 1.0f );
	    	Debug.Log("Int Teste 2: Estado 2");
			component.fakeClick(true);
			component.OnMouseExit();
	    	yield return WaitFor.Frames(200);

	    	//check se estado do jogo alterou e nova posicao da camera
	    	//esta ativa
	    	obj = GameObject.Find("CharSelectScene");
	    	if(obj) 
				IntegrationTest.Pass(gameObject);
			else
				IntegrationTest.Fail(gameObject);
	}


    public void Start()
    {
		StartCoroutine(novo_jogo());			
    }
}
