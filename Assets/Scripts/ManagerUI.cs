using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Dropdown _dropdown;
    [SerializeField] private GameObject _terrainUI;
    [SerializeField] private GameObject _waterUI;
    [SerializeField] private GameObject _skyUI;

    [Header("UI Terrain")]
    [SerializeField] private TerrainGeneration _parametrsTerrain;
    [SerializeField] private Slider _sizeTerraineSlider;
    [SerializeField] private Slider _heightTerraineSlider;
    [SerializeField] private Slider _noiseTerraineSlider;

    [Header("UI Water")]
    [SerializeField] private Material _materialWater;
    [SerializeField] private Slider _speedWaveSlider;
    [SerializeField] private Slider _heightWaveSlider;
    [SerializeField] private Slider _smoothWaveSlider;

    [Header("UI Sky")]
    [SerializeField] private Volume _volume;
    [SerializeField] private Transform _globalLight;
    [SerializeField] private Slider _speedSkySlider;
    [SerializeField] private Slider _densitySkySlider;
    [SerializeField] private Slider _fogSlider;
    [SerializeField] private Slider _timeSlider;
    public void ChangeTypeSettings()
    {
        _terrainUI.SetActive(false);
        _waterUI.SetActive(false);
        _skyUI.SetActive(false);
        if (_dropdown.value == 0)
        {
            _terrainUI.SetActive(true);
        }
        else if(_dropdown.value == 1)
        {
            _waterUI.SetActive(true);
        }
        else if(_dropdown.value == 2)
        {
            _skyUI.SetActive(true);
        }
    }
    public void SetSizeTerrain()
    {
        _parametrsTerrain.SetSize((int)_sizeTerraineSlider.value);
    }
    public void SetHeightTerrain()
    {
        _parametrsTerrain.SetHeight((int)_heightTerraineSlider.value);
    }
    public void SetNoiseTerrain()
    {
        _parametrsTerrain.SetScaleNoise(_noiseTerraineSlider.value);
    }
    public void SetSpeedWater()
    {
        _materialWater.SetFloat("_SpeedWave", _speedWaveSlider.value);
    }
    public void SetHeightWater()
    {
        _materialWater.SetFloat("_Displacment", _heightWaveSlider.value);
    }
    public void SetSmoothWater()
    {
        _materialWater.SetFloat("_Smoothenes", _smoothWaveSlider.value);
    }
    public void SetSpeedSky()
    {
        if (_volume.profile.TryGet<VolumetricClouds>(out var cloud))
        {
            var currentWindSpeed = cloud.globalWindSpeed.value;
            currentWindSpeed.additiveValue = _speedSkySlider.value;
            cloud.globalWindSpeed.value = currentWindSpeed;
        }
    }
    public void SetDensitySky()
    {
        if (_volume.profile.TryGet<VolumetricClouds>(out var cloud))
        {
            cloud.shapeFactor.value = _densitySkySlider.value;
        }
    }
    public void SetFogStrength()
    {
        if (_volume.profile.TryGet<Fog>(out var fog))
        {
            fog.meanFreePath.value = _fogSlider.value;
        }
    }
    public void SetTime()
    {
        _globalLight.rotation = Quaternion.Euler(_timeSlider.value, 0, 0);
    }
}
