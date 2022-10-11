using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* LoadScene.cs
 * 
 * Created: Rodney Johnston on 4/21/2020
 *
 * Purpose: This class is used to change scenes when a button is pressed. It will be
 *          used for the main menu, pause menu, and the back to main menu button.
 *          
 * Use:     Place this script onto the main camera, then, in the button's inspector, go to
 *          the On Click () function in the Button Script Component. Then, click the plus sign,
 *          make it Runtime Only, then select the main camera for the object, then select the
 *          ChangeScene's Change function, and finally type in the scene it will change to.
 */
public class LoadScene : MonoBehaviour
{
    // The change method will take in the name of scene it will transition to, and load that scene.
    public void Change(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
