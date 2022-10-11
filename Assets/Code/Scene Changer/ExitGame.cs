using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ExitGame.cs
 * 
 * Created: Rodney Johnston on 4/21/2020
 *
 * Purpose: This class is used to end the game when a button is pressed. It will be
 *          used for the main menu and pause menu.
 *          
 * Use:     Place this script onto the main camera, then, in the button's inspector, go to
 *          the On Click () function in the Button Script Component. Then, click the plus sign,
 *          make it Runtime Only, then select the main camera for the object, then, finally, select
 *          the EndGame's End function.
 */
public class ExitGame : MonoBehaviour
{
    // Method that will end the game
    public void End()
    {
        // Debugs, so we can check if the button will work in the unity editor.
        Debug.Log("End your life");
        Application.Quit();
    }
}
