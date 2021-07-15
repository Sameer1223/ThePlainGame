using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantiatePlane : MonoBehaviour {
    void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if (scene.name == "GameScene"){
            Debug.Log("Cringe!");
            Instantiate(Resources.Load("Planes/" + PlaneSelection.player.getModelName()) as GameObject, transform.position, Quaternion.identity);
        }
    }

    void OnDisable(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}


