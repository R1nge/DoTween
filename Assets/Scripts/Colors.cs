using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colors : MonoBehaviour
{
    [SerializeField] private MeshRenderer shape;

    public void ChangeColor()
    {
        shape.material.DOColor(Random.ColorHSV(), .3f);
    }

    public void ReloadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}