using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class WeatherManager : MonoBehaviour
{
    public string cityName = "Ljubljana";
    private string apiKey = "cffadea04a4e0a84af98588311ab05a9";
    private string weatherURL;

    public GameObject rainyBackground, sunnyBackground;

    private void Start()
    {
        weatherURL = "https://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&appid=" + apiKey;
        StartCoroutine(FetchWeatherData());
    }

    private IEnumerator FetchWeatherData()
    {
        UnityWebRequest request = UnityWebRequest.Get(weatherURL);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
        }
        else
        {
            string jsonResult = request.downloadHandler.text;
            WeatherResponse weatherData = JsonUtility.FromJson<WeatherResponse>(jsonResult);
            ApplyWeatherBackground(weatherData.weather[0].main);
            // Process the JSON data and apply the weather background
        }
    }

    void ApplyWeatherBackground(string weather)
    {
        if (weather == "Rain" || weather == "Drizzle" || weather == "Thunderstorm")
        {
            rainyBackground.SetActive(true);
            sunnyBackground.SetActive(false);
        }
        else
        {
            rainyBackground.SetActive(false);
            sunnyBackground.SetActive(true);
        }
    }
}

[System.Serializable]
public class WeatherResponse
{
    public Weather[] weather;
}

[System.Serializable]
public class Weather
{
    public string main;
}



