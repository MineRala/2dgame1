using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Rigidbody2D MyCharacter;
    // Start is called before the first frame update

    private void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(MyCharacter.position);

        if (pos.x < 0.0) Debug.Log("I am left of the camera's view.");
        if (1.0 < pos.x) Debug.Log("I am right of the camera's view.");
        if (pos.y < 0.0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
            Debug.Log("I am below the camera's view.");
        }
        if (1.0 < pos.y) Debug.Log("I am above the camera's view.");
    }

}
