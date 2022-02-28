using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cubes : MonoBehaviour
{
    [SerializeField] private Transform[] cubes;
    [SerializeField] private float endValueX;

    public void MoveSequence()
    {
        var sequence = DOTween.Sequence();

        foreach (var cube in cubes)
        {
            sequence.Append(cube.DOMoveX(endValueX, Random.Range(1, 2)).SetLoops(2, LoopType.Yoyo));
        }

        sequence.OnComplete(() =>
        {
            foreach (var cube in cubes)
            {
                cube.DOScale(Vector3.zero, .5f).SetEase(Ease.InBounce);
            }
        });
    }

    public async void MoveAsync()
    {
        foreach (var cube in cubes)
        {
            await cube.DOMoveX(endValueX, Random.Range(1, 2)).SetLoops(2, LoopType.Yoyo).AsyncWaitForCompletion();
            cube.DOScale(Vector3.zero, .5f).SetEase(Ease.InBounce);
        }
    }

    public async void MoveTasks()
    {
        var tasks = new List<Task>();

        foreach (var cube in cubes)
        {
            tasks.Add(cube.DOMoveX(endValueX, Random.Range(1, 2)).SetLoops(2, LoopType.Yoyo).AsyncWaitForCompletion());
        }

        await Task.WhenAll(tasks);

        foreach (var cube in cubes)
        {
            await cube.DOScale(Vector3.zero, .5f).SetEase(Ease.InBounce).AsyncWaitForCompletion();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}