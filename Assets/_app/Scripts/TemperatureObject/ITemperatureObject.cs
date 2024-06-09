

public interface ITemperatureObject
{

    float maxTemperature { get; }
    float minTemperature { get; }
    float currentTemperature { get; }

    void IncreaseTemperature(double amount);

    void OnChangeTemperature();
    void OnOverMaxTemperatureLimit();
    void OnLowerMinTemperatureLimit();
}

