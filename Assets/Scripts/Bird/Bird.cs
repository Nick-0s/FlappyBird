using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private int _score;

    public event UnityAction Died;
    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<ScoreZone>(out ScoreZone scoreZone))
            IncreaseScore();
        else
            Die();
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _mover.ResetBird();
    }

    private void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
