

using System.Collections.Generic;

public interface ITemperatureEnviroment
{
    List<ITemperatureObject> temperatureObjects { get; }
    void ApplyTemperatureChange(List<ITemperatureObject> target);
}

public class Test : ITemperatureEnviroment
{
    private List<ITemperatureObject> _datas;
    public List<ITemperatureObject> temperatureObjects => this._datas;
    public void ApplyTemperatureChange(List<ITemperatureObject> target) {
        
    }
}
