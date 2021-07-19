using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantiatePlane : MonoBehaviour {
    
    void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if (scene.name == "GameScene"){
            Instantiate(Resources.Load("Planes/" + PlaneSelection.player.getModelName()) as GameObject, transform.position, Quaternion.identity);
            GameObject.Find("HUD").GetComponent<StatsUI>().OnPlaneSelection();
        }
    }

    void OnDisable(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}


