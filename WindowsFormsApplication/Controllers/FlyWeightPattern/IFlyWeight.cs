namespace WindowsFormsApplication.Controllers.FlyWeightPattern
{
    public interface IFlyWeight<T>
    {
        T GetType(string key);
    }
}
