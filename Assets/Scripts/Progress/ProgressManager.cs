using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] private Slider _progressSlider;
    [SerializeField] private AchievementCollectBehaviour _achievementCollectionBehaviour;

    private float _progressValue = 0f;
    public float ProgressValue => _progressValue;

    public void Reset()
    {
        _progressValue = 0f;
        _achievementCollectionBehaviour.Activate(null);
    }

    public void UpdateProgress(float value)
    {
        if(_progressValue<1f)
        {
            _progressValue += (value) / 10000f;

            _progressSlider.value = _progressValue;
        }
        else
        {
            Reset();
        }
    }
}
